using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class RessourceManager : MonoBehaviour
{
    
    private static RessourceManager _instance = null;
    public static RessourceManager Instance => _instance;
    private int _food = 0;
    private List<Ant> _ants = new List<Ant>();
    [SerializeField] private GameObject _base = null;

    public int Food
    {
        get => _food;
        set
        {
            _food = value;
        }
    }

    public List<Ant> Ants
    {
        get => _ants;
        set
        {
            _ants = value;
        }
    }

    public GameObject Base
    {
        get => _base;
        set
        {
            _base = value;
        }
    }

    private int _aphids = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private event Action _foodChange;
    public event Action FoodChange
    {
        add 
        { 
            _foodChange -= value; 
            _foodChange += value;

        }
        remove 
        {
            _foodChange -= value;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
      public int Aphids => _aphids;
}
