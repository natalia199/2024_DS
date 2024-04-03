using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewTrial : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject RingManager;

    public int totalTrials;
    public int totalPracticeTrials;
    public int maxTrials;
    public int maxPracticeTrials;

    void Start()
    {
        totalTrials = 0;
        totalPracticeTrials = 0;

        // new ball
        Instantiate(ballPrefab, ballPrefab.transform.position, ballPrefab.transform.rotation);
        // new targetring
        RingManager.GetComponent<TargetRing>().SetNewTargetRing();
    }

    public void SetNewTrial()
    {
        if (GameObject.Find("SetUp").GetComponent<StudySetUp>().recordedTrials)
        {
            totalTrials++;

            // SAVING DATA
            /*GameObject.Find("Manager").GetComponent<RecordData>().Send(GameObject.Find("SetUp").GetComponent<StudySetUp>().userID, GameObject.Find("SetUp").GetComponent<StudySetUp>().orderIndex, totalTrials, 
             * GameObject.Find("SetUp").GetComponent<StudySetUp>().conditionTracker + 1, GameObject.Find("SetUp").GetComponent<StudySetUp>().ringSize,
                GameObject.Find("Manager").GetComponent<RecordData>().conditionTime, GameObject.Find("Manager").GetComponent<RecordData>().trialTime, GameObject.Find("Manager").GetComponent<RecordData>().ballInHandTime, 
                GameObject.Find("Manager").GetComponent<RecordData>().errorRate, GameObject.Find("Manager").GetComponent<RecordData>().ballReleaseCount, GameObject.Find("Manager").GetComponent<RecordData>().ringEdgeCount);
            */
            //GameObject.Find("Manager").GetComponent<RecordData>().ResetNewTrial();

            if (totalTrials <= maxTrials)
            {
                // new ball
                Instantiate(ballPrefab, ballPrefab.transform.position, ballPrefab.transform.rotation);
                // new targetring
                RingManager.GetComponent<TargetRing>().SetNewTargetRing();
            }
            else
            {
                RecordedConditionFinished();
            }
        }
        else
        {
            totalPracticeTrials++;

            if (totalPracticeTrials <= maxPracticeTrials)
            {
                // new ball
                Instantiate(ballPrefab, ballPrefab.transform.position, ballPrefab.transform.rotation);
                // new targetring
                RingManager.GetComponent<TargetRing>().SetNewTargetRing();
            }
            else
            {
                PracticeConditionFinished();
            }
        }
    }

    public void ErrorCount()
    {
        // inc error
    }

    public void RecordedConditionFinished()
    {
        GameObject.Find("SetUp").GetComponent<StudySetUp>().recordedTrials = false;

        if (GameObject.Find("SetUp").GetComponent<StudySetUp>().conditionTracker < GameObject.Find("SetUp").GetComponent<StudySetUp>().ConditionOrder.Count) 
        {
            GameObject.Find("SetUp").GetComponent<StudySetUp>().IncConditionTracker();

            SceneManager.LoadScene("Survey");
        }
        else
        {
            SceneManager.LoadScene("End");
        }
    }

    public void PracticeConditionFinished()
    {
        GameObject.Find("SetUp").GetComponent<StudySetUp>().recordedTrials = true;

        // go to survery and present new condition
        SceneManager.LoadScene("Transition");
    }
}
