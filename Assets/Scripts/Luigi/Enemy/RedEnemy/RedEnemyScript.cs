using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemyScript : MonoBehaviour
{
    public float m_moveSpeed;
    [SerializeField]
    private Transform m_target;
    public float m_attackRange;

    void Start ()
    {
        
	}
	void Update ()
    {
        if (Vector2.Distance(transform.position, m_target.position) > m_attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, m_target.position, m_moveSpeed * Time.deltaTime);
        }
        
    }
}
