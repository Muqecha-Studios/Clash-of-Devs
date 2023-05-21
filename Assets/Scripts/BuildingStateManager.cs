using UnityEngine;

public class BuildingStateManager : MonoBehaviour
{
    [SerializeField]
    private BuildingManager buildingManager;

    [SerializeField]
    private BuildingStates state = BuildingStates.None;

    public void SetState(BuildingStates newState)
    {
        state = newState;
        
        switch (state)
        {
            case BuildingStates.None:
                break;
            case BuildingStates.UnderConstruction:
                buildingManager.StartConstruction();
                break;
            case BuildingStates.Idle:
                break;
            case BuildingStates.Combat:
                buildingManager.StartCombat();
                break;
            case BuildingStates.Reparing:
                buildingManager.StartReparing();
                break;
        }
    }
}
public enum BuildingStates
{
    None,
    UnderConstruction,
    Idle,
    Combat,
    Destroyed,
    Reparing
}