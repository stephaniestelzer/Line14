using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TemperatureManager : MonoBehaviour
{
    public static int temperature;
    public TextMeshProUGUI tempText;
    public TextMeshProUGUI tempText2; //game over screen
    // Start is called before the first frame update
    void Start()
    {
      temperature = 30;
    }

    // Update is called once per frame
    void Update()
    {
      tempText.text = temperature + "°C";
      tempText2.text = temperature + "°C";
    }

    public static void changeTemp(int num) //connect this to gameplay later
    {
      temperature += num;
      Debug.Log(temperature);
    }

    public void ResetTemperature()
    {
      temperature = 0;
    }
}
