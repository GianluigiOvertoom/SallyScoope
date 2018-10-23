using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;
    public Transform m_upWall;
    public Transform m_downWall;
    public Transform m_righWall;
    public Transform m_leftWall;

    private float xMax;
    private float xMin;
    private float yMax;
    private float yMin;

    void Start ()
    {
	}
	void Update ()
    {
        xMax = m_righWall.transform.position.x;
        xMin = m_leftWall.transform.position.x;
        yMax = m_upWall.transform.position.y;
        yMin = m_downWall.transform.position.y;

        //if within the bounds, camera locks onto player
        if (m_player.transform.position.y < yMax && m_player.transform.position.y > yMin)
        {
            transform.position = new Vector3(m_player.transform.position.x, m_player.transform.position.y, -10f);
        }

        //if player is above/below the y axis binders, camera locks to player on xAxis and stays stationary 
        //on yAxis
        if (m_player.transform.position.y > yMax)
        {
            transform.position = new Vector3(m_player.transform.position.x, yMax, -10f);
        }
        else if (m_player.transform.position.y < yMin)
        {
            transform.position = new Vector3(m_player.transform.position.x, yMin, -10f);
        }

        //if player is right/left of the xAxis binders, camera locks to player on yAxis and stays stationary 
        //on xAxis
        if (m_player.transform.position.x > xMax)
        {
            transform.position = new Vector3(xMax, m_player.transform.position.y, -10f);
        }
        else if (m_player.transform.position.x < xMin)
        {
            transform.position = new Vector3(xMin, m_player.transform.position.y, -10f);
        }

        //if player is above the yAxis binder, and to the right of the xAxis, the camera stays stationary
        if (m_player.transform.position.y > yMax && m_player.transform.position.x > xMax)
        {
            transform.position = new Vector3(xMax, yMax, -10f);
        }
        //if player is above the yAxis binder, and to the left of the xAxis, the camera stays stationary
        if (m_player.transform.position.y > yMax && m_player.transform.position.x < xMin)
        {
            transform.position = new Vector3(xMin, yMax, -10f);
        }
        //if player is below the yAxis binder, and to the right of the xAxis, the camera stays stationary
        if (m_player.transform.position.y < yMin && m_player.transform.position.x > xMax)
        {
            transform.position = new Vector3(xMax, yMin, -10f);
        }
        //if player is below the yAxis binder, and to the left of the xAxis, the camera stays stationary
        if (m_player.transform.position.y < yMin && m_player.transform.position.x < xMin)
        {
            transform.position = new Vector3(xMin, yMin, -10f);
        }
    }
}
