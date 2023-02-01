using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kill : MonoBehaviour
{
    public Transform player;
    private Transform previous;
    // Start is called before the first frame update
    void Start()
    {
        previous = player;
    }

    // Update is called once per frame
    void Update()
    {
        if (previous.position.y < player.position.y) {
            previous = player;
            transform.position = player.position + new Vector3(0, -10, 0);
        }
        else {
            transform.position = transform.position;
        }
        
    }

    void OnCollisionEnter2D(Collision2D col){
        Destroy(col.gameObject);
        SceneManager.LoadScene("Menu");
    }

   
}
