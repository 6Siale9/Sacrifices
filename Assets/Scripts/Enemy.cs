using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation.Samples;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _size = 0;
    [SerializeField] private bool _AttackBase = false;

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
            gameObject.GetComponent<MoveToObject>().Target = CentralRessource.Instance.Base;
        }
    }

    private void GetNearestAnt()
    {
        Ant savedAnt = null;
        for (int i = 0; i < CentralRessource.Instance.Ants.Count; i++) 
        {
            float savedDistance = 0;
            if (Vector3.Distance(CentralRessource.Instance.Ants[i].gameObject.transform.position, gameObject.transform.position) < savedDistance)
            {
                savedDistance = Vector3.Distance(CentralRessource.Instance.Ants[i].gameObject.transform.position, gameObject.transform.position);
                savedAnt = CentralRessource.Instance.Ants[i];
            }
            else if (savedAnt == null)
            {
                savedDistance = Vector3.Distance(CentralRessource.Instance.Ants[i].gameObject.transform.position, gameObject.transform.position);
                savedAnt = CentralRessource.Instance.Ants[i];
            }
        }
        gameObject.GetComponent<MoveToObject>().Target = savedAnt.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
