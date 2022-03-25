/*Code via Alexander Zotov w/ updates from
Stephanie Stelzer */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnvironmentManager : MonoBehaviour
{
    [SerializeField]
    private GameObject platform;

    // list of all possible textures
    [SerializeField]
    private Texture[] textures;

    private Renderer platformRenderer;

    private int textureIndex;
    // Start is called before the first frame update
    void Start()
    {
        platformRenderer = platform.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int temp = TemperatureManager.temperature;
        if(temp == 30){
            platformRenderer.sharedMaterial.mainTexture = textures[0];
        }
        if(temp == 15){
            platformRenderer.sharedMaterial.mainTexture = textures[1];
        }
    }
}
