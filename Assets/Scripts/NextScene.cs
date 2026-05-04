using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string _sceneToCall = null;
    private bool _a = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WaitForOneFrame();
    }

    private void WaitForOneFrame()
    {
        if (_a)
        {
            SceneManager.LoadScene(_sceneToCall);
        }
        else
        {
            _a = true;
        }
    }
}
