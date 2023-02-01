using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    private Vector3 direction;
    public float speed = 5.0f;
    private bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(1,3);
        if (x == 1) {
            direction = new Vector3(10f, 0, 0);
        }
        else {
            direction = new Vector3(-10f, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = transform.position - direction * Time.deltaTime;

        if (transform.position.x <= -8) {
            direction = new Vector3(-speed, 0, 0);
        }   
        if (transform.position.x >= 8) {
            direction = new Vector3(speed, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col) {
        col.gameObject.GetComponent<Player>().Jump();
        Destroy(this.gameObject, 3.5f);
        if (spawned == false) {
            Instantiate(this.gameObject, new Vector3(Random.Range(-8,8), this.transform.position.y + 10.0f, 0f), Quaternion.identity);
            spawned = true;
        }
    }
}