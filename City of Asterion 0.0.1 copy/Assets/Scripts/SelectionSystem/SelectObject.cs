using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    [SerializeField]
    public Camera mainCamera;

    [SerializeField]
    public InputSystem input;

    [SerializeField]
    BuildingManager manager;

    [SerializeField]
    public LayerMask mask;

    public ObjectInformation objectInfoUI;

    public GameObject selectedObject;

    public 
    void Start()
    {
       
        input.OnMouseClick += SelectStructure;
        input.OnExit += objectInfoUI.HideUI;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectStructure()
    {
        if (manager.buildingState != null)
            return;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, mask))
        {
            selectedObject = hit.transform.gameObject;
            objectInfoUI.ShowUI();
        }
    }

    public void DeleteStructure()
    {
        Destroy(selectedObject);
        objectInfoUI.HideUI();
    }


}
