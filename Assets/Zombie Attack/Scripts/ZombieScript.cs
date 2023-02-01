using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZombieScript : MonoBehaviour
{
    public UnityStandardAssets.Characters.ThirdPerson.AICharacterControl aicc;
    public ZombieSpawnerScript parentSpawner;
    private GameObject Score;
    private void Awake() 
    {
        Score = GameObject.Find("Canvas");
        if(aicc == null)
        {
            aicc = GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
        }
    }

    public void Init(Transform target, ZombieSpawnerScript spawner)
    {
        if(aicc == null)
        {
            aicc = GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>();
        }
        aicc.target = target;
        parentSpawner = spawner;
    }

    public void KillZombie()
    {
        // ADD CODE HERE
        print("Killing Zombie");
        Score.GetComponent<ScoreScript>().money += 10; 
        Destroy(this.gameObject);
        // END OF CODE
    }
}
