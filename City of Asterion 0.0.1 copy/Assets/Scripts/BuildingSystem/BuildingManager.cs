using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{

    [SerializeField]
    public BuildingDatabaseSO buildingDataBaseSO;

    [SerializeField]
    public InputSystem input;

    [SerializeField]
    public PreviewSystem previewSystem;

    [SerializeField]
    public ObjectPlacer objectPlacer;

    public IBuildingState buildingState;

    void Start()
    {
        StopPlacement();
    }

    void Update()
    {
        Vector3 mousePos = input.GetSelectedMapPosition();
        buildingState.UpdateState(mousePos);
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        buildingState = new PlacementState(ID,
                                          previewSystem,
                                          buildingDataBaseSO,
                                          objectPlacer);
        input.OnMouseClick += PlaceStructure;
        input.OnExit += StopPlacement;

    }

    public void StopPlacement()
    {
        if (buildingState == null)
            return;
        buildingState.EndState();
        input.OnMouseClick -= PlaceStructure;
        input.OnExit -= StopPlacement;
        buildingState = null;
    }


    public void PlaceStructure()
    {
        if (input.IsPointerOverUI())
            return;

        Vector3 mousePos = input.GetSelectedMapPosition();

        buildingState.OnAction(mousePos);

    }

}
