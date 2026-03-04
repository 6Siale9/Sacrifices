using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _moveSpeed = 40f;
    private float _zoomSpeed = 10f;
    private float _minZoom = 0.4f;
    private float _maxZoom = 2.5f;
    private float _scroll = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Zoom();
    }
     void Movement()
    {
        float horizontal = 0f;
        float vertical = 0f;
        //_moveSpeed*= _scroll+5;
        if (Input.GetKey(KeyCode.Mouse1))
        {
            vertical -= Input.GetAxis("Mouse Y") * _moveSpeed * Time.deltaTime;
            horizontal -= Input.GetAxis("Mouse X") * _moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Z))
            vertical += 1f;
        if (Input.GetKey(KeyCode.S))
            vertical -= 1f;
        if (Input.GetKey(KeyCode.D))
            horizontal -= 1f;
        if (Input.GetKey(KeyCode.Q))
            horizontal += 1f;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        transform.Translate(direction * _moveSpeed * _scroll * Time.deltaTime, Space.World);
    }
    void Zoom()
    {
        
        _scroll -= Input.GetAxis("Mouse ScrollWheel");
        _scroll = Mathf.Clamp(_scroll, _minZoom, _maxZoom);
        //Vector3 zoomDirection = transform.forward * _scroll * _zoomSpeed;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _scroll*_zoomSpeed, transform.position.z), 0.1f);
            //transform.Translate(zoomDirection, Space.World);
    }
}
