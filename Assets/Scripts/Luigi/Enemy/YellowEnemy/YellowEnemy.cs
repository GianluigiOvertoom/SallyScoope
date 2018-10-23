using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum YellowEnemyState
{
    idle,
    attacking
}

public class YellowEnemy : MonoBehaviour
{
    //Assign States
    public YellowEnemyState s_state;

    //Assign range
    public float m_attackRange;
    //Assign target
    [SerializeField]
    private Transform m_player;
    //Assign Attack values
    private float m_shotTimer;
    public float m_startShotTimer;
    //Assign Attack
    ObjectPooler objectpooler;
    
    //Assign Animator
    private Animator m_anim;

    void Start ()
    {
        m_shotTimer = m_startShotTimer;
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
            //state change
            if (m_shotTimer < 0.1 || m_shotTimer == 0.6)
            {
                s_state = YellowEnemyState.attacking;
            }
            if (m_shotTimer > 0.2)
            {
                s_state = YellowEnemyState.idle;
            }
            //shoot shot
            if (m_shotTimer <= 0)
            {
                objectpooler.SpawnFromPool("EnemyProjectile", transform.position, Quaternion.identity);
                m_shotTimer = m_startShotTimer;
            }
            else
            {
                m_shotTimer -= Time.deltaTime;
            }
        }
        else
        {
            s_state = YellowEnemyState.idle;
        }
    }
}
