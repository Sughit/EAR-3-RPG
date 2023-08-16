using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questManager : MonoBehaviour
{
    public List<GameObject> questArray = new List<GameObject>();
    public Transform questWindow;

    public void AddQuest(GameObject newQuest)
    {
        questArray.Add(newQuest);
        Instantiate(newQuest, questWindow);
        // foreach (var quest in questArray)
        // {
        //     quest.SetActive(true);
        // }
    } 

    public void RemoveQuest(GameObject newQuest, string newQuestLoc)
    {
        questArray.Remove(newQuest);
        GameObject.Find(newQuestLoc).SetActive(false);
        
    }
}
