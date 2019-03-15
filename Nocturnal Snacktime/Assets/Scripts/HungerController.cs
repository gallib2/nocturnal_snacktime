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
        //InvokeRepeating("GetHungry", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Make sure you dont hit negative hunger by eating snack
        if (hunger < 0)
        {
            hunger = 0;
        }
    }

    private void OnEnable()
    {
        PlayerMovement.OnPlayerOutOfBedRoom += StartHungerBar;
    }

    private void OnDisable()
    {
        PlayerMovement.OnPlayerOutOfBedRoom -= StartHungerBar;
    }

    void StartHungerBar()
    {
        InvokeRepeating("GetHungry", 2.0f, 2.0f);
    }

    // Increase hunger over time
    void GetHungry()
    {
        hunger += 5;
        hungerbar.value = hunger;
    }

    public void EatSnack()
    {
        hunger -= 20;
        hungerbar.value = hunger;
    }

}
