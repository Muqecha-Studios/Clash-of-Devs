using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField]
    private int buildingHealth = 100;

    [SerializeField]
    private Transform normalBuilding;
    [SerializeField]
    private Transform brokenBuilding;

    [SerializeField]
    private int buildTime = 3;

    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private TMP_Text health;

    public BuildingType buildingType = BuildingType.None;

    

    private void Awake()
    {
        //canvas.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (TryGetComponent(out Barracks barracks))
        {
            barracks.AddToSpawnerList();
        }
    }


    internal void StartCombat()
    {
        throw new NotImplementedException();
    }

    public void StartConstruction()
    {
        brokenBuilding.gameObject.SetActive(true);
        normalBuilding.gameObject.SetActive(false);
        StartCoroutine(Construction());
    }

    private void StartBuildingFunction()
    {
        if (buildingType == BuildingType.Mine)
        {
            if (transform.gameObject.TryGetComponent<MineBuildingActions>(out MineBuildingActions component))
            {
                component.StartMining();
            }
        }
    }

    private IEnumerator Construction()
    {
        float timePassed = 0;
        while (timePassed < buildTime)
        {
            timePassed += Time.deltaTime;

            if (timePassed >= buildTime)
            {
                brokenBuilding.gameObject.SetActive(false);
                normalBuilding.gameObject.SetActive(true);
                StartBuildingFunction();
                //canvas.gameObject.SetActive(true);
            }

            yield return null;
        }
    }

    internal void StartReparing()
    {
        throw new NotImplementedException();
    }


    
}

[Serializable]
public enum BuildingType
{
    None,
    TownHall,
    Mine,
    Bank,
    Tower,
    Canon,
    Barracks
}