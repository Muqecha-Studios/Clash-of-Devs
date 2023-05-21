using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PriceListSO : ScriptableObject
{
    [SerializeField]
    public List<PriceData> BuildingPrices;
    public List<PriceData> CharacterPrices;
}

[Serializable]
public class PriceData
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public int ID { get; private set; }

    [field: SerializeField]
    public ObjectsDatabaseSO DatabaseInstance { get; private set; }

    [field: SerializeField]
    public int DatabaseID { get; private set; }

}