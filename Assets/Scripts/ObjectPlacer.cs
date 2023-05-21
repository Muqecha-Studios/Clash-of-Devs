using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> placedGameObjects = new();

    [SerializeField]
    private LayerMask layer;

    public int PlaceObject(GameObject prefab, Vector3 position)
    {
        GameObject newObj = Instantiate(prefab);
        newObj.transform.position = position;
        placedGameObjects.Add(newObj);

        newObj.transform.GetComponent<NavMeshObstacle>().enabled = true;

        BuildingStateManager stateManager= newObj.GetComponent<BuildingStateManager>();
        stateManager.SetState(BuildingStates.UnderConstruction);

        return placedGameObjects.Count - 1;
    }
}
