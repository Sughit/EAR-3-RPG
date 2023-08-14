using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questManager : MonoBehaviour
{
    public List<GameObject> questArray = new List<GameObject>();

    public void AddQuest(GameObject newQuest)
    {
        questArray.Add(newQuest);
        foreach (var quest in questArray)
        {
            quest.SetActive(true);
        }
    } 
}
