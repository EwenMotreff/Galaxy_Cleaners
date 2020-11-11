using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    //Variables
    public float Force = 800f, DestroyTime = 1f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Start()
    {
        //Assignation
        rb.AddForce(Vector2.up * Force);
        Destroy(gameObject, DestroyTime);
    }

    //private void OnDestroy()
    //{
    //    //Assignation de True a la variable CanShoot du PlayerController
    //    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().CanShoot = true;
    //}
}
