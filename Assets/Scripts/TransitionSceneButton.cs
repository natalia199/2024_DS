using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionSceneButton : MonoBehaviour
{    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "StartBtn")
        {
            // next scene
            SceneManager.LoadScene("Experience");
        }
        else if(other.tag == "TransitionBtn")
        {
            // next scene
            SceneManager.LoadScene("Transition");
        }
    }
}
