using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation.Samples;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _size = 0;
    [SerializeField] private bool _AttackBase = false;
    [SerializeField] private TMP_Text _text = null;
    [SerializeField] private Canvas _canva = null;

    public int Size { get => _size; set => _size = value; }
    public bool AttackBase { get => _AttackBase; set => _AttackBase = value; }

    // Start is called before the first frame update
    void Start()
    {
        StartLogic();
    }

    private void StartLogic()
    {
        if (_AttackBase)
        {
            GetNearestAnt();
        }
        else
        {
            gameObject.GetComponent<MoveToObject>().Target = RessourceManager.Instance.Base;
        }
    }

    private void GetNearestAnt()
    {
        Ant savedAnt = null;
        for (int i = 0; i < RessourceManager.Instance.Ants.Count; i++) 
        {
            float savedDistance = 0;
            if (Vector3.Distance(RessourceManager.Instance.Ants[i].gameObject.transform.position, gameObject.transform.position) < savedDistance)
            {
                savedDistance = Vector3.Distance(RessourceManager.Instance.Ants[i].gameObject.transform.position, gameObject.transform.position);
                savedAnt = RessourceManager.Instance.Ants[i];
            }
            else if (savedAnt == null)
            {
                savedDistance = Vector3.Distance(RessourceManager.Instance.Ants[i].gameObject.transform.position, gameObject.transform.position);
                savedAnt = RessourceManager.Instance.Ants[i];
            }
        }
        gameObject.GetComponent<MoveToObject>().Target = savedAnt.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        Quaternion a = new Quaternion(Camera.main.transform.rotation.x, Camera.main.transform.rotation.y, Camera.main.transform.rotation.z, Camera.main.transform.rotation.w);
        _canva.transform.rotation = a;
            _text.text = "Enemy size : " + _size.ToString();
    }
}
