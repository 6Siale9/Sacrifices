using System;
using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

public static CameraShake Instance { get; private set; }
    private float _shakeDuration = 0.3f;
    private float _shakeMagnitude = 0.2f;
    private Vector3 _initialPosition; 

    void Awake()
    {
        _initialPosition = transform.localPosition;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    //shake the camera
    public void ShakeCamera()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }
    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator Shake()
    {
        float shakeTime = 0.0f;

        while (shakeTime < _shakeDuration)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * _shakeMagnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * _shakeMagnitude;

            transform.localPosition = new Vector3(_initialPosition.x + x, _initialPosition.y + y, _initialPosition.z);

            shakeTime += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = _initialPosition;
    }
}