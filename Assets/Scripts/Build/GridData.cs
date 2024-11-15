using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData 
{
    Dictionary<Vector3Int, PlacementData> placedObjects = new Dictionary<Vector3Int, PlacementData>();


    public void AddObjectAt(Vector3Int gridPosition, Vector2Int objectSize, int objectID, int placeObjectIndex)
    {
        List<Vector3Int> positionToOccypy = Calculating(gridPosition, objectSize);
        PlacementData data = new PlacementData(positionToOccypy, objectID, placeObjectIndex);

        foreach (var pos in positionToOccypy)
        {
            if (placedObjects.ContainsKey(pos))
                throw new Exception($"Dictionary already contains this cell {pos}");
            placedObjects[pos] = data;
        }
    }

    private List<Vector3Int> Calculating(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> returnVal = new List<Vector3Int>();
        for (int x = 0; x < objectSize.x; x++)
        {
            for (int y = 0; y < objectSize.y; y++)
            {
                returnVal.Add(gridPosition + new Vector3Int(x,0,y));   

            }
        }
        return returnVal;
    }

    public bool CanPlaceObjectAt(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> positionToOccypy = Calculating(gridPosition, objectSize);
        foreach (var pos in positionToOccypy)
        {
            if (placedObjects.ContainsKey(pos))
                return false;
        }
        return true;

    }
}

public class PlacementData
{
    public List<Vector3Int> occupiePositions;
    public int ID { get; private set; }
    public int PlaceObjectIndex { get; private set; }



    public PlacementData(List<Vector3Int> occupiePositions, int iD, int placeObjectIndex)
    {
        this.occupiePositions = occupiePositions;
        ID = iD;
        PlaceObjectIndex = placeObjectIndex;
    }
}
