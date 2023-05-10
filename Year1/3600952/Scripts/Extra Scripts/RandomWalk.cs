using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
// Walk to a random position and repeat
[RequireComponent(typeof(NavMeshAgent))]
public class RandomWalk : MonoBehaviour
{
    public float m_Range = 25.0f;
    NavMeshAgent m_agent;
 
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }
 
    void Update()
    {
        if (m_agent.pathPending || m_agent.remainingDistance > 0.1f)
            return;
 
        Vector2 randomPos = Random.insideUnitCircle;
        m_agent.destination = m_Range * new Vector3(randomPos.x,0,randomPos.y);
    }
}