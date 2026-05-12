using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLaunch : MonoBehaviour
{
    [SerializeField] private GameObject _text = null;
    [SerializeField] private Image _image = null;
    private float _alpha = 1f;
    private float _pos = -800f;
    private float _timing = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SondManager.Instance.PlaySound("Reload");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateImageAlpha();
        UpdateTextPosition();
    }

    private void UpdateImageAlpha()
    {
        if (_alpha > 0)
        {
            _alpha -= Time.deltaTime * 0.6f;
            Color color = new Color(0f, 0f, 0f, _alpha);
            _image.color = color;
        }
        else if (_alpha == 0)
        {
            _alpha -= 0;
            Color color = new Color(0f, 0f, 0f, _alpha);
            _image.color = color;
        }
    }

    private void UpdateTextPosition()
    {
        if (_pos < 0)
        {
            _pos += Time.deltaTime * 900;
        }
        if (_pos >= 0 && _pos < 800)
        {
            if (_timing < 0.6f)
            {
                _timing += Time.deltaTime;
            }
            else
            {
                _pos += Time.deltaTime * 900;
            }
        }
        if (_pos >= 800)
        {
            Destroy(gameObject);
        }
        _text.transform.localPosition = new Vector3(_pos, 0, 0);
    }
}
