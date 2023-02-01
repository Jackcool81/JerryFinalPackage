using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBullet : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2);

    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.up * 100);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        print ("hit");
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
        // Destroy(this.gameObject);
    }
}
