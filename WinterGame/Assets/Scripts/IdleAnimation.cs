using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimation : MonoBehaviour
{
    private bool movingUp = true;
    private float startingY;
    public float speed;

    void Start()
    {
        startingY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        gameObject.transform.Rotate(new Vector3(0, 1, 0), speed);

        // Translation
        if (movingUp) {
            gameObject.transform.Translate(new Vector3(0, speed / 250, 0));
        }
        else {
            gameObject.transform.Translate(new Vector3(0, -speed / 250, 0));
        }

        if (transform.position.y >= startingY + 0.25) {
            movingUp = false;
        }
        if (transform.position.y <= startingY) {
            movingUp = true;
        }

    }
}
