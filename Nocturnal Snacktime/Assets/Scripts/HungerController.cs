using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerController : MonoBehaviour
{
    public Slider hungerbar;

    public float hunger = 0;
    public Image filling;


    // Start is called before the first frame update
    void Start()
    {
        hungerbar.value = hunger;
        filling.color = Color.yellow;
        InvokeRepeating("FlashingBar", 1.0f, 0.03f);
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

    private void FlashingBar()
    {
        if (hunger >= 35)
        {
            if (filling.color == Color.yellow)
            {
                filling.color = Color.white;
            }
            else
            {
                filling.color = Color.yellow;
            }

        }
        else
        {
            filling.color = Color.yellow;
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
        hunger += 2.5f;
        hungerbar.value = hunger;
    }

    public void EatSnack()
    {
        hunger -= 20;
        hungerbar.value = hunger;
    }

}
