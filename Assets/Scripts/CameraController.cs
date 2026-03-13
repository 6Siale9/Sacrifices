using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private LayerMask _antLayerMask;
    [SerializeField] private Texture2D _grabCursor;
    [SerializeField] private Texture2D _defaultCursor;
    private CinemachineVirtualCamera _currentCamera = null;
    private float _moveSpeed = 300f;
    private float _zoomSpeed = 10f;
    private float _minZoom = 0.4f;
    private float _maxZoom = 2.5f;
    private float _scroll = 0f;


    // Start is called before the first frame update
    void Start()
    {
        _currentCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Zoom();
        Click();
    }
     void Movement()
    {
        float horizontal = 0f;
        float vertical = 0f;
        //_moveSpeed*= _scroll+5;
        if (Input.GetKey(KeyCode.Mouse2))
        {
            UnityEngine.Cursor.SetCursor(_grabCursor, Vector3.zero, CursorMode.ForceSoftware);
            vertical -= Input.GetAxis("Mouse Y") * _moveSpeed * Time.deltaTime;
            horizontal -= Input.GetAxis("Mouse X") * _moveSpeed * Time.deltaTime;
        }
        else
        {
            UnityEngine.Cursor.SetCursor(_defaultCursor, Vector3.zero, CursorMode.ForceSoftware);
        }
        if (Input.GetKey(KeyCode.W))
            vertical += 1f;
        if (Input.GetKey(KeyCode.S))
            vertical -= 1f;
        if (Input.GetKey(KeyCode.A))
            horizontal -= 1f;
        if (Input.GetKey(KeyCode.D))
            horizontal += 1f;

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        Vector3 _newposition = transform.position + direction * _moveSpeed * _scroll*Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, _newposition, 0.1f);
        
    }
    void Zoom()
    {
        
        _scroll -= Input.GetAxis("Mouse ScrollWheel");
        _scroll = Mathf.Clamp(_scroll, _minZoom, _maxZoom);
        //Vector3 zoomDirection = transform.forward * _scroll * _zoomSpeed;
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, _scroll*_zoomSpeed, transform.position.z), 0.1f);
            //transform.Translate(zoomDirection, Space.World);
    }


    
    void Click()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction.normalized * 100f, Color.red, 1f);
            bool isHit = Physics.Raycast(ray.origin, ray.direction.normalized, out hit, 100, _antLayerMask);
            if (isHit)
            {
                Debug.Log("Clicked on: " + hit.collider.name);
                if (hit.collider.CompareTag("AllyAnt"))
                {
                    Ant ant = hit.collider.GetComponent<Ant>();
                    if (ant.Selected == true)
                    {
                        ant.Selected = false;
                        Debug.Log("Unclicked");
                    }
                    else
                    {
                        ant.Selected = true;
                        Debug.Log("Clicked");
                    }
                }
                
            }
        }
    }


}
