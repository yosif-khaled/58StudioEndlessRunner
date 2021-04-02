using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 cameraOffset;

    [SerializeField] private Transform target;

    private void Start()
    {
        cameraOffset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, cameraOffset.z + target.position.z);
        transform.position = newPosition;
    }
}
