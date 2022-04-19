using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{

    public GameObject player;
    public CharacterController controller; //both of these defined in the inspector
    public GameObject winDialogue;

    private static int checkpoint;
    private static Vector3 lastCheckP;
    void Start()
    {
        checkpoint = 0;
        controller = player.GetComponent<CharacterController>();
        lastCheckP = new Vector3(0f,10f,-12f); //spawn
    }

    public static void Reset(){
        checkpoint = 0;
        lastCheckP = new Vector3(0f,10f,-12f); //spawn
    }

    void Update()
    {
        //cannot progress backwards
        if(checkpoint < 4 && player.transform.position.z > 692){
            lastCheckP = new Vector3(0f,9f,692f);
            checkpoint = 4;
            Debug.Log("Boss defeated");
            winDialogue.SetActive(true);
        }else if(checkpoint < 3 &&player.transform.position.z > 578f){
            lastCheckP = new Vector3(0f,20f, 578f);
            checkpoint = 3;
        }else if(checkpoint < 2 && player.transform.position.z > 365f){
            lastCheckP = new Vector3(0f,13.4f, 365f);
            checkpoint = 2;
        }else if(checkpoint < 1 && player.transform.position.z > 204.3){
            lastCheckP = new Vector3(0f,11f, 204.3f);
            checkpoint = 1;
        }


    if(player.transform.position.y < -5f){
        //checks which checkpoint you passed
        // if(checkpoint < 4 && player.transform.position.z > 692){
        //     lastCheckP = new Vector3(0f,9f,692f);
        //     checkpoint = 4;
        // }else if(checkpoint < 3 &&player.transform.position.z > 578f){
        //     lastCheckP = new Vector3(0f,20f, 578f);
        //     checkpoint = 3;
        // }else if(checkpoint < 2 && player.transform.position.z > 365f){
        //     lastCheckP = new Vector3(0f,13.4f, 365f);
        //     checkpoint = 2;
        // }else if(checkpoint < 1 && player.transform.position.z > 204.3){
        //     lastCheckP = new Vector3(0f,11f, 204.3f);
        //     checkpoint = 1;
        // }


        ToLastCheckPoint();
    }
    }

    void ToLastCheckPoint(){
                //Debug.Log("i fell!!!");
            switch(checkpoint){
                case 0 :
                    lastCheckP = new Vector3(0f,10f,-12f); //spawn
                break;
                case 1:
                    lastCheckP = new Vector3(0f,11f, 204.3f);
                break;
                case 2 :
                    lastCheckP = new Vector3(0f,13.4f, 365f);
                break;
                case 3:
                    lastCheckP = new Vector3(0f,20f, 578f);
                break;
                case 4 :
                    lastCheckP = new Vector3(0f,9f,692f);
                break;
            }


                controller.enabled = false;
                player.transform.position = lastCheckP;
                PlayerStats.Instance.TakeDamage(1, false);
                controller.enabled = true;
    }

}
