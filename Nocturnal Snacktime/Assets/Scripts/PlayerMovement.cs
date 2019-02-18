using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static event Action OnArriveKitchen;
    public static event Action OnTouchedTvController;
    public static event Action OnTouchLightSwitch;

    public HungerController hungerController;
    public NoiseController noiseController;

    public float moveSpeed;
    public float diagonalMoveModifier;
    public bool isRunning = false;
    private float currentSpeed;

    public float noiseInfluentRegular;
    public float noiseInfluentLight;

    // Use this for initialization
    void Start()
    {
        hungerController = hungerController.GetComponent<HungerController>();
        noiseController = noiseController.GetComponent<NoiseController>();

        noiseInfluentRegular = 10;
        noiseInfluentLight = 5;
    }

    // Update is called once per frame
    void Update()
    {
    
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
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            noiseController.noise += noiseInfluentRegular;
            noiseController.noisebar.value = noiseController.noise;
        }

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }

        if (other.gameObject.tag == "Goal1")
        {
            Debug.Log("enter goal1");
            if (OnArriveKitchen != null)
            {
                Debug.Log("enter goal");
                OnArriveKitchen();
            }
        }

        // if the player touch the TV controller
        if(other.gameObject.tag == "TvController")
        {
            // destroy the TV controller
            Destroy(other.gameObject);

            // notify that the player touch the controller
            // the LightAnimation is listening to this event 
            // when we call this function the LightAnimation will 'close' the TV
            if(OnTouchedTvController != null)
            {
                OnTouchedTvController();
            }
        }

        // notify that the player touch the light switch
        // the Game Manager is listening to this event 
        // when we call this function the Game Manager will 'turn the light on'
        if (other.gameObject.tag == "LightSwitch")
        {
            Destroy(other.gameObject);

            if (OnTouchLightSwitch != null)
            {
                OnTouchLightSwitch();
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // the obstacleLight is the obstacles that makes less noise
        // for example: the carpets are 'ObstacleLight'.
        if (other.tag == "ObstacleLight")
        {
            noiseController.noise += noiseInfluentLight;
            noiseController.noisebar.value = noiseController.noise;
        }
    }
}
