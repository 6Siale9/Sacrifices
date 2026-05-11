using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoud : MonoBehaviour
{
    [SerializeField] private GameObject _button = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }   
    public void click()
    {
        SondManager.Instance.PlaySound("Click");
    }
    public void hover()
    {
        SondManager.Instance.PlaySound("Hover");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
