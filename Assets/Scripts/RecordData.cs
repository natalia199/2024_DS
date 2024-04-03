using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RecordData : MonoBehaviour
{
    // Condition's variables
    public int trialID;
    public int ballinRingCount;                              // Amount of times ball entered the ring in the trial
    public float timeBallinRing;                             // How long the ball's been inside the ring prior to being released
    public int ballReleaseCount;

    public int errorRate;                                    // Number of times the ball touched the ring's edge in the condition
    public int ringEdgeCount;                                    // Number of times the ball touched the ring's edge in the condition
    public float conditionTime;
    public float trialTime;
    public float ballInHandTime;

    public bool startBallHoldTime;
    public bool stopTrialTime;
    public bool stopConditionTime;

    // Google Forms URL for data
    string URL = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfMKaCNSTSw3VXlNFTHajQ7twcxtLoSvjZYgf-wUWPXUBoUkQ/formResponse";


    // Convert data into String vairables
    public void Send(string id, int order, int tID, int cID, int rings, float ctime, float ttime, float btime, int error, int ballrelease, int ringedge)
    {
        string ctime_data = "" + ctime;
        string ttime_data = "" + ttime;
        string btime_data = "" + btime;

        StartCoroutine(Post(id, order, cID, tID, rings, ctime_data, ttime_data, btime_data, error, ballrelease, ringedge));
    }

    // Send data to the Google Form
    IEnumerator Post(string id, int order_data, int condition_data, int trial_data, int ringSize_data, string condTime_data, string trialTime_data, string ballinhandTime_data, int error_data, int ballReleaseCount_data, int ringedge_data)
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.576949183", id);                               // ID
        form.AddField("entry.431976176", order_data);                       // order
        form.AddField("entry.1273131174", condition_data);                   // Condition
        form.AddField("entry.1092043313", trial_data);                      // Trial
        form.AddField("entry.195361419", ringSize_data);                  // Set targets
        form.AddField("entry.675253732", condTime_data);                       // Time
        form.AddField("entry.2121096732", trialTime_data);                       // Time
        form.AddField("entry.483126295", ballinhandTime_data);                       // Time
        form.AddField("entry.1557410765", error_data);                        // Error rate
        form.AddField("entry.1944872007", ballReleaseCount_data);               // Cursor on target count
        form.AddField("entry.1755411749", ringedge_data);               // Cursor on target count

        UnityWebRequest www = UnityWebRequest.Post(URL, form);

        yield return www.SendWebRequest();

        Debug.Log("submitted");
    }

    void Awake()
    {
        newScene();                                                 // Reset variables for new trial order
    }

    public void newScene()
    {
        // ids
        trialID = 1;

        // counts
        ballReleaseCount = 0;
        errorRate = 0;
        ringEdgeCount = 0;

        // times
        conditionTime = 0;
        trialTime = 0;
        ballInHandTime = 0;
        startBallHoldTime = false;
        stopTrialTime = false;
        stopConditionTime = false;
    }

    public void Update()
    {
        if (GameObject.Find("SetUp").GetComponent<StudySetUp>().recordedTrials)
        {
            // record condition time (seconds)
            // doesn't stop until LAST TRIAL is completed
            if (!stopConditionTime)
            {
                conditionTime += Time.deltaTime;
            }

            // record trial time
            // renewed every trial completion
            if (!stopTrialTime)
            {
                trialTime += Time.deltaTime * 1000;
            }

            // record time from ball grasp to release (miliseconds)
            // renewed every trial completion
            if (startBallHoldTime)
            {
                ballInHandTime += Time.deltaTime * 1000;
            }

            // error rate
            // incremented on Ball script when ball touches ring
            // incremeted on BallHandInteraction script when ball is released

            // ball release count
            // incremeted on BallHandInteraction script when ball is released
        }
    }

    public void ResetNewTrial()
    {
        // ids
        trialID++;

        // counts
        ballReleaseCount = 0;
        errorRate = 0;
        ringEdgeCount = 0;

        // times
        trialTime = 0;
        ballInHandTime = 0;
        startBallHoldTime = false;
        stopTrialTime = false;
    }

    public void IncErrorRate()
    {
        errorRate++;
    }
    
    public void BallReleased()
    {
        ballReleaseCount++;
    }
    
    public void TouchedRing()
    {
        ringEdgeCount++;
    }

}
