using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleWaypointScript : MonoBehaviour
{
    [SerializeField]
    protected float debugDrawRadius = 1f;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius);
    }
    void Start ()
    {
    }
}
