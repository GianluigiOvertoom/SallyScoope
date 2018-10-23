using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingControls : MonoBehaviour
{
    //Assign Controls
    private float b_horizontalToInt;
    private float b_verticalToInt;
    public int b_horizontal;
    public int b_vertical;
    public bool b_snap;
    public bool b_zap;
    public bool b_pause;
    public bool b_submit;
    public bool b_cancel;

    //Assign pause
    public bool m_isPaused;

    private void Start()
    {
        m_isPaused = false;
    }

    private void Update ()
    {
        //Controls
        b_horizontalToInt = Input.GetAxis("Horizontal");
        b_verticalToInt = Input.GetAxis("Vertical");
        b_snap = Input.GetButton("A");
        b_zap = Input.GetButtonDown("B");
        b_pause = Input.GetButtonDown("Pause");
        b_submit = Input.GetButtonDown("Submit");
        b_cancel = Input.GetButtonDown("Cancel");

        //fix controller problems
        b_horizontal = (int)b_horizontalToInt;
        b_vertical = (int)b_verticalToInt;        
        //run
        if (b_horizontal > 0)
        {
            Debug.Log("Walking forward");
        }
        else if (b_horizontal < 0)
        {
            Debug.Log("Walking backwards");
        }
        if (b_vertical > 0)
        {
            Debug.Log("Walking up");
        }
        else if (b_vertical < 0)
        {
            Debug.Log("Walking down");
        }
        else if (b_vertical == 0 && b_horizontal == 0)
        {
            Debug.Log("Idle");
        }
        //Snap
        if (b_snap && m_isPaused == false)
        {
            Debug.Log("Say cheese");
        }
        //Zap
        if (b_zap && m_isPaused == false)
        {
            Debug.Log("Gotcha");
        }
        //Pause
        if (b_pause && m_isPaused == false)
        {
            Debug.Log("You're paused now");
            m_isPaused = true;
        }
        //UnPause
        else if (b_pause && m_isPaused == true)
        {
            Debug.Log("You've been unpaused");
            m_isPaused = false;
        }
        //Submit
        if (b_submit && m_isPaused == true)
        {
            Debug.Log("Confirm/Submit");
        }
        //Cancel
        if (b_cancel && m_isPaused == true)
        {
            Debug.Log("Cancel");
        }
	}
}