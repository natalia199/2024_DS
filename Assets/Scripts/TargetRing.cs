using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRing : MonoBehaviour
{
    public List<GameObject> rings = new List<GameObject>();

    public int currentTargRing = 0;
    public int previousTargRing;
    public List<int> visitedRings = new List<int>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNewTargetRing()
    {
        bool ringFound = false;

        previousTargRing = currentTargRing;

        rings[previousTargRing].GetComponent<Ring>().SetRegularMaterial();
        rings[previousTargRing].GetComponent<Ring>().UpdateRingStatus(false);

        currentTargRing = Random.Range(0, 5);

        // Making sure not to repeat any target rings
        while (!ringFound && visitedRings.Count > 0)
        {
            currentTargRing = Random.Range(0, 5);

            for(int i = 0; i < visitedRings.Count; i++)
            {
                if(currentTargRing == visitedRings[i])
                {
                    break;
                }

                if (i == (visitedRings.Count - 1))
                {
                    ringFound = true;
                }
            }
        }

        visitedRings.Add(currentTargRing);

        rings[currentTargRing].GetComponent<Ring>().targetRing = true;
        rings[currentTargRing].GetComponent<Ring>().UpdateRingStatus(true);
        rings[currentTargRing].GetComponent<Ring>().SetTargetMaterial();
        
        // resetting the visited rings
        if (visitedRings.Count == 6)
        {
            visitedRings.Clear();
        }
    }
}
