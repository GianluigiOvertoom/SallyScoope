using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleEnemy : MonoBehaviour
{
    public float m_speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    [SerializeField]
    private GameObject m_target;
    [SerializeField]
    private GameObject m_unit;
    public float m_Range;

    private bool m_horizontal;
    private bool m_vertical;

    //Assign Renderer
    //private SpriteRenderer m_renderer;
    void Start ()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        //m_renderer = GetComponent<SpriteRenderer>();
    }

	void Update ()
    {
        if (m_unit.transform.position.x >= m_target.transform.position.x - m_Range && m_unit.transform.position.x <= m_target.transform.position.x + m_Range && m_vertical == false)
        {
            transform.position = Vector2.MoveTowards(m_unit.transform.position, m_target.transform.position, (m_speed + (m_speed / m_speed)) * Time.deltaTime);
        }
        else if (m_unit.transform.position.y >= m_target.transform.position.y - m_Range && m_unit.transform.position.y <= m_target.transform.position.y + m_Range && m_horizontal == false)
        {
            transform.position = Vector2.MoveTowards(m_unit.transform.position, m_target.transform.position, (m_speed + (m_speed / m_speed)) * Time.deltaTime);
            m_vertical = true;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, m_speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                m_horizontal = false;
                m_vertical = false;
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }
}
