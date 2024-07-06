using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject _mouseIndicator;
    [SerializeField]
    private InputManager _inputManager;


    private void Update()
    {
        Vector3 mousePosition = _inputManager.GetSelectedMapPosition();
        _mouseIndicator.transform.position = mousePosition;
    }
}
