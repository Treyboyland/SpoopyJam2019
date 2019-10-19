using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class BehaviourProabilityList : List<BehaviourAndProbability>
{
    bool maxFound;

    int maxProbability;

    public MonoBehaviour GetRandomObject()
    {
        if (!maxFound)
        {
            CalculateMax();
        }

        int target = UnityEngine.Random.Range(0, maxProbability);
        int selectedNum = 0;
        for (int i = 0; i < Count - 1; i++)
        {
            var powerup = this[i];
            var nextPowerup = this[i + 1];
            selectedNum += powerup.Probability;
            if (selectedNum <= target && selectedNum + nextPowerup.Probability >= target)
            {
                return this[i].Behaviour;
            }
        }

        return this[Count - 1].Behaviour;
    }

    void CalculateMax()
    {
        maxProbability = 0;
        maxFound = true;
        for (int i = 0; i < Count; i++)
        {
            maxProbability += this[i].Probability;
        }
    }

    public BehaviourProabilityList(List<BehaviourAndProbability> items) : base(items)
    {

    }
}