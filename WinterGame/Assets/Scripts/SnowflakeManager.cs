using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SnowflakeManager : MonoBehaviour
{
    public static int snowflakes;
    public TextMeshProUGUI snowText;
    public TextMeshProUGUI snowText2; //game over screen
    public TextMeshProUGUI iciclesText;
    public static int icicles;
    public static AudioSource source;
    private static bool threeHundred;
    private static bool sixHundred;

    // Start is called before the first frame update
    void Start()
    {
      snowflakes = 0;
      icicles = 0;
        source = gameObject.GetComponent<AudioSource>();
        threeHundred = false;
        sixHundred = false;
    }

    // Update is called once per frame
    void Update()
    {
      snowText.text = snowflakes.ToString();
      snowText2.text = snowflakes.ToString();
      iciclesText.text = icicles.ToString();
    }

    public static void playPickupSound() {
        source.PlayOneShot(source.clip);
    }

    public static void changeSnow(int num) //connect this to gameplay later
    {
      snowflakes += num;
      if (!threeHundred)
      {
        if(snowflakes >= 300){
          TemperatureManager.changeTemp(-15);
          threeHundred = true;
        }
      }
      if (!sixHundred)
      {
        if(snowflakes >= 600){
          TemperatureManager.changeTemp(-15);
          sixHundred = true;
        }
      }
    }

    public static void AddIcicle()
    {
      icicles++;
    }

    public static void RemoveIcicle()
    {
      icicles--;
    }

    public void ResetSnowflakes()
    {
      snowflakes = 0;
      icicles = 0;
    }
}
