using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    public float m_speed;
    [SerializeField]
    private Transform m_player;
    private Vector2 m_target;

    private void Start()
    {
        m_target = new Vector2(m_player.position.x, m_player.position.y);
    }

    public void OnObjectSpawn ()
    {
        m_target = new Vector2(m_player.position.x, m_player.position.y);
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_target, m_speed * Time.deltaTime);

        if (transform.position.x == m_target.x && transform.position.y == m_target.y)
        {
            this.gameObject.SetActive(false);
        }
    }
    
}
