using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FoodSource : MonoBehaviour
{
    [SerializeField] private float _resourceAvailable = 1;
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] private Canvas _canva = null;


    public float ResourceAvailable { get => _resourceAvailable; set => _resourceAvailable = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
        LifeLogic();
    }

    private void UpdateUI()
    {
        Quaternion a = new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
        _canva.transform.rotation = a;
        _text.text =_resourceAvailable.ToString();
    }

    private void LifeLogic()
    {
        if (_resourceAvailable <= 0)
        {
            Destroy(gameObject);
        } 
    }
}
