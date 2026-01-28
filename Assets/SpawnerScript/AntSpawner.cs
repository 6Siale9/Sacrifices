using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntSpawner : MonoBehaviour
{
    [SerializeField] private Transform _posSpawn;
    [SerializeField] private GameObject _smallGroupeAnt;
    [SerializeField] private GameObject _midGroupeAnt;
    [SerializeField] private GameObject _bigGroupeAnt;

    private float _spawnDelay = 4f;
    private float _timeDelay;
    void Start()
    {
        
    }

    void Update()
    {

    }

    public float SpawnTime
    {
        get => _timeDelay;
        set => _timeDelay = value;
    }

    public void SpawnSmallGroupeAnts()
    {
        Instantiate(_smallGroupeAnt, _posSpawn);
    }

    public void SpawnMidGroupeAnts()
    {
        Instantiate(_midGroupeAnt, _posSpawn);
    }

    public void SpawnBigGroupeAnts()
    {
        Instantiate(_bigGroupeAnt, _posSpawn);
    }
    //_timeDelay += Time.deltaTime;
    //if (_timeDelay > _spawnDelay)
    //{
    //  SpawnAnts();
    //_timeDelay = 0;
    //}
}
