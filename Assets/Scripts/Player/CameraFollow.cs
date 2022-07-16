using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothTime = 0.3f;

    private Vector3 velocity;

    private void FixedUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.position + offset, ref velocity, smoothTime);
    }
}
