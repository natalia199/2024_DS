using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallObject : MonoBehaviour
{
    // If the ball is being held or not
    public bool released;
    public bool insideRing;

    public GameObject ballPrefab;

    void Start()
    {
        released = false;
        insideRing = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyBall()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ERROR
        if (other.tag == "TargetRing")
        {
            // data errors
            GameObject.Find("Manager").GetComponent<RecordData>().IncErrorRate();
            GameObject.Find("Manager").GetComponent<RecordData>().TouchedRing();
            // Stopping time-based user data
            GameObject.Find("Manager").GetComponent<RecordData>().startBallHoldTime = false;
            GameObject.Find("Manager").GetComponent<RecordData>().stopTrialTime = true;
            if (GameObject.Find("Manager").GetComponent<NewTrial>().totalTrials == GameObject.Find("Manager").GetComponent<NewTrial>().maxTrials)
            {
                GameObject.Find("Manager").GetComponent<RecordData>().stopConditionTime = true;
            }

            // Start new trial
            GameObject.Find("Manager").GetComponent<NewTrial>().SetNewTrial();

            DestroyBall();
        }

        // SUCCESS
        if (other.tag == "InsideRing")
        {
            insideRing = true;

            // Stopping time-based user data
            GameObject.Find("Manager").GetComponent<RecordData>().startBallHoldTime = false;
            GameObject.Find("Manager").GetComponent<RecordData>().stopTrialTime = true;
            if (GameObject.Find("Manager").GetComponent<NewTrial>().totalTrials == GameObject.Find("Manager").GetComponent<NewTrial>().maxTrials)
            {
                GameObject.Find("Manager").GetComponent<RecordData>().stopConditionTime = true;
            }

            // Start new trial
            GameObject.Find("Manager").GetComponent<NewTrial>().SetNewTrial();

            DestroyBall();
        }
        else
        {
            // left ring before releasing
            insideRing = false;
        }
    }
}
