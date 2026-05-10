using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ToBuild : MonoBehaviour
{
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] private int _toGo = 0;
    private bool _completed = false;
    [SerializeField] private GameObject _sticks = null;
    [SerializeField] private GameObject _dirt = null;
    [SerializeField] private Canvas _canvas = null;
    [SerializeField] private ObMana _manager = null;

    // Start is called before the first frame update
    void Start()
    {
        _canvas.worldCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        CompletionLogic();
    }

    private void UpdateText()
    {
        Quaternion a = new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
        _canvas.transform.rotation = a;
        if (_completed)
        {
            _text.text = "";
        }
        else
        {
            _text.text = _toGo.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_completed)
        {
            GameObject entering = other.gameObject;
            if (entering.CompareTag("AllyAnt"))
            {
                Ant ant = entering.GetComponent<Ant>();
                if (_toGo < ant.Size)
                {
                    ant.Size -= _toGo;
                    _toGo = 0;
                    _manager.OneDone();
                }
                else
                {
                    _toGo -= ant.Size;
                    Destroy(entering);
                }
            }
        }
    }

    private void CompletionLogic()
    {
        if (!_completed)
        {
            if (_toGo <= 0)
            {
                _sticks.SetActive(false);
                _dirt.SetActive(true);
                _completed = true;
            }
        }
    }
}
