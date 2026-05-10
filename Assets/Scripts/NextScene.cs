using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
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
            SceneManager.LoadScene(1);
        }
        else
        {
            _a = true;
        }
    }
}
