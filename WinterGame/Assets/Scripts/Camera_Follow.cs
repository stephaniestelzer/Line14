using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code from: https://forum.unity.com/threads/camera-rotates-with-the-object.879817/
public class Camera_Follow : MonoBehaviour
{
    public Transform Target;

    Vector3 offset;

    private void Start()
    {
        offset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        transform.position = Target.position + offset;
    }
}
