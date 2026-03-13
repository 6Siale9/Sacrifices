using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RessourceManager : MonoBehaviour
{
    
    private static RessourceManager _instance = null;
    public static RessourceManager Instance => _instance;
    private int _food = 0;
    private int _aphids = 0;

    [SerializeField] private float _health = 100f;
    public int Food
    {
        get => _food;
        set
        {
            _food = value;
        }
    }
   
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
    public float Health
    {
        get => _health;
        set
        {
            _health = value;
        }
    }
     public int Aphids
    {
        get => _aphids;
        set
        {
            _aphids = value;
        }
    }
}
