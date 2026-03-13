using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

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
    [SerializeField] private bool _selected = false;
    #region Work
    [SerializeField] private bool _working = false;
    private float _sliderValue = 0;
    [SerializeField] private Slider _slider = null;
    [SerializeField] private FoodSource _workstation = null;
    #endregion Work
    #endregion Attributs

    #region Accessors

    public int Size { get => _size; set => _size = value; }
    
    public float Id { get => _id; set => _id = value; }
    
    public bool Selected { get => _selected; set => _selected = value; }
    
    #endregion Acceessors

    void Start()
    {
        AddToList();
        DefineID();
    }

    void Update()
    {
        UpdateUI();
        CheckForInput();
        WorkLogic();
    }

    #region Initiate
    private void AddToList()
    {
        CentralRessource.Instance.Ants.Add(this);
    }

    private void DefineID()
    {
        if (CentralRessource.Instance.Ants.Count != 0)
        {
            _id = CentralRessource.Instance.Ants[CentralRessource.Instance.Ants.Count - 1].Id + 1;
        }
        else
        {
            _id = 0;
        }
    }
    #endregion Initiate

    #region Tick
    private void CheckForInput()
    {
        if (Input.GetKeyDown("space") && _selected)
        {
            Divide();
        }
    }

    private void UpdateUI()
    {
        Quaternion a = new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
        _canva.transform.rotation = a;
        if (_selected)
        {
            _text.text = "<" + _size.ToString() + ">";
        }
        else
        {
            _text.text = _size.ToString();
        }
        _slider.value = _sliderValue;
    }

    private void WorkLogic()
    {
        if (_working)
        {
            if (_sliderValue <= 1)
            {
                _sliderValue += Time.deltaTime * 0.1f;
            }
            else
            {
                _sliderValue = 0;
                if (_workstation.ResourceAvailable > _size)
                {
                    // Bouffe += _size ici
                    Debug.Log("Miam : " + _size);
                    _workstation.ResourceAvailable -= _size;
                }
                else
                {
                    // Bouffe += _workstation.RessourceAvailable ici
                    Debug.Log("Miam : " + _workstation.ResourceAvailable);
                    _workstation.ResourceAvailable -= _size;
                    _working = false;
                    _sliderValue = 0;
                    _workstation = null;
                }
            }
        }
    }
    #endregion Tick

    #region Trigger
    private void OnTriggerEnter(Collider other)
    {
        GameObject entering = other.gameObject;
        if (entering.CompareTag("AllyAnt"))
        {
            Ant enteringScript = entering.GetComponent<Ant>();
            if (_size > enteringScript.Size)
            {
                _size += enteringScript.Size;
                if (enteringScript.Selected)
                {
                    _selected = true;
                }
                Destroy(entering);
            }
            else if (_size == enteringScript.Size)
            {
                if (_id > enteringScript.Id)
                {
                    _size += enteringScript.Size;
                    if (enteringScript.Selected)
                    {
                        _selected = true;
                    }
                    Destroy(entering);
                }
            }
        }
        else if (entering.CompareTag("Enemy"))
        {
            Enemy enteringScript = entering.GetComponent<Enemy>();
            if (enteringScript.Size > _size)
            {
                enteringScript.Size -= _size;
                Destroy(gameObject);
            }
            else if (enteringScript.Size < _size)
            {
                _size -= enteringScript.Size;
                Destroy(entering);
            }
            else if (enteringScript.Size == _size)
            {
                Destroy(entering);
                Destroy(gameObject);
            }
        }
        else if (entering.CompareTag("WorkStation"))
        {
            _working = true;
            _workstation = entering.GetComponentInParent<FoodSource>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("WorkStation"))
        {
            _working = false;
            _workstation = null;

            _sliderValue = 0;
        }
    }
    #endregion Trigger

    private void Divide()
    {
        if (_size != 1)
        {
            Vector3 offset = new Vector3(gameObject.transform.position.y, gameObject.transform.position.x + 1, gameObject.transform.position.z);
            bool isOdd = false;
            if (_size % 2 == 1)
            {
                isOdd = true;
            }
            _size /= 2;
            GameObject child = Instantiate(gameObject, offset, gameObject.transform.rotation);
            Ant childAnt = child.GetComponent<Ant>();
            childAnt.Size = _size;
            if (isOdd)
            {
                _size += 1;
            }
        }
    }
}
