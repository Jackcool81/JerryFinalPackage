using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public TextMeshProUGUI score;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] arr = GameObject.FindGameObjectsWithTag("Enemy");
        if (arr.Length == 0) {
            StartCoroutine(countWait());
        }
        
    }

    IEnumerator countWait() {
        score.text = (48 - count).ToString(); 
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Menu");
    }   

    void OnCollisionEnter2D(Collision2D enemy) {
        count = count + 1;
        Destroy(enemy.gameObject);

    }

    
}
