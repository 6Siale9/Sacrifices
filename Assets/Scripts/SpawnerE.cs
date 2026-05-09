using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnerE : MonoBehaviour
{
    [SerializeField] private float _firstCd = 0f;
    [SerializeField] private float _nextCd = 0f;
    [SerializeField] private TMP_Text _text = null;

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
        float a = Mathf.Round(_firstCd);
        _text.text = a.ToString();
    }

    private void SpawnLogic()
    {

    }
}
