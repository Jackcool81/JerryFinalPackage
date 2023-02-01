using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Spawner : MonoBehaviour
{
    public GameObject Zombie;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        SpawnZombie(); //call the function to spawn 1 zombie
        InvokeRepeating("SpawnZombie", 0.0f, 2.0f);
    }

    // Update is called once per frame
  
    void SpawnZombie(){
        GameObject zombieCopy = Instantiate(Zombie,this.gameObject.transform);
        zombieCopy.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = Player.transform;
    }
}
