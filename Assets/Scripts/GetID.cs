using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetID : MonoBehaviour
{
    public string ID;
    public TextMeshProUGUI IDtxt;

    void Start()
    {
        ID = "";
    }

    void Update()
    {
        IDtxt.text = ID;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "IDKey")
        {
            if (ID.Length < 6)
            {
                ID = ID + other.transform.parent.name;
            }
        }
        else if(other.tag == "ClearKey")
        {
            ID = "";
        }
        else if(other.tag == "BackspaceKey")
        {
            if (ID.Length > 0)
            {
                ID.Remove(ID.Length - 1);
            }
        }
    }
}
