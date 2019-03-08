using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseController : MonoBehaviour
{
    public Slider noisebar;
    public float noise = 0;

    // Start is called before the first frame update
    void Start()
    {
        noisebar.value = noise;       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Decrease noise over time
    public void QuietDown()
    {
        if (noise > 0)
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
}
