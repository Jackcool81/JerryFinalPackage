using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D player;
    public GameObject questLog;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (questLog.activeSelf == false)
            {
                questLog.SetActive(true);
            }
            else
            {
                questLog.SetActive(false);
            }

        }
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal > 0){
            gameObject.transform.localScale = new Vector3 (4.3679f,4.3497f,1f);
        }
        if (horizontal < 0){
            gameObject.transform.localScale = new Vector3 (-4.3679f,4.3497f,1f);
        }
        Vector3 direction = new Vector3(horizontal, vertical, 0);
        direction = direction.normalized * speed * Time.deltaTime;
        player.MovePosition(player.transform.position + direction);
        
       
    }
}
