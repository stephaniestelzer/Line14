using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    private GameObject self;
    public GameObject slime;
    public static bool showShadow;
    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject;
        GEvents.current.onDeathOne += onDeathOne;
        showShadow = false;
        self.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        self.transform.position = new Vector3(slime.transform.position.x, 17.43f,slime.transform.position.z); //hard coded height
    }

    private void onDeathOne(){
        Destroy(self);
    }

}
