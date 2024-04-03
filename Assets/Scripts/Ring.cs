using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public bool targetRing;

    public Material target;
    public Material notTarget;

    public GameObject ringModel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateRingStatus(bool x)
    {
        if (x)
        {
            // This goal = success
            this.transform.GetChild(0).tag = "InsideRing";

            // The edges = error
            this.transform.GetChild(1).tag = "TargetRing";
            this.transform.GetChild(2).tag = "TargetRing";
        }
        else
        {
            this.transform.GetChild(0).tag = "Ring";
            this.transform.GetChild(1).tag = "Ring";
            this.transform.GetChild(2).tag = "Ring";
        }
    }

    public void SetTargetMaterial()
    {
        ringModel.GetComponent<MeshRenderer>().material = target;
        ringModel.transform.GetChild(0).GetComponent<MeshRenderer>().material = target;
    }

    public void SetRegularMaterial()
    {
        ringModel.GetComponent<MeshRenderer>().material = notTarget;
        ringModel.transform.GetChild(0).GetComponent<MeshRenderer>().material = notTarget;
    }
}
