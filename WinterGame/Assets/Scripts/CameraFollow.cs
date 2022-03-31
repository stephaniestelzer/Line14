using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code from: https://forum.unity.com/threads/camera-rotates-with-the-object.879817/
public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    Vector3 offset;

    bool shaking = false;
    Vector3 movement1 = new Vector3(0, 0.05f, 0.05f);
    Vector3 movement2 = new Vector3(0, -0.05f, -0.05f);
    Vector3 movement3 = new Vector3(0, 0.05f, -0.05f);
    int shakeFrame = 0;
    public int speed;

    private void Start()
    {
        //offset = transform.position - Target.position;
        offset = new Vector3(14.44f, 6.68f, 6.64f);
    }

    private void LateUpdate()
    {
        transform.position = Target.position + offset;

        if (shaking) {

            float transformFactor = shakeFrame % speed;

            if (shakeFrame < 1 * speed)
            {
                transform.position += (movement1 * transformFactor);
            }
            else if (shakeFrame < 2 * speed)
            {
                transformFactor = speed - transformFactor;
                transform.position += (movement1 * transformFactor);
            }

            else if (shakeFrame < 3 * speed)
            {
                transform.position += (movement2 * transformFactor);
            }
            else if (shakeFrame < 4 * speed)
            {
                transformFactor = speed - transformFactor;
                transform.position += (movement2 * transformFactor);
            }

            else if (shakeFrame < 5 * speed)
            {
                transform.position += (movement3 * transformFactor);
            }
            else if (shakeFrame < 6 * speed) {
                transformFactor = speed - transformFactor;
                transform.position += (movement3 * transformFactor);
            }

            else
            {
                shakeFrame = 0;
                shaking = false;
            }

            shakeFrame++;
            
        }

    }

    public void setShaking() {
        shaking = true;
    }
}
