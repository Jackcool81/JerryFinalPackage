using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public float speed = 5.0f;
    //Rigidbody2D rb;
    public int ShieldHealth = 50;
     public Transform target;
        public float lerpSpeed = 1.0f;

        private Vector3 offset;

        private Vector3 targetPos;

    // Start is called before the first frame update
   private void Start()
        {
            if (target == null) return;

            offset = transform.position - target.position;
        }

 void OnCollisionEnter2D(Collision2D collision)
    {
        print ("shield hit");
        if (collision.gameObject.tag == "EnemyBullet")
        {
            ShieldHealth = ShieldHealth - 5;
        }
        if (collision.gameObject.tag == "Bullet"){
            //print(collision.gameObject.GetComponent<Collider2D>());
            //print(GetComponent<Collider2D>());
           
        }
    }
    
  


       
     

    private void Update()
    {
        if (target == null) return;

        targetPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);

        if (ShieldHealth <= 0){
            Destroy(this.gameObject);
        }
    }

    


}
