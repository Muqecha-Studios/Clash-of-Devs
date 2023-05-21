using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterdatabaseSO : ScriptableObject
{
    [SerializeField]
    public List<CharacterData> characterData;
}

[Serializable]
public class CharacterData
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public int ID { get; private set; }

    [field: SerializeField]
    public GameObject Prefab { get; private set; }

    [field: SerializeField]
    public int coinCost { get; private set; }

}
