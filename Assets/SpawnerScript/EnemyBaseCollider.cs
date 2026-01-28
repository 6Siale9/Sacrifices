using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseCollider : MonoBehaviour
{
    [SerializeField] private float _health = 200f;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SmallGroupAnts")
        {
            Destroy(other.gameObject);
            _health -= 15f;
        }

        if (other.gameObject.tag == "MidGroupAnts")
        {
            Destroy(other.gameObject);
            _health -= 45f;
        }

        if (other.gameObject.tag == "BigGroupAnts")
        {
            Destroy(other.gameObject);
            _health -= 135f;
        }
    }

    private void Update()
    {
        UpdateHealth();
    }
    private void UpdateHealth()
    {
        if (_health < 0f)
        {
            Destroy(gameObject);
        }
    }
}
