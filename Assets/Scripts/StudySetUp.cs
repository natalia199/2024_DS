using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudySetUp : MonoBehaviour
{
    public List<List<int>> ConditionOrder = new List<List<int>>();

    public int conditionTracker;
    public int ringSize;

    // true == recorded, false == practice
    public bool recordedTrials;

    public string userID;
    public int orderIndex;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        conditionTracker = 0;
        recordedTrials = false;
    }

    void Update()
    {
        
    }

    public void SetConditionOrder(int ID)
    {
        userID = "" + ID;
        orderIndex = ID % GameObject.Find("Conditions").GetComponent<ConditionSetUp>().OrderedConditions.Count;

        for (int i = 0; i < GameObject.Find("Conditions").GetComponent<ConditionSetUp>().conditionMax; i++)
        {
            ConditionOrder.Add(GameObject.Find("Conditions").GetComponent<ConditionSetUp>().OrderedConditions[orderIndex][i]);
        }

        /*
        for (int i = 0; i < ConditionOrder.Count; i++)
        {
            Debug.Log(i + " " + ConditionOrder[i][0] + ConditionOrder[i][1] + ConditionOrder[i][2]);
        }
        */
    }

    public void IncConditionTracker()
    {
        conditionTracker++;
    }
}
