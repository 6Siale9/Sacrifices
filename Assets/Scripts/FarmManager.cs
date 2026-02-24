using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FarmManager : MonoBehaviour
{
    // Start is cal
    private float _seconds = 0f;
   
    void Start()
    {
        RessourceManager.Instance.FoodChange += FoodSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (_seconds >= 1f)
        {
            _seconds = 0f;
            FoodSpawn();
        }
        else
        {
            _seconds += Time.deltaTime; 
        }
    }
    private void FoodSpawn()
    {
       RessourceManager.Instance.Food += RessourceManager.Instance.Aphids/30;
    }
    
}
