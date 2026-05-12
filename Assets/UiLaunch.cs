using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiLaunch : MonoBehaviour
{
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] private Image _image = null;
    private float _alpha = 1f;


    // Start is called before the first frame update
    void Start()
    {
        SondManager.Instance.PlaySound("Reload");
    }

    // Update is called once per frame
    void Update()
    {
        UpdateImageAlpha();
    }

    private void UpdateImageAlpha()
    {
        if (_alpha > 0)
        {
            _alpha -= Time.deltaTime;
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
}
