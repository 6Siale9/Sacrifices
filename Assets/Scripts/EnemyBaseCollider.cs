using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseCollider : MonoBehaviour
{
    [SerializeField] private float _maxHealth = 200;
    private float _health = 0;

    private void Start()
    {
        _health = _maxHealth;
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AllyAnt"))
        {
            Ant ant = other.gameObject.GetComponentInParent<Ant>();
            if (ant.Size > _health)
            {
                ant.Size -= _health;
                Destroy(gameObject);
            }
            else if (ant.Size < _health)
            {
                _health -= ant.Size;
                Destroy(ant.gameObject);
            }
            else
            {
                Destroy(gameObject);
                Destroy(ant.gameObject);
            }
        }
    }
    */
}
