using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObMana : MonoBehaviour
{
    [SerializeField] private int _scene = 0;
    [SerializeField] private int _toDo = 0;
    private int _actually = 0;
    private bool _go = false;
    private float _cd = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NextLogic();
    }

    public void OneDone()
    {
        _actually += 1;
        if (_actually == _toDo)
        {
            _go = true;
        }
    }

    private void NextLogic()
    {
        if (_go)
        {
            if (_cd <= 0)
            {
                SceneManager.LoadScene(_scene);
            }
            else
            {
                _cd -= Time.deltaTime;
            }
        }
    }
}
