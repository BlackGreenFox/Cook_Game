using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    private Camera _sceneCamera;

    [SerializeField]
    private LayerMask _placementLayerMask;

    private Vector3 _lastPosition;



    public Vector3 GetSelectedMapPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _sceneCamera.nearClipPlane;
        Ray ray = _sceneCamera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit, 100, _placementLayerMask))
        {
            _lastPosition = hit.point;
        }

        return _lastPosition;
    }
}
