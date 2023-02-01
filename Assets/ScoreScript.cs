using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreScript : MonoBehaviour
{
    public int money = 0;
    public GameObject Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.Find("Text Money");
    }

    // Update is called once per frame
    void Update()
    {
        Score.GetComponent<TextMeshProUGUI>().text = "$" + money.ToString();
    }
}
