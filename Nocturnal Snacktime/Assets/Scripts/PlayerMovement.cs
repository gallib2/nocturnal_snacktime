using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Slider noisebar;
    public Slider hungerbar;
    public float moveSpeed;
    public float diagonalMoveModifier;
    public bool isRunning = false;
    private float currentSpeed;
    public float noise = 0;
    public float hunger = 0;

    public float cook1 = 0;
    bool cooking1 = false;

    bool food1 = false;
    bool food2 = false;

    // Use this for initialization
    void Start()
    {
        noisebar.value = noise;
        hungerbar.value = hunger;
        InvokeRepeating("GetHungry", 2.0f, 2.0f);
        InvokeRepeating("QuietDown", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Lose the game
        if (noise >= 50 || hunger >= 50)
        {
            SceneManager.LoadScene(0);
        }


        //If the player is holding down the Run button, he will run
        if (Input.GetButtonDown("Run"))
        {
            isRunning = true;
        }
        //Else, he will walk
        else if (Input.GetButtonUp("Run"))
        {
            isRunning = false;
        }

        //Walk
        if (isRunning == false)
        {
            float moveHorizontal = Input.GetAxis("Horizontal") * currentSpeed * Time.deltaTime;
            float moveVertical = Input.GetAxis("Vertical") * currentSpeed * Time.deltaTime;
            transform.Translate(new Vector3(moveHorizontal, moveVertical));
        }
        //Run
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal") * (currentSpeed + 3) * Time.deltaTime;
            float moveVertical = Input.GetAxis("Vertical") * (currentSpeed + 3) * Time.deltaTime;
            transform.Translate(new Vector3(moveHorizontal, moveVertical));
        }

        //If moving diagonal, move at lower speed (modifier is changed in inspector)
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            currentSpeed = moveSpeed * diagonalMoveModifier;
        }
        else
        {
            currentSpeed = moveSpeed;
        }


        //If you hold the interact button to cook (need to add a condition where you are close to the object being cooked)
        if (Input.GetButton("Interact"))
        {
            cook1 = Mathf.PingPong(Time.time * 7, hungerbar.maxValue);
            hungerbar.value = cook1;
            cooking1 = true;
        }
        else if ((cook1 < 3 || cook1 > 7) && (cooking1 == true))
        {
            noise += 30;
            noisebar.value = noise;
            cooking1 = false;
            cook1 = 0;
            hungerbar.value = cook1;
        }
        else if ((cook1 > 3 || cook1 < 7) && (cooking1 == true))
        {
            food1 = true;
            cooking1 = false;
            Debug.Log("Cooked!");
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            noise += 10;
            noisebar.value = noise;
        }

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
    }

    //Increase hunger over time
    //void GetHungry()
    //{
    //    hunger += 5;
    //    hungerbar.value = hunger;
    //}

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
