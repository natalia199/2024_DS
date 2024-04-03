using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionSetUp : MonoBehaviour
{
    public int conditionMax;
    public List<string> inputDevice = new List<string>();
    public List<string> handVisual = new List<string>();
    public List<string> controllerVisual = new List<string>();

    // Original condition order
    public List<List<int>> conditions = new List<List<int>>();
    List<int> tempConditions = new List<int>();
    
    // All variations of condition order
    List<List<int>> tempOrderCond = new List<List<int>>();
    public List<List<List<int>>> OrderedConditions = new List<List<List<int>>>();
    

    void Start()
    {
        settingConditions();
    }

    void settingConditions()
    {        
        // input dev
        for (int i = 0; i < inputDevice.Count; i++)
        {
            // hand
            for (int j = 0; j < handVisual.Count; j++)
            {
                // controller
                for (int k = 0; k < controllerVisual.Count; k++)
                {
                    tempConditions.Add(i);
                    tempConditions.Add(j);
                    tempConditions.Add(k);

                    conditions.Add(tempConditions);

                    tempConditions = new List<int>();
                }
            }
        }

        conditionMax = conditions.Count;

        CounterBalanceOrder();
    }

    void CounterBalanceOrder()
    {
        //OrderedConditions
        // Holds all 8 different orders of the conditions
        // e.g., OrderedConditions[0] = [HT, H on, C on], ... [HH, H off, C off], OrderedConditions[1] = [HT, H on, C off], ... [HT, H on, C on], OrderedConditions[2] = [HT, H off, C on], ... [HT, H on, C off], etc.

        for (int w = 0; w < conditionMax; w++)
        {
            for (int i = 0; i < conditions.Count; i++)
            {
                tempOrderCond.Add(conditions[i]);
            }

            // Adding previous conditions to the end
            for(int o = 0; o < w; o++)
            {
                tempOrderCond.Add(conditions[o]);
            }
            // Removing the front conditions that were just added to the end
            for(int q =0; q < w; q++)
            {
                tempOrderCond.RemoveAt(0);
            }

            OrderedConditions.Add(tempOrderCond);

            tempOrderCond = new List<List<int>>();
        }
    }
}
