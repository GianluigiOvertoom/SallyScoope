using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenWaypointScript : MonoBehaviour
{
    [SerializeField]
    protected float debugDrawRadius = 1f;
    [SerializeField]
    private GameObject m_enemy;

    private float m_yPos;
    public float m_xPos;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
    private void Start()
    {
        m_yPos = m_enemy.GetComponent<GreenEnemyScript>().yPos;
        transform.position = new Vector2(m_xPos, m_yPos);
    } 
    
}
