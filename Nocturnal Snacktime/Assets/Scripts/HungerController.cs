using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerController : MonoBehaviour
{
    public Slider hungerbar;

    public float hunger = 0;


    // Start is called before the first frame update
    void Start()
    {
        hungerbar.value = hunger;
        InvokeRepeating("GetHungry", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Increase hunger over time
    void GetHungry()
    {
        hunger += 2;
        hungerbar.value = hunger;
    }

}
