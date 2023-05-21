using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private Grid grid;

    [SerializeField]
    private ObjectsDatabaseSO database;


    [SerializeField]
    private GameObject gridVisualization;

    private GridData floorData, furnitureData;

    [SerializeField]
    private PreviewSystem preview;

    private Vector3Int lastDetectedPosition = Vector3Int.zero;

    [SerializeField]
    private ObjectPlacer objectPlacer;

    IBuildingState buildingState;

    [SerializeField]
    private ResourceManager resourceManager;

    private void Start()
    {
        StopPlacement();
        floorData= new GridData();
        furnitureData= new GridData();
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();

        if (!CheckIfBuy(ID))
        {
            StopPlacement();
            Debug.Log($"you don't have enough coin to buy {database.objectsData[database.objectsData.FindIndex(data => data.ID == ID)].Name} which has a price of {database.objectsData[database.objectsData.FindIndex(data => data.ID == ID)].coinPrice}");
            return;
        }

        gridVisualization.SetActive(true);

        buildingState = new PlacementState(ID, grid, preview, database, floorData, furnitureData, objectPlacer);

        inputManager.onClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    private bool CheckIfBuy(int ID)
    {
        int selectedObjectIndex = database.objectsData.FindIndex(data => data.ID == ID);
        string itemName = database.objectsData[selectedObjectIndex].Name;
        Debug.Log($"Item being Bought is {itemName}");
        int price = database.objectsData[selectedObjectIndex].coinPrice;
        return resourceManager.CanBuy(price);
    }

    private void PlaceStructure()
    {
        if (inputManager.IsPointerOverUI())
            return;

        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

       buildingState.OnAction(gridPosition);
        resourceManager.BuyItem();
    }

    //private bool CheckPlacementValidity(Vector3Int gridPosition, int selectedObjectIndex)
    //{
    //    GridData selectedData = database.objectsData[selectedObjectIndex].ID == 0 ? floorData : furnitureData;

    //    return selectedData.CanPlaceObjectAt(gridPosition, database.objectsData[selectedObjectIndex].size);
    //}

    private void StopPlacement()
    {
        if (buildingState == null)
            return;

        gridVisualization.SetActive(false);
        buildingState.EndState();
        inputManager.onClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
        lastDetectedPosition = Vector3Int.zero;
        buildingState = null;
    }

    private void Update()
    {
        if (buildingState == null)
            return;
        
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        if(lastDetectedPosition != gridPosition)
        {
            buildingState.UpdateState(gridPosition);
            lastDetectedPosition = gridPosition;
        }

        
    }

}
