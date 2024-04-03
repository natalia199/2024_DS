using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallHandInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BallGrabbed()
    {
        // start Hand-Grab-Ball time
        // set ball's kinematic to FALSE
        // set ball's 'released' to FALSE
        this.GetComponent<BallObject>().released = false;

        // start recording ball hold time
        GameObject.Find("Manager").GetComponent<RecordData>().startBallHoldTime = true;
    }

    public void BallReleased()
    {
        // stop Hand-Grab-Ball time
        // set ball's 'released' to TRUE
        this.GetComponent<BallObject>().released = true;

        // stop recording ball hold time + inc ball release count
        GameObject.Find("Manager").GetComponent<RecordData>().startBallHoldTime = false;
        GameObject.Find("Manager").GetComponent<RecordData>().BallReleased();        
    }
}
