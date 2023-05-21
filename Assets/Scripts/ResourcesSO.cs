using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ResourcesSO : ScriptableObject
{
    public List<ResourceDB> resources;
}

[Serializable]
public class ResourceDB
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public int ID { get; private set; }

    [field: SerializeField]
    public GameObject prefab { get; private set; }

}