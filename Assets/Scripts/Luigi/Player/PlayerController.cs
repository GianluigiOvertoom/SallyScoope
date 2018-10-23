using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    walking,
    snap,
    zap,
    damaged,
    death
}

public enum PlayerDirection
{
    up,
    right,
    down,
    left
}

public class PlayerController : MonoBehaviour
{
    //Assign states
    public PlayerState s_state;
    public PlayerDirection s_direction;
    public bool s_attacking;

    //Assign Controls
    private float b_horizontalToInt;
    private float b_verticalToInt;
    private int b_horizontal;
    private int b_vertical;
    private bool b_snap;
    private bool b_zap;
    public bool b_pause;
    public bool b_submit;
    public bool b_cancel;

    //Assign Variables
    //Assign Player RigidBody
    [SerializeField]
    private Rigidbody2D m_rigidbody;

    //Assign Movement
    private float m_speed = 3;
    //Assign UI
    public bool m_isPaused;
    //Assign Attack
    [SerializeField]
    private GameObject m_pivot;
    private float m_rotation;
    [SerializeField]
    private GameObject m_snap;
    [SerializeField]
    private GameObject m_zap;
    private float m_zapTimer = 0.2f;
    private bool m_canAttack;

    //Assign Animator
    private Animator m_anim;

    private void Start ()
    {
        m_isPaused = false;
        m_snap.SetActive(false);
        m_zap.SetActive(false);
        m_canAttack = true;
        m_anim = GetComponent<Animator>();
    }
    private void Update()
    {
        b_snap = Input.GetButton("A");
        b_zap = Input.GetButtonDown("B");
        b_pause = Input.GetButtonDown("Pause");
        b_submit = Input.GetButtonDown("Submit");
        b_cancel = Input.GetButtonDown("Cancel");

        //Animator
        m_anim.SetInteger("State", (int)s_state);
        m_anim.SetBool("Attack", s_attacking);

        //Attacking
        if (b_snap == true && m_isPaused == false)
        {
            m_speed = 0;
            m_snap.SetActive(true);
            s_state = PlayerState.snap;
            s_attacking = true;
        }
        else if (b_zap == true && m_canAttack == true && m_isPaused == false)
        {
            s_state = PlayerState.zap;
            s_attacking = true;
            StartCoroutine(Zapping());
        }
        else if (b_snap == false)
        {
            m_speed = 5;
            m_snap.SetActive(false);
            s_attacking = false;
        }
        if (m_canAttack == false)
        {
            m_speed = 0;
            m_zap.SetActive(true);
            s_state = PlayerState.zap;
            s_attacking = true;
        }
        //Rotate Attack
        m_pivot.transform.rotation = Quaternion.Euler(0, 0, m_rotation);
    }

    private void FixedUpdate()
    {
        //Controls
        b_horizontalToInt = Input.GetAxis("Horizontal");
        b_verticalToInt = Input.GetAxis("Vertical");

        m_anim.SetFloat("Direction", (float)s_direction);

        //fix controller problems
        b_horizontal = (int)b_horizontalToInt;
        b_vertical = (int)b_verticalToInt;
        //Movement
        m_rigidbody.velocity = new Vector2(b_horizontal, b_vertical) * m_speed;
        //Movement states
        if (b_horizontal != 0 && m_speed > 0 || b_vertical != 0 && m_speed > 0 && s_attacking == false)
        {
            s_state = PlayerState.walking;
        }
        else if (b_horizontal == 0 && b_vertical == 0 && s_attacking == false)
        {
            s_state = PlayerState.idle;
        }
        //direction
        if (b_horizontal > 0)
        {
            s_direction = PlayerDirection.right;
            m_rotation = 270;
        }
        if (b_horizontal < 0)
        {
            s_direction = PlayerDirection.left;
            m_rotation = 90;
        }
        if (b_vertical > 0)
        {
            s_direction = PlayerDirection.up;
            m_rotation = 0;
        }
        if (b_vertical < 0)
        {
            s_direction = PlayerDirection.down;
            m_rotation = 180;
        }
    }
    
    IEnumerator Zapping()
    {
        m_canAttack = false;
        yield return new WaitForSeconds(m_zapTimer);
        s_attacking = false;
        m_zap.SetActive(false);
        m_canAttack = true;
    }
}
