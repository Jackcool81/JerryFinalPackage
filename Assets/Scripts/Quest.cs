using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string QuestTitle;
    public string QuestDescription;
    public bool QuestCompletion;
    public Transform questLocation;

    public string questString;
    public string acceptString;
    public string rejectString;
    string[] questDialougeInfo = new string[3];

    //maybe reward the player when done?
    public void Complete()
    {
        isActive = false;
    }
    public string[] getQuestString(int questID) //questID will be either 0, 1, or 2 for now we will have 3 quests
    {
        //this is all the dialouge needed for quest 1
        Debug.Log(questID);
        if (questID == 0) 
        {
            questString = "can you find my cat?"; 
            acceptString = "Thank you";
            rejectString = "That's a pity";
            questDialougeInfo[0] = questString; //Quest description
            questDialougeInfo[1] = acceptString; //quest Accept string
            questDialougeInfo[2] = rejectString; //quest Decline string
            return questDialougeInfo;
        }
        else if (questID == 1)
        {
            questString = "Can you help me find my sword"; 
            acceptString = "Thank you for your help";
            rejectString = "See you next time then";
            questDialougeInfo[0] = questString; //Quest description
            questDialougeInfo[1] = acceptString; //quest Accept string
            questDialougeInfo[2] = rejectString; //quest Decline string
            return questDialougeInfo;
        }
        else
        {
            questString = "Can you kill those monsters over there?"; 
            acceptString = "Those monsters have been awfully annoying";
            rejectString = "Well I can't blame you";
            questDialougeInfo[0] = questString; //Quest description
            questDialougeInfo[1] = acceptString; //quest Accept string
            questDialougeInfo[2] = rejectString; //quest Decline string
            return questDialougeInfo;
        }

    }
}
