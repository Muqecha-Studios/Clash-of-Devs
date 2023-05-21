using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public RectTransform CharacterSelectionPanel;

    [SerializeField]
    private InputManager inputManager;

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

        CharacterSelectionPanel.gameObject.SetActive(false);
    }
    private void Start()
    {
        inputManager = InputManager.Instance;
        inputManager.OnSelect += OpenBuildingUI;
    }
    public void OpenBuildingUI()
    {
        CharacterSelectionPanel.gameObject.SetActive(true);
       
    }

    public void CloseBuildingUI()
    {
        CharacterSelectionPanel.gameObject.SetActive(false);

    }
}
