using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Zone1 : MonoBehaviour
{
    [SerializeField] private Collider _collider = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Ant ant = collision.rigidbody.gameObject.GetComponent<Ant>();
        if (ant != null)
        {
            SceneManager.LoadScene("Lvl2");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Ant ant = other.gameObject.GetComponent<Ant>();
        if (ant != null)
        {
            SceneManager.LoadScene("Lvl2");
        }
    }
}
