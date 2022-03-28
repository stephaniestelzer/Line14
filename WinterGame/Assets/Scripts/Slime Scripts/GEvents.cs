using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEvents : MonoBehaviour
{
    public static GEvents current;

    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }

public event Action onDeathOne;

    public void DeathOne(Vector3 position)
    {
        BossEventHandle.position = position;
        if(onDeathOne != null)
        {
            onDeathOne();
        }
    }

public event Action onDeathTwo;

    public void DeathTwo(Vector3 position)
    {
        BossEventHandle.position = position;
        if(onDeathTwo != null)
        {
            onDeathTwo();
        }
    }

    public event Action onDeathThree;

    public void DeathThree(Vector3 position)
    {
        BossEventHandle.position = position;
        if(onDeathThree != null)
        {
            onDeathThree();
        }
    }

//boss takes damage
public event Action onDamageTick;

    public void DamageTick()
    {
        
        if(onDamageTick != null)
        {
            onDamageTick();
        }
    }

public event Action onWakeArea;

    public void WakeArea()
    {
        
        if(onWakeArea != null)
        {
            onWakeArea();
        }
    }

}
