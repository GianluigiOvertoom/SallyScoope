using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MagentaEnemyState
{
    idle,
    attacking
}

public class MagentaEnemy : MonoBehaviour
{
    //Assign States
    public MagentaEnemyState s_state;
    public bool s_attacking;

    //Assign range
    public float m_attackRange;
    //Assign target
    [SerializeField]
    private Transform m_player;
    //Assign Attack values
    public int m_shotAmount;
    private int m_shots;
    private float m_shotTimer;
    public float m_startShotTimer;
    private float m_burstTimer;
    public float m_startBurstTimer;
    //Assign Attack
    ObjectPooler objectpooler;

    //Assign Animator
    private Animator m_anim;

    void Start()
    {
        m_shotTimer = m_startShotTimer;
        m_shots = m_shotAmount;
        objectpooler = ObjectPooler.Instance;
        m_anim = GetComponent<Animator>();
    }
    void Update()
    {
        //animator
        m_anim.SetInteger("State", (int)s_state);
        //if in range start shooting
        if (Vector2.Distance(transform.position, m_player.position) < m_attackRange)
        {
            if (m_shots > 0)
            {
                s_attacking = true;
            }
            else
            {
                s_attacking = false;
            }
            //shoot shot
            if (m_burstTimer <= 0 && m_shots > 0)
            {
                objectpooler.SpawnFromPool("EnemyProjectile", transform.position, Quaternion.identity);
                m_burstTimer = m_startBurstTimer;
                m_shots -= 1;
                
            }
            else
            {
                m_burstTimer -= Time.deltaTime;
            }
        }
        else
        {
            s_state = MagentaEnemyState.idle;
            s_attacking = false;
        }

        if (m_shotTimer <= 0 && m_shots <= 0)
        {
            m_shotTimer = m_startShotTimer;
            m_shots = m_shotAmount;
        }
        else if (Vector2.Distance(transform.position, m_player.position) < m_attackRange && m_shotTimer > 0)
        {
            m_shotTimer -= Time.deltaTime;
        }

        //state change
        if (s_attacking == true)
        {
            s_state = MagentaEnemyState.attacking;
        }
        if (s_attacking == false)
        {
            s_state = MagentaEnemyState.idle;
        }
    }
}
