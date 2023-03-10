using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class QuestLog : MonoBehaviour
{
    public Quest[] quests;
    public TextMeshProUGUI textDisplay; //A refrence to our text display aka where we are going to put the description
    public GameObject text; //Hold our text game object
    public GameObject panel;
    public Transform QuestWindow;
    public Button recallButtonObject;

    public void UpdateQuest(int i)
    {
         quests[i].isActive = true;
         Button btn = Instantiate(recallButtonObject, QuestWindow);
         btn.GetComponentInChildren<Text>().text = quests[i].QuestTitle;
         btn.onClick.AddListener(description);
    }
    public void description() //When called, will display whatever text we want to the description
    {
        text.SetActive(true); //Checks the text on
        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        foreach (Quest i in quests)
        {
            if (i.QuestTitle == EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text)
            {
                text.GetComponentInChildren<TextMeshProUGUI>().text = i.QuestDescription;
                break;
            }
            
        }
        //textDisplay.gameObject.SetActive(true);
        
    }
}
