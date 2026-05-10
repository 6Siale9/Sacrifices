using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnerE : MonoBehaviour
{
    [SerializeField] private float _firstCd = 0f;
    [SerializeField] private float _nextCd = 0f;
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] private int _size = 0;
    [SerializeField] private GameObject _ant = null;
    [SerializeField] private Canvas _canvas = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
        SpawnLogic();
    }

    private void UpdateText()
    {
        Quaternion a = new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
        _canvas.transform.rotation = a;
        float b = Mathf.Round(_firstCd);
        _text.text = _size.ToString() + " dans " + b.ToString();
    }

    private void SpawnLogic()
    {
        if (_firstCd <= 0)
        {
            _firstCd = _nextCd;
            GameObject a = Instantiate(_ant);
            Enemy enemy = a.GetComponent<Enemy>();
            enemy.Size = _size;
            int i = Random.Range(0, 50);
            if (i < 50)
            {
                enemy.AttackBase = true;
            }
            else
            {
                enemy.AttackBase = false;
            }
        }
        else
        {
            _firstCd -= Time.deltaTime;
        }
    }
}
