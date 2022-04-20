using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//TO DO: Add Upper Bound
public class HiddenRoom : MonoBehaviour//Modelled after OnCollision
{
    public Transform poppi;
    void LateUpdate()
    {
        if (poppi.position.z >= (transform.position.z  -1))//-1 to disappear before you get there
        {
            if(poppi.position.y < 10)
            {
                //Debug.Log("Room Unlocked");
                Destroy(gameObject);
            }
        }
    }
}
