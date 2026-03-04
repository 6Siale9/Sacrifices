using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Use physics raycast hit from mouse click to set agent destination
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class AllyAntMove : MonoBehaviour
    {
        NavMeshAgent m_Agent;
        RaycastHit m_HitInfo = new RaycastHit();
        [SerializeField] private Ant _otherScript = null;

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            if (_otherScript.Selected)
            {
                if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
                {
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                        m_Agent.destination = m_HitInfo.point;
                }
            }
        }
    }
}