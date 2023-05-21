using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    private CharacterSpawner spawner;

    public Transform spawnPoint;

    [SerializeField]
    private int listIndex;

    private void Awake()
    {
        spawner = CharacterSpawner.Instance;
    }

    public void AddToSpawnerList()
    {
        listIndex = spawner.AddSpawnPoint(spawnPoint);
    }

    public void BarracksDystroyed()
    {
        spawner.RemoveSpawnPoint(listIndex);
    }
}
