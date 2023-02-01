using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void Ooo() {
        SceneManager.LoadScene("JerryRpg");
    }
    public void SpaceDogs() {
        SceneManager.LoadScene("SpaceDogs");
    }
    public void DoodleJump() {
        SceneManager.LoadScene("DoodleJump");
    }
    public void Obstaclecourse() {
        SceneManager.LoadScene("ObstacleCourse");
    }
    public void Zombies() {
        SceneManager.LoadScene("Zombie Attack Minigame");
    }
}
