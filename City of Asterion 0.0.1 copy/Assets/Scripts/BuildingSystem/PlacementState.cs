using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlacementState : IBuildingState
{
    private int selectedObjectIndex = -1;
    int ID;
    PreviewSystem previewSystem;
    BuildingDatabaseSO database;
    ObjectPlacer objectPlacer;
    private GameObject gameObject;

    public PlacementState(int iD,
                          PreviewSystem previewSystem,
                          BuildingDatabaseSO database,
                          ObjectPlacer objectPlacer)
    {
        ID = iD;
        this.previewSystem = previewSystem;
        this.database = database;
        this.objectPlacer = objectPlacer;

        selectedObjectIndex = database.objectData.FindIndex(data => data.ID == ID);
        if (selectedObjectIndex > -1)
        {
            gameObject = database.objectData[selectedObjectIndex].Prefab;
            previewSystem.StartShowingPlacementPreview(gameObject);
        }
        else
            throw new System.Exception($"No object with ID {iD}");

    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3 mousePosition)
    {

        bool isOccupied = IsOccupied();
        if (isOccupied)
        {
            return;
        }
        objectPlacer.PlaceObject(database.objectData[selectedObjectIndex].Prefab, previewSystem.PlaceAtSnapping());

        previewSystem.UpdatePosition(mousePosition, false);
    }


    private bool IsOccupied()
    {
        bool isOccupied = previewSystem.previewObject.GetComponentInChildren<Structure>().occupied;

        return isOccupied;
    }

    public void UpdateState(Vector3 mousePosition)
    {
        bool isOccupied = IsOccupied();

        previewSystem.UpdatePosition(mousePosition, isOccupied);
    }
}