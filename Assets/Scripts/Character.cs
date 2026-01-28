using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField ] private Camera _camera;
    private Vector3 _savePosition = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FollowMouse()
    {
        transform.position = GetWorldMousePosition();

    }
    
    private Vector3 GetWorldMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = _camera.ScreenToWorldPoint(mousePos);
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            _savePosition = hit.point;
            return hit.point;
        }
        return _savePosition;
        


    }
    void Update()
    {
        FollowMouse();
    }
}
