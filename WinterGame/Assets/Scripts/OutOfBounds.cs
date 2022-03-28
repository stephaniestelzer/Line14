using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    public GameObject player;
    public CharacterController controller; //both of these defined in the inspector


    //int checkpoint;
    private static Vector3 lastCheckP;
    void Start()
    {
        //checkpoint = 0;
        controller = player.GetComponent<CharacterController>();
        lastCheckP = new Vector3(0f,10f,-12f); //spawn
    }

    public static void Reset(){
        lastCheckP = new Vector3(0f,10f,-12f); //spawn
    }
    
    void Update()
    {
        //this seems wasteful to me, but for animations later might be needed
    // if(player.transform.position.z > 205f){
    //     //light the igloo up!
        
    // }else if(player.transform.position.z > 205f){

    // }


    if(player.transform.position.y < -15f){
        //checks which checkpoint you passed
        if(player.transform.position.z > 692){
            lastCheckP = new Vector3(0f,9f,692f);
        }else if(player.transform.position.z > 578f){
            lastCheckP = new Vector3(0f,20f, 578f);
        }else if(player.transform.position.z > 365f){
            lastCheckP = new Vector3(0f,13.4f, 578f);
        }else if(player.transform.position.z > 204.3){
            lastCheckP = new Vector3(0f,11f, 578f);
        }
        ToLastCheckPoint();
    }
    }

    void ToLastCheckPoint(){
                //Debug.Log("i fell!!!");
                //player.GetComponent<Rigidbody>().velocity = new Vector3(0f,0f,0f);
                controller.enabled = false;
                player.transform.position = lastCheckP;
                PlayerStats.Instance.TakeDamage(1);
                controller.enabled = true;
    }

}
