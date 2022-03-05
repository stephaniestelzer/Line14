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
    public TextMeshProUGUI snowText3; //you won screen

    // Start is called before the first frame update
    void Start()
    {
      snowflakes = 0;
    }

    // Update is called once per frame
    void Update()
    {
      snowText.text = "Snowflakes: " + snowflakes ;
      snowText2.text = snowflakes.ToString();
      snowText3.text = snowflakes.ToString();
    }

    public static void changeSnow(int num) //connect this to gameplay later
    {
      snowflakes += num;
      if(snowflakes == 300){
        TemperatureManager.changeTemp(-15);
      }
      if(snowflakes == 600){
        TemperatureManager.changeTemp(-15);
      }
    }

    public void ResetSnowflakes()
    {
      snowflakes = 0;
    }
}
