using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineBuildingActions : MonoBehaviour
{
    [SerializeField]
    private ResourceManager resourceManager;

    [SerializeField]
    private bool isMining = false;

    [SerializeField]
    private float coinMiningTime = 4f;
    [SerializeField]
    private int coinMinedPerCycle = 10;

    private float timePassed = 0;

    private void Awake()
    {
        resourceManager = ResourceManager.Instance;
    }

    private void Update()
    {
        if (isMining)
        {
            Debug.Log(timePassed);
            
            timePassed += Time.deltaTime;

            if (timePassed >= coinMiningTime)
            {
                resourceManager.CollectResource(coinMinedPerCycle);
                timePassed = 0;
            }
            
        }
    }

    internal void StartMining()
    {
        Debug.Log("Mining Has Started");
        isMining= true;
    }

    private void Mine()
    {
        
    }


}
