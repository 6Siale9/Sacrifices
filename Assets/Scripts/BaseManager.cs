using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    [SerializeField] private Transform _army;
    [SerializeField] private GameObject _ant;
    [SerializeField] private GameObject _farm;
    private float _seconds = 0f;
    [SerializeField] private int _pv = 100;
    private bool _healing = false;
    private Vector3 _spawnPosition;
    /* if nouriture est bien faire l'incom sinon stoper l'incom
    quand la fourmis spawn elle se fusionne dans un tas en attente 
    on trigger enter se supprimer et donner sa size a la fourmis qui spawn
    */
    
    // Start is called before the first frame update
    void Start()
    {
        _spawnPosition = Random.insideUnitSphere * 5f + transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         if (_seconds >= 1f)
        {
            if (_healing == true)
            {
              if (RessourceManager.Instance.Food > 0)
                {
                    RessourceManager.Instance.Food -= 1;
                    _pv += 10;
                }    
            }

        }
          if (_seconds >= 5f)
        {
            _seconds = 0f;
            if (_healing == true)
            {
               if (RessourceManager.Instance.Food > 0)
                {
                    RessourceManager.Instance.Food -= 1;
                    Spawn();
                }  
            }
              
        }
        _seconds += Time.deltaTime; 
    }
    private void Spawn()
    {
        Instantiate(_ant, _spawnPosition, Quaternion.identity, _army);
    }
}
