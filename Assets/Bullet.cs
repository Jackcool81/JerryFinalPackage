using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody RB;
    void OnCollisionEnter(){
        RB.isKinematic = true;
        RB.isKinematic = false;
        // Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent <Rigidbody>();
        Destroy(gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
