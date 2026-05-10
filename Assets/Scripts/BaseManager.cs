using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{
    [SerializeField] private Transform _army;
    [SerializeField] private Transform _enemyObj;
    [SerializeField] private GameObject _ant;
    [SerializeField] private GameObject _farm;
    
    private float _cooldown1sec = 0f;
    [SerializeField] private float _cooldown1 = 1f;
    [SerializeField] private float _cooldown2 = 5f;
    private float _cooldown2sec = 0f;
    private bool _healing = false;
    private Vector3 _spawnPosition = new Vector3(3.2f, 0.5f, 9.2f);

    public Transform EnemyObj { get => _enemyObj; set => _enemyObj = value; }

    /* if nouriture est bien faire l'incom sinon stoper l'incom
quand la fourmis spawn elle se fusionne dans un tas en attente 
on trigger enter se supprimer et donner sa size a la fourmis qui spawn
*/

    // Start is called before the first frame update
    void Start()
    {
       Initialize();
    }

    private void Initialize()
    {
        RessourceManager.Instance.Base = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (RessourceManager.Instance.Health < 100f)
        {
            _healing = true;
        }
        else
        {
            _healing = false;
        }
        if (_cooldown1sec >= _cooldown1)
        {
            _cooldown1 = 5f;
            if (_healing == true)
            {
              if (RessourceManager.Instance.Food > 0)
                {
                    RessourceManager.Instance.Food -= 1;
                    RessourceManager.Instance.Health += 3;
                }    
            }

        }
        if (_cooldown2sec >= _cooldown2 && !_healing && RessourceManager.Instance.Food > 0)
        {
            _cooldown2 = 5f;
            if (RessourceManager.Instance.Food > 2)
            {
                RessourceManager.Instance.Food -= 1;
                Spawn();
            }  
              
        }
        _cooldown1 -= Time.deltaTime;
        _cooldown2 -= Time.deltaTime;  
        //RessourceManager.Instance.Aphids
    }

    private void Spawn()
    {
        _spawnPosition = Random.insideUnitSphere * 5f + transform.position;
        _spawnPosition.y = 1;
        Instantiate(_ant, _spawnPosition, Quaternion.identity, _army);
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject merde = other.gameObject;
        if (merde.CompareTag("Enemy"))
        {
            Enemy enemy = merde.GetComponent<Enemy>();
            RessourceManager.Instance.Health -= enemy.Size;
            if (RessourceManager.Instance.Health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(enemy.gameObject);
            }
        }
    }
}
