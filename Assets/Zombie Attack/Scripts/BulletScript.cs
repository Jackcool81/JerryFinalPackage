using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Rigidbody rb;
    public int damage = 10;

    private void Start() 
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, 5);
    }

    public void FireBullet(Vector3 direction, float power)
    {
        rb.AddForce(direction * power, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other) 
    {
        // if(other.gameObject.GetComponent<BulletScript>() != null || other.gameObject.CompareTag("Player"))
        // {
        //     return;
        // }
        // print("Incolloision Enter");
        if (other.gameObject.tag == "Zombie"){
            print("inCollision");
            
            other.gameObject.GetComponent<HealthScript>().ChangeHealth(-34);
            Destroy(this.gameObject);
        }

    }
}
