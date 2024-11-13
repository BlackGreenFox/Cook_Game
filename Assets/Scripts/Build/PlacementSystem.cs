using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _mouseIndicator, _cellIndicator;
    [SerializeField]
    private InputManager _inputManager;
    [SerializeField]
    private Grid _grid;

    [SerializeField]
    private ObjectDataBase _database;
    private int _selectedObjectIndex = -1;

    [SerializeField]
    private GameObject _gridVisualization;

    private void Start()
    {
        StopPlacement();
    }

    public void StartPlacement(int ID)
    {
        StopPlacement();
        _selectedObjectIndex = _database.objectsData.FindIndex(data => data.ID == ID);
        if (_selectedObjectIndex < 0) 
        {
            Debug.LogError($"No ID Found {ID}");
            return;
        }

        _gridVisualization.SetActive(true);
        _cellIndicator.SetActive(true);
        _inputManager.OnClicked += PlaceStructure;
        _inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if (_inputManager.IsPointerOverUI())
            return;

        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(mousePosition);
        GameObject newObject = Instantiate(_database.objectsData[_selectedObjectIndex].Prefab);
        newObject.transform.position = _grid.CellToWorld(gridPosition);

    }

    private void StopPlacement()
    {
        _selectedObjectIndex = -1;
        _gridVisualization.SetActive(false);
        _cellIndicator.SetActive(false);
        _inputManager.OnClicked -= PlaceStructure;
        _inputManager.OnExit -= StopPlacement;
    }

    private void Update()
    {
        if (_selectedObjectIndex < 0)
            return;
  
        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = _grid.WorldToCell(mousePosition);
        _mouseIndicator.transform.position = mousePosition;
        _cellIndicator.transform.position = _grid.CellToWorld(gridPosition);
    }
}
