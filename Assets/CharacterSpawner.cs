using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterSpawner : MonoBehaviour
{
    public static CharacterSpawner Instance { get; private set; }

    [SerializeField]
    private List<Transform> barracksSpawnPoints = new List<Transform>();

    [SerializeField]
    private CharacterdatabaseSO characterDB;

    private int currentSpawnIndex = 0;

    [SerializeField]
    private Transform collectiveSpawnPoint;
    [SerializeField]
    private Transform collectiveTravelPoint;

    [SerializeField]
    private ResourceManager resourceManager;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    private void Start()
    {
        resourceManager = ResourceManager.Instance;
    }

    public int AddSpawnPoint(Transform point)
    {
        barracksSpawnPoints.Add(point);
        return barracksSpawnPoints.Count - 1;
    }

    public void RemoveSpawnPoint(int index) 
    {
        barracksSpawnPoints.RemoveAt(index);
    }

    public void StartSpawning(int characterIndex)
    {
        if (!resourceManager.CanBuy(characterDB.characterData[characterIndex].coinCost))
        {
            Debug.Log("Insufficient Funds");
            return;
        }    
        SpawnCharacter(characterDB.characterData[characterIndex].Prefab, collectiveSpawnPoint);
        resourceManager.BuyItem();
        if (currentSpawnIndex > barracksSpawnPoints.Count)
            currentSpawnIndex++;
    }

    public void SpawnCharacter(GameObject prefab, Transform spawnPoint)
    {
        GameObject newCharacter = Instantiate(prefab, spawnPoint.transform);
        newCharacter.GetComponent<NavMeshAgent>().SetDestination(collectiveTravelPoint.position);
    }


}
