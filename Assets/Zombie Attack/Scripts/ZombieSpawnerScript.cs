using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZombieSpawnerScript : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform target;

    public float spawnRange = 10;

    public UnityEvent ZombieDied;

    void Start()
    {
        SpawnZombie();
    }

    public Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-spawnRange,spawnRange), 1, Random.Range(-spawnRange,spawnRange));
    }

    public void SpawnZombie()
    {
        // ADD CODE HERE
        //Create a variable GameObject called Zombie
        //Variable, DataType Name
        //Datatype = GameObject
        //name = zombie
        //Set variable equal to Instaniate(ZombiePrefab)
        
        //Set the zombie transform position to the result of Random Position() 
        //Refrence zombie position using dot format
        //zombite.transform.position
        //set the zombie.transform.position = Call the Random Position function
        
        // Use GetComponent to get the Zombie scripts init method
        //zombie.GetComponent<ZombieScript>().Init(target, this)
        // END OF CODE
    }

    public void ZombieHasDied()
    {
        ZombieDied?.Invoke();
    }
}
