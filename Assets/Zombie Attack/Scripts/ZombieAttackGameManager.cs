using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieAttackGameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private int score = 0;

    public GameObject gameOverObject;

    // Start is called before the first frame update
    void Start()
    {
        IncreaseScore(0);
        gameOverObject.SetActive(false);
    }

    public void IncreaseScore(int value)
    {
        score += value;
        scoreText.text = $"Score: {score}";
    }

    public void GameOver()
    {
        gameOverObject.SetActive(true);
        Time.timeScale = 0;
    }
}
