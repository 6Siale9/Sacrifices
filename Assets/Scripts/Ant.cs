using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ant : MonoBehaviour
{
    #region Attributs
    [SerializeField ] private Camera _camera;
    private Vector3 _savePosition = Vector3.zero;
    [SerializeField] private int _size = 0;
    [SerializeField] private Collider _collider = null;
    [SerializeField] private float _id = 0;
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] private Canvas _canva = null;
    [SerializeField] private GameObject _ant = null;
    [SerializeField] private Mesh _mesh = null;
    [SerializeField] private bool _selected = false;

    // Start is called before the first frame update
    #endregion Attributs

    #region Accessors
    public int Size { get => _size; set => _size = value; }
    public float Id { get => _id; set => _id = value; }
    public bool Selected { get => _selected; set => _selected = value; }
    #endregion Acceessors

    void Start()
    {
        DefineARandomID();
    }

    void Update()
    {
        //FollowMouse();
        CheckForInput();
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
        _id = Random.Range(0f, int.MaxValue);

    }

    private void Setup()
    {
        _camera = Camera.main;
        _text = gameObject.GetComponentInChildren<TMP_Text>();
        _canva = gameObject.GetComponentInChildren<Canvas>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject entering = other.gameObject;
        if (entering.CompareTag("AllyAnt"))
        {
            Ant enteringAnt = entering.GetComponent<Ant>();
            if (_size > enteringAnt.Size)
            {
                _size += enteringAnt.Size;
                Destroy(entering);

            }
            else if (_size == enteringAnt.Size)
            {
                if (_id >= enteringAnt.Id)
                {
                    _size += enteringAnt.Size;
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

    private void CheckForInput()
    {
        if (_selected)
        {
            if (Input.GetKeyDown("space"))
            {
                Divide();
            }
        }
    }

    private void Divide()
    {
        Vector3 position = new Vector3(gameObject.transform.position.x + 2f, gameObject.transform.position.y, gameObject.transform.position.z);
        GameObject a = Instantiate(_ant, position, gameObject.transform.rotation);
        bool _isOdd = false;
        if (_size % 2 != 0)
            _isOdd = true;
        _size /= 2;
        Ant ant = a.GetComponent<Ant>();
        ant.Size = _size;
        if (_isOdd)
            _size += 1;
        if (ant.Size == 0)
            Destroy(a);
        else
        {
            _selected = false;
            ant.Selected = false;
        }
    }
}
