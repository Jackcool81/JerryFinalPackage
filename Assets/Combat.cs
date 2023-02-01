using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Combat : MonoBehaviour
{
public bool canCombat = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" ) { 
            if (canCombat) {
                canCombat = false;
                SceneManager.LoadScene("BattleScene");
            }
        }
        
    }
}
