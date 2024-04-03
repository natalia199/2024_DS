using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TransitionDisplay : MonoBehaviour
{
    public TextMeshProUGUI text;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Transition")
        {
            if (GameObject.Find("SetUp").GetComponent<StudySetUp>().recordedTrials)
            {
                DisplayRecorded();
            }
            else
            {
                DisplayPractice();
            }
        }
        else if (SceneManager.GetActiveScene().name == "Survey")
        {
            DisplaySurvey();
        }
    }

    void DisplayPractice()
    {
        text.text = "The Practice Trials will begin after pressing the Start button. Your progress will not be recorded!";
    }

    void DisplayRecorded()
    {
        text.text = "The Recorded Trials will begin after pressing the Start button. Your progress will be recorded!";
    }

    void DisplaySurvey()
    {
        text.text = GameObject.Find("SetUp").GetComponent<StudySetUp>().conditionTracker + "/" + GameObject.Find("SetUp").GetComponent<StudySetUp>().ConditionOrder.Count + " <b>Conditions completed!</b><br><br>Please remove the headset and fill out the online Survey. Once done, press the button below to continue.";
    }
}
