using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector2 m_velocity;
    public float m_smoothTimeX;
    public float m_smoothTimeY;

    [SerializeField]
    private GameObject player;

    public bool bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

	void Start ()
    {
	}

    private void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref m_velocity.x, m_smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref m_velocity.y, m_smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds == true)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
    }

    public void SetMinCamPos()
    {
        minCameraPos = gameObject.transform.position;
    }
    public void SetMaxCamPos()
    {
        maxCameraPos = gameObject.transform.position;
    }
}
