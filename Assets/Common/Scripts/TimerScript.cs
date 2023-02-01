using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public int gameTimer = 120;
    private int currentTime = 0;
    private int increment = 1;
    public UnityEvent TimerFinished; 
    public TextMeshProUGUI timerText;

    public void StartTimer()
    {
        InvokeRepeating("RunTimer", 0, increment);
    }

    private void RunTimer()
    {
        int remaining = gameTimer - currentTime;
        timerText.text = $"{remaining/60}:{remaining%60:00}";
        currentTime += increment;
       if(currentTime >= gameTimer)
       {
           timerText.text = "0:00";
           TimerFinished?.Invoke();
           CancelInvoke();
       }

    }
}
