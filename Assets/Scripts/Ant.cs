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
    private bool _selected = false;
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
        UpdateText();
        CheckForInput();
    }

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

    private void CheckForInput()
    {
        if (Input.GetKeyDown("space") && _selected)
        {
            Divide();
        }
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
    }

    private void UpdateText()
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
    }

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
