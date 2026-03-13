using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private RectTransform _fill;

    [SerializeField] private RectTransform _hitIndicator;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private float _lerpValue = 0.1f;
    private float _currentHealth;
    private Vector3 _fill0;

    public float CurrentHp
    {
        get
        {
            return _currentHealth;
        }
        set
        {
            _currentHealth = Mathf.Clamp(value, 0, _maxHealth);
        }
    }

    public float HpPerc => (float)_currentHealth / _maxHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void SetHealth(float health)
    {
        // Calcule la position de remplissage en fonction du pourcentage de vie
        _fill0 = new Vector3(-_fill.rect.width, 0, 0);  
        CurrentHp = health;
         Vector3 targetPos = Vector3.Lerp(_fill0, Vector3.zero, HpPerc);
        _fill.transform.localPosition = Vector3.Lerp(_fill.transform.localPosition, targetPos, _lerpValue);
        _hitIndicator.transform.localPosition = Vector3.Lerp(_hitIndicator.transform.localPosition, targetPos, _lerpValue/5);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {      
            RessourceManager.Instance.Health -= 10;
        }
        _currentHealth = RessourceManager.Instance.Health;

        SetHealth(_currentHealth);

        

    }
   
}
