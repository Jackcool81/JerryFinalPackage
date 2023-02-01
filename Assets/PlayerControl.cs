using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5.0f;
    Rigidbody2D rb;
    public GameObject bullet;
    public Transform firepoint;
    public int PlayerHealth = 50;
    public GameObject shield;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Acessing Rigidbody functions
    }

 void OnCollisionEnter2D(Collision2D collision)
    {
        print ("shield hit");
        if (collision.gameObject.tag == "EnemyBullet")
        {
            PlayerHealth = PlayerHealth - 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Moving
        float xmove = Input.GetAxisRaw("Horizontal"); //Get where the players wants to go, a or d 
        rb.velocity = new Vector2(xmove, rb.velocity.y) * speed;//change the velocity of the rigidbody for this object, moving it on the x axis

        if (Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            
           //Physics2D.IgnoreCollision( bullet1.transform.GetComponent<Collider2D>(), shield.GetComponent<Collider2D>());
        }
        if (PlayerHealth <= 0){
            Destroy(this.gameObject);
        }
    }
}
