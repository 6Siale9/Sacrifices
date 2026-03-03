using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ant : MonoBehaviour
{
    #region Attributs
    [SerializeField ] private Camera _camera;
    private Vector3 _savePosition = Vector3.zero;
    [SerializeField] private float _size = 0;
    [SerializeField] private Collider _collider = null;
    [SerializeField] private float _id = 0;
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] private Canvas _canva = null;
    // Start is called before the first frame update
    #endregion Attributs

    #region Accessors
    public float Size { get => _size; set => _size = value; }
    public float Id { get => _id; set => _id = value; }
    #endregion Acceessors

    void Start()
    {
        DefineARandomID();
    }

    void Update()
    {
        //FollowMouse();
        UpdateText();
    }

    #region Move
    /*
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
    */
    #endregion Move

    private void DefineARandomID()
    {
        _id = Random.Range(0f, 50f);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject entering = other.gameObject;
        if (entering.CompareTag("AllyAnt"))
        {
            Ant enteringScript = entering.GetComponent<Ant>();
            if (_size > enteringScript.Size)
            {
                _size += enteringScript.Size;
                Destroy(entering);
            }
            else if (_size == enteringScript.Size)
            {
                if (_id > enteringScript.Id)
                {
                    _size += enteringScript.Size;
                    Destroy(entering);
                }
            }
        }
        else if (entering.CompareTag("Enemy"))
        {
            Enemy enteringScript = entering.GetComponent<Enemy>();
            if (enteringScript.Hp > _size)
            {
                enteringScript.Hp -= _size;
                Destroy(gameObject);
            }
            else if (enteringScript.Hp < _size)
            {
                _size -= enteringScript.Hp;
                Destroy(entering);
            }
            else if (enteringScript.Hp == _size)
            {
                Destroy(entering);
                Destroy(gameObject);
            }
        }
    }

    private void UpdateText()
    {
        Quaternion a = new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
        _canva.transform.rotation = a;
        
        
        _text.text = _size.ToString();
    }
}
