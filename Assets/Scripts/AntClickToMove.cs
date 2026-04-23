using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Use physics raycast hit from mouse click to set agent destination
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class AntClickToMove : MonoBehaviour
    {
        private bool _selected = false;
        NavMeshAgent m_Agent;
        RaycastHit m_HitInfo = new RaycastHit();
        private Ant _fuck = null;

        public bool Selected { get => _selected; set => _selected = value; }

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            _fuck = gameObject.GetComponent<Ant>();
        }

        void Update()
        {
            _selected = _fuck.Selected;
            if (Selected && Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                    m_Agent.destination = m_HitInfo.point;
            }
        }
    }
}