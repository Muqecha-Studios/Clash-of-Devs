using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface navMesh;

    private void Awake()
    {
        navMesh = GetComponent<NavMeshSurface>();
    }

    public void RefreshNavMesh()
    {
        Debug.Log("refreshing navmesh");
        navMesh.BuildNavMesh();
    }
}
