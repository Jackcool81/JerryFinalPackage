using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        //InnvokeRepeating is a Unity Function that will call whatever function we want forever
        //First Parameter is the String name of the function you want to run
        //Second Paramter is how much time inbetween function calls
        
        InvokeRepeating("Shoot", 2f, 1f);
        rb = GetComponent<Rigidbody2D>();
    }

    void Shoot() {
        print("hi");
        //Generates a ranbdom number from 1 to 10
        int x = Random.Range(1, 10);
        if (x == 5) 
        {
            print("IM SHOOTIN");
            Instantiate(bullet, gameObject.transform.position, gameObject.transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.down * 0.001f;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
