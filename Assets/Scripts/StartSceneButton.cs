using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartSceneButton : MonoBehaviour
{
    public GameObject userID;

    public Material available;
    public Material unavailable;

    public GameObject button;

    // Update is called once per frame
    void Update()
    {
        if (userID.GetComponent<GetID>().ID.Length == 2)
        {
            button.GetComponent<MeshRenderer>().material = available;
        }
        else
        {
            button.GetComponent<MeshRenderer>().material = unavailable;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StartBtn" && userID.GetComponent<GetID>().ID.Length == 2)
        {
            // Setting data
            GameObject.Find("SetUp").GetComponent<StudySetUp>().SetConditionOrder(int.Parse(userID.GetComponent<GetID>().ID));

            // next scene
            SceneManager.LoadScene("Transition");
        }
    }
}
