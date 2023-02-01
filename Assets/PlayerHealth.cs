using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100.0f;
    public GameObject GameOver;
    public GameObject healthText;

    private void OnCollisionStay(Collision other){
        if(other.collider.CompareTag("Zombie")){
            Health = Health - 0.1f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        healthText = GameObject.Find("HP");
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Health <= 0)
        {
            StartCoroutine (reset());
        }
        else {
            healthText.GetComponent<TextMeshProUGUI>().text = Health.ToString();
        }
    }

    //Coroutine, wait a certain number of seconds in unity
    IEnumerator reset(){
        GameOver.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        SceneManager.LoadLevel("Menu");
    }
}
