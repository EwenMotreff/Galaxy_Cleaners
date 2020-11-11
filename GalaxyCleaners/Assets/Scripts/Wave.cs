using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject[] AlienType;
    public float SpaceColumns = 2f, SpaceRows = 2f;
    public int TotalAlienInLine = 6;
    public bool CanMoove = true;
    public bool Walkright = true;
    public float WaveStepRight = 1f, WaveStepDown = 1f, WaveSpeed = 0.8f;

    private void Awake()
    {
        // Generation de la vague d'alien
        for (int i = 0; i < AlienType.Length; i++) //boucle sur tous les elements du tableau
        {
            float posY = transform.position.y - (SpaceRows * i); //définition de la ligne (y)
            for (int n = 0; n < TotalAlienInLine; n++) //boucle sur le nb d'alien à instancier
            {
                //definition de la position x de l'alien sur la ligne y.
                Vector2 posX = new Vector2(transform.position.x + (SpaceColumns * n), posY);
                GameObject Go = Instantiate(AlienType[i].gameObject, posX, Quaternion.identity); //instantiation
                Go.transform.SetParent(this.transform); //Objet enfant de Wave
                Go.name = "Alien" + (n + 1) + "-row:" + (i + 1); //Définition du nom des aliens 
            }

        }
    }

    private void Start()
    {
            StartCoroutine(MooveWave());
    }

    IEnumerator MooveWave()
        {
            while (CanMoove)
            {
                Vector2 direction = Walkright ? Vector2.right : Vector2.left;
                transform.Translate(direction * WaveStepRight);
                yield return new WaitForSeconds(WaveSpeed);
            }
        }
}