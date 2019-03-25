using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseController : MonoBehaviour
{
    public Slider noisebar;
    public Image filling;
    public float noise = 0;
    public bool IsTvOn = false;

    // Start is called before the first frame update
    void Start()
    {
        noisebar.value = noise;
        filling.color = Color.red;
        InvokeRepeating("FlashingBar", 1.0f, 0.03f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FlashingBar()
    {
        if (noise >= 35)
        {
            if (filling.color == Color.red)
            {
                filling.color = Color.white;
            }
            else
            {
                filling.color = Color.red;
            }
        }
        else
        {
            filling.color = Color.red;
        }
    }

    //Decrease noise over time
    public void QuietDown()
    {
        if (noise > 0 && IsTvOn == false)
        {
            noise -= 5.0f;
            noisebar.value = noise;
        }
    }

    //Any bumping into anything will generate noise. called in PlayerMovement on collision
    public void MakeSomeNoise(float n)
    {
        noise += n;
        noisebar.value = noise;
    }

    //Stepping will generate noise. stepping on carpet will generate less noise
    public void StepNoise(float n)
    {
        noise += 0.05f - n;
        noisebar.value = noise;
    }

    //Called in playermovement, repeats until controller is picked up. also prevent quieting down
    public void TVnoise()
    {
        IsTvOn = true;
        noise += 2f;
        noisebar.value = noise;
    }
}
