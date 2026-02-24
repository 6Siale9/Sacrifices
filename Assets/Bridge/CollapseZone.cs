using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollapseZone : MonoBehaviour
{
    [SerializeField] private GameObject _bridge;
    [SerializeField] private GameObject _ants;
    [SerializeField] private int _requiredAnts = 0;
    private int _currentUnits = 0;
    // Start is called before the first frame update
    void Start()
    {
        _bridge.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_ants)
        {
            Destroy(other.gameObject);
            _currentUnits++;

            if (_currentUnits >= _requiredAnts)
            {
                _bridge.SetActive(true);
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
