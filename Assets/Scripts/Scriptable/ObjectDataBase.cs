using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class ObjectDataBase : ScriptableObject
{
    public List<ObjectData> objectsData;
}

[Serializable]
public class ObjectData
{
    [field: SerializeField]
    public int ID {  get; private set; }

    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField]
    public Vector2Int Size { get; private set; } = Vector2Int.zero;

    [field: SerializeField]
    public GameObject Prefab { get; private set; }

}