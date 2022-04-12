using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTint : MonoBehaviour
{

    int clock = 0;
    bool tinted = false;
    public int flashTime;
    Color[] originalColors;

    // Start is called before the first frame update
    void Start()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        originalColors = new Color[renderers.Length];
        for (int i = 0; i < renderers.Length; i++)
        {
            originalColors[i] = renderers[i].material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tinted) {
            if (clock == flashTime)
            {
                clock = 0;
                tinted = false;
                resetMaterials();
            }
            else {
                clock++;
            }
        }
    }

    public void onDamage() {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            Color color = renderers[i].material.color;
            float newR = tintOneColorChannel(color.r, 0.40f) + .2f;
            float newG = tintOneColorChannel(color.g, 0.10f);
            float newB = tintOneColorChannel(color.b, 0.10f);
            renderers[i].material.color = new Color(newR, newG, newB);
        }
        tinted = true;
        clock = 0;
    }

    private float tintOneColorChannel(float current, float tintFactor) {
        return current + (1 - current) * tintFactor;
    }


    private void resetMaterials() {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material.color = originalColors[i];
        }
    }
}
