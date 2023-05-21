using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterCombat : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Animator animator;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (GetComponent<NavMeshAgent>().isStopped)
            {
                animator.SetBool("IsRunning", false);
            }
            else
            {
                animator.SetBool("IsRunning", true);
            }
        }
       
    }
    public void Attack()
    {

    }

    public void DealDamage()
    {

    }

    internal void StartCombat()
    {
        Debug.Log("Starting Combat");
        animator.SetBool("IsAttacking",true);
    }
}
