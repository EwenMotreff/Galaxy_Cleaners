using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Déclarations
    Vector2 PositionPlayer;
    public float speed = 10f;
    public float limitx = 9f;
    public float limity = 5.8f;
    public GameObject BulletPrefab;
    Transform ejectPosition;
    //public bool CanShoot = true;

    void Start()
    {
        PositionPlayer = transform.position;
        ejectPosition = transform.Find("Eject");
    }

    
    void Update()
    {
        MovePlayer();
        PlayerShoot();
    }

    void MovePlayer()
    {
        //Déplacement du canon en limitant l'axe x
        PositionPlayer.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        PositionPlayer.x = Mathf.Clamp(PositionPlayer.x, -limitx, limitx);
        transform.position = PositionPlayer;
        //Déplacement du canon en limitant l'axe y
        PositionPlayer.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        PositionPlayer.y = Mathf.Clamp(PositionPlayer.y, - 3.6f , limity);
        transform.position = PositionPlayer;
    }

    void PlayerShoot()
    {
        if( Input.GetKeyDown(KeyCode.Space))//&& CanShoot
        {
            //CanShoot = false; //ne peut plus tirer
            Instantiate(BulletPrefab, ejectPosition.position, Quaternion.identity);
        }
    }
}
