using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestDialogue : MonoBehaviour
{
    public GameObject panel;
    public GameObject buttons;
    public PlayerMovement player;
    //Without reference variable
    public GameObject objectWithScript;
    public static int questID = 0;
    public string questString;
    public string acceptString;
    public string rejectString;

    public GameObject combatPrefab;

    public Text panelText;

    private bool isDone;

    private void Start()
    {
        panel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDone == false && questID < 3)
        {
            string[] questInfo = objectWithScript.GetComponent<QuestLog>().quests[questID].getQuestString(questID);
            panelText.text = questInfo[0];
            panel.SetActive(true);
            isDone = true;
            player.enabled = false;
        }
        else {
            panelText.text = "Thanks I got nothing let for you!";
            panel.SetActive(true);
            StartCoroutine(ExitQuest());
        }
    }

    public void AcceptQuest()
    {
        panelText.text = acceptString;
        buttons.SetActive(false);
        objectWithScript.GetComponent<QuestLog>().UpdateQuest(questID);
        string[] questInfo = objectWithScript.GetComponent<QuestLog>().quests[questID].getQuestString(questID);
        panelText.text = questInfo[1];
        GameObject newCombat = Instantiate(combatPrefab);
        Transform newCombat1 = objectWithScript .GetComponent<QuestLog>().quests[questID].questLocation;
        newCombat.transform.position = newCombat1.position;
        //objectWithScript.GetComponent<QuestLog>().UpdateQuest(questID);
        questID++;
        StartCoroutine(ExitQuest());
    }

    public void RejectQuest()
    {
        string[] questInfo = objectWithScript.GetComponent<QuestLog>().quests[questID].getQuestString(questID);
        panelText.text = questInfo[2];
        buttons.SetActive(false);
        StartCoroutine(ExitQuest());
    }

    private IEnumerator ExitQuest()
    {
        // Wait until left click is pressed
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        panel.SetActive(false);
        player.enabled = true;
    }
}
