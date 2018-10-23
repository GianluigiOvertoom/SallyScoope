using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GreenEnemyScript : MonoBehaviour
{
    //Enemy hover/Patrolling
    public float m_hSpeed = 0.05f;
    public float m_vSpeed = 3f;
    public float m_amplitude = 0.2f;
    public Vector2 m_tempPos;
    private float waitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    public float startWaitTime;
    public float yPos;
    //Assign Renderer
    private SpriteRenderer m_renderer;

    void Start ()
    {
        //Hover
        m_tempPos = new Vector2(transform.position.x, yPos);
        //patrol spots
        randomSpot = Random.Range(0, moveSpots.Length);
        m_renderer = GetComponent<SpriteRenderer>();
        waitTime = startWaitTime;
    }

    private void FixedUpdate ()
    {
        //Hover movement
        transform.position = m_tempPos;

        //Patrolling
        m_tempPos = transform.position = Vector2.MoveTowards(m_tempPos, moveSpots[randomSpot].position, m_hSpeed * Time.deltaTime);
        m_tempPos.y = yPos + Mathf.Sin(Time.realtimeSinceStartup * m_vSpeed) * m_amplitude;
        

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                m_tempPos = transform.position;
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (moveSpots[randomSpot].position.x < m_tempPos.x)
        {
            m_renderer.flipX = true;
        }
        
        else if(moveSpots[randomSpot].position.x > m_tempPos.x)
        {
            m_renderer.flipX = false;
        }
        
    }
}