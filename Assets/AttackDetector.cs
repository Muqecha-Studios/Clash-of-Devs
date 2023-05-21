using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetector : MonoBehaviour
{
    [SerializeField]
    private CharacterCombat combatManager;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Attaching {collision.gameObject.name}");
        combatManager.StartCombat();
    }
}
