using UnityEngine;

public interface IBuildingState
{
    void EndState();
    void OnAction(Vector3 mousePosition);
    void UpdateState(Vector3 mousePosition);
}
