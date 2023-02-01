using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Respawner : MonoBehaviour
{
    public Transform player;
    public GameObject scoreText;
    public GameObject finishedTest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < player.transform.position.y + -10 ){
            transform.position = player.transform.position + new Vector3(0, -10, 0);
        }
        scoreText.GetComponent<TextMeshProUGUI>().text = Mathf.Clamp(Mathf.Round(player.transform.position.y),0,1000000000000000).ToString();
       

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        print(col);
        Destroy(col.gameObject);
        if (col.gameObject.GetComponent<Player>() != null) {
            StartCoroutine(finished());
       
        }
    }

    IEnumerator finished() {
        finishedTest.GetComponent<TextMeshProUGUI>().text = "You lost final score " + scoreText.GetComponent<TextMeshProUGUI>().text;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
}