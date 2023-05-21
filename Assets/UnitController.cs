using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    public NavMeshAgent agent;

    private void Start()
    {
        inputManager = InputManager.Instance;
        inputManager = ResourceManager.Instance.InputManager;
        inputManager.OnMove += MoveCharacter;
    }

    private void MoveCharacter()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
    }
}
