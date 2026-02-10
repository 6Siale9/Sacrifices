using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Use physics raycast hit from mouse click to set agent destination
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class MoveToObject : MonoBehaviour
    {
        NavMeshAgent _Agent;
        RaycastHit _HitInfo = new RaycastHit();
        [SerializeField] private GameObject _target = null;

        void Start()
        {
            _Agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            /*if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))*/
            if (Vector3.Distance(gameObject.transform.position, _target.transform.position) > 2)
                _Agent.destination = _target.transform.position;
            else
                gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
            //}
        }
    }
}