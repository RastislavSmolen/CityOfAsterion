using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class PreviewSystem : MonoBehaviour
{

    [SerializeField]
    private float newPreviewYOffset = 0.06f;

    [SerializeField]
    public GameObject previewObject;

    [SerializeField]
    private Material previewMaterialPrefab;
    private Material previewMaterialInstance;


    public Vector3 targetPosition;
    public float snapDistance = 1;
    public List<Transform> nodes = new List<Transform>();
    private Vector3 storedPosition;

    void Start()
    {
        previewMaterialInstance = new Material(previewMaterialPrefab);
    }
   
    public void StartShowingPlacementPreview(GameObject prefab)
    {
       
        previewObject = Instantiate(prefab);
        previewObject.GetComponentInChildren<Structure>().occupied = false;
        PreparePreview(previewObject);
    }


    private void PreparePreview(GameObject previewObject)
    {
        Renderer[] renderers = previewObject.GetComponentsInChildren<Renderer>();
        foreach (var renderer in renderers)
        {
            Material[] materials = renderer.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = previewMaterialInstance;
            }
            renderer.materials = materials;
        }
    }

    public void StopShowingPreview()
    {
        if (previewObject != null)
            Destroy(previewObject);
    }

    public void UpdatePosition(Vector3 position, bool isOccupied)
    {
        if (previewObject != null)
        {
            MovePreview(position);
            ApplyFeedbackToPreview(isOccupied);
        }
    }

    private void ApplyFeedbackToPreview(bool isOccupied)
    {
        Color color = isOccupied ? Color.red : Color.white;
        color.a = 0.5f;
        previewMaterialInstance.color = color;
    }

    private void MovePreview(Vector3 position)
    {
        storedPosition = position;

        float smallestDistanceSquared = snapDistance * snapDistance;

        if ((position - targetPosition).sqrMagnitude < smallestDistanceSquared)
        {

            transform.position = targetPosition;
            foreach (Transform node in nodes)
            {
                targetPosition = node.position;
                previewObject.transform.position = node.position;
                smallestDistanceSquared = (node.position - targetPosition).sqrMagnitude;

            }
            return;
        }

        previewObject.transform.position = new Vector3(
        storedPosition.x,
        storedPosition.y + newPreviewYOffset,
        storedPosition.z);

    }

    public Vector3 PlaceAtSnapping()
    {
        float smallestDistanceSquared = snapDistance * snapDistance;

        if ((storedPosition - targetPosition).sqrMagnitude < smallestDistanceSquared)
        {

            storedPosition = targetPosition;
            foreach (Transform node in nodes)
            {

                storedPosition = node.position;
                smallestDistanceSquared = (node.position - targetPosition).sqrMagnitude;

            }
            return storedPosition;
        }

       storedPosition = new Vector3(
        storedPosition.x,
        storedPosition.y + newPreviewYOffset,
        storedPosition.z);
        return storedPosition;
    }


  
    void Update()
    {
       
    }
    //internal void StartShowingRemovePreview()
    //{
    //    ApplyFeedbackToCursor(false);
    //}
}
