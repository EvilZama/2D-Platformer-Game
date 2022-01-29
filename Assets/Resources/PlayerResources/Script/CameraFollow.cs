using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;


    void Update()
    {
        PlayerCamera();
    }

    private void PlayerCamera()
    {
        transform.position = target.position + offset;
    }
}
