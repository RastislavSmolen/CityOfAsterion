using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]

public class BuildingDatabaseSO : ScriptableObject
{
    public List<ObjectData> objectData;
}

[Serializable]

public class ObjectData
{
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public int ID { get; private set; }

    [field: SerializeField]
    public GameObject Prefab { get; private set; }
}