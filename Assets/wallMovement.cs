using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallMovement : MonoBehaviour
{
    [SerializeField]
    private Transform waypoint;

    [SerializeField]
    private Vector3 movedir;

    [SerializeField]
    [Tooltip("movespeed in units per second")]
    [Range(0f, 50)]
    private float moveSpeed = 3;
    public GameObject Target;

    private Transform targetWaypoint;
    // Start is called before the first frame update
    void Start()
    {
        targetWaypoint = waypoint;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, moveSpeed * Time.deltaTime);
        transform.position += moveSpeed * Time.deltaTime * movedir;
    }
}
