using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    [SerializeField]
    private List<ResourceData> resourceList;

    [SerializeField]
    private TMP_Text goldUIText;

    private int itemIndex;
    private int cashedPrice = 0;

    public InputManager InputManager;

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
        goldUIText.text = resourceList[0].Amount.ToString();
    }

    private void Update()
    {
        goldUIText.text = resourceList[0].Amount.ToString();
    }
    public bool CanBuy(int price)
    {
        cashedPrice = 0;
        foreach (var resource in resourceList)
        {
            if (resource.Amount >= price)
            {
                cashedPrice = price;
                return true;
            }
        }
        cashedPrice= 0;
        return false;
    }

    public void BuyItem()
    {
        resourceList[itemIndex].BuyAction(cashedPrice);
        goldUIText.text = resourceList[itemIndex].Amount.ToString();
    }

    public void CollectResource(int amount)
    {
        resourceList[0].AddAmount(amount);
    }
}

[Serializable]
public class ResourceData
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public float Amount { get; private set; } = 0f;

    public void UpdateAmount(float amount)
    {
        Amount = amount;
    }

    public void AddAmount(float amount)
    {
        Amount += amount;
    }

    public void BuyAction(int price)
    {
        Amount -= price;
    }
}