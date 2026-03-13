using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CentralRessource : MonoBehaviour
{
    private static CentralRessource _instance;
    [SerializeField] private List<Ant> ants = new List<Ant>();
    [SerializeField] private GameObject _base = null;

    public static CentralRessource Instance
    {
        get => _instance;
        set => _instance = value;
    }

    public List<Ant> Ants
    {
        get => ants;
        set => ants = value;
    }
    public GameObject Base
    {
        get => _base;
        set => _base = value;
    }

    private void Awake()
    {
        Initialise();
    } 

    private void Initialise()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadScene("DEVLvlGaspard");
        }
    }
}
