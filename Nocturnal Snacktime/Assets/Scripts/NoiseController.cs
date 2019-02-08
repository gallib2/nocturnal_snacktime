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
        InvokeRepeating("QuietDown", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Decrease noise over time
    void QuietDown()
    {
        if (noise > 0)
        {
            noise -= 2.0f;
            noisebar.value = noise;
        }
    }
}
