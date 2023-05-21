using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectsDatabaseSO : ScriptableObject
{
    public List<objectData> objectsData;
}

[Serializable]
public class objectData
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public int ID { get; private set; }
     
    [field: SerializeField]
    public Vector2Int size { get; private set; } = Vector2Int.one;

    [field: SerializeField]
    public GameObject prefab { get; private set; }

    [field: SerializeField]
    public int coinPrice { get; private set; }

}