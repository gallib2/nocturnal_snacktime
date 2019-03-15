using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public static event Action OnArriveKitchen;
    public static event Action OnTouchedTvController;
    public static event Action OnTurnTvOn;
    public static event Action OnTouchLightSwitch;
    public static event Action OnTouchedObstacle;
    public static event Action OnPlayerOutOfBedRoom;

    public HungerController hungerController;
    public NoiseController noiseController;
    public Slider cookingSlider;
    public Canvas toggleableCanvas;
    public Canvas timedCanvas;
    public AudioSource stepSource;
    public BangNoises bn;
    public Image redFlash;

    public GameObject playerBubble;

    public float moveSpeed;
    public float diagonalMoveModifier;
    bool isMoving = false;
    bool isRunning = false;
    private float currentSpeed;

    public float noiseInfluentRegular;
    public float noiseInfluentLight;

    public float cook1 = 0;
    bool cooking1 = false;
    bool inKitchen = false;

    // Use this for initialization
    void Start()
    {
        Destroy(timedCanvas, 10.0f);
        hungerController = hungerController.GetComponent<HungerController>();
        noiseController = noiseController.GetComponent<NoiseController>();

        noiseInfluentRegular = 10;
        noiseInfluentLight = 5;

        redFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //If moving, make stepping noises
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
          //  Debug.Log("Resume moving");
            stepSource.UnPause();
            CancelInvoke();
            isMoving = true;
        }
        else
        {
//            Debug.Log("Stopped moving");
            stepSource.Pause();
            InvokeRepeating("CallQuiet", 1.0f, 1.0f);
            isMoving = false;
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

        //If player is in the kitchen
        if (inKitchen == true)
        {
            //Cooking slider appears
            toggleableCanvas.enabled = true;

            //If player presses the cooking button
            if (Input.GetButton("Interact"))
            {
                cook1 = Mathf.PingPong(Time.time * 7, cookingSlider.maxValue);
                cookingSlider.value = cook1;
                cooking1 = true;
            }
            //If player lets go of the cooking button and fails to stop around center
            else if ((cook1 < 3 || cook1 > 7) && (cooking1 == true))
            {
                noiseController.MakeSomeNoise(30);
                cooking1 = false;
                cook1 = 0;
                hungerController.hungerbar.value = cook1;
            }
            //if player lets go of the cooking button and succeeds at stopping around center
            else if ((cook1 > 3 || cook1 < 7) && (cooking1 == true))
            {
                cooking1 = false;
                Debug.Log("Cooked!");
            }
        }
        //If the player is not in the kitchen, the cooking slider is invisible
        else
        {
            toggleableCanvas.enabled = false;
        }
    }

    private void CallQuiet()
    {
        //Debug.Log("Stopped moving, quieting down");
        noiseController.QuietDown();
    }

    IEnumerator Stepping(float n)
    {
        noiseController.StepNoise(n);
        yield return new WaitForSeconds(0.5f);
    }

    //Screen flashes red (called on collision)
    IEnumerator ScreenFlashRed()
    {
        Debug.Log("Should flash");
        redFlash.enabled = true;
        yield return new WaitForSeconds(0.1f);
        redFlash.enabled = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle" && OnTouchedObstacle != null)
        {
            noiseController.MakeSomeNoise(10);
            bn.MakeSomeNoise();
            StartCoroutine(ScreenFlashRed());
            OnTouchedObstacle();
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

        if (other.gameObject.tag == "Snack")
        {
            hungerController.EatSnack();
            Destroy(other.gameObject);
        }

        // if the player touch the TV controller
        if(other.gameObject.tag == "TvController")
        {
            // notify that the player touch the controller
            // the LightAnimation is listening to this event 
            // when we call this function the LightAnimation will 'close' the TV
            if(OnTouchedTvController != null)
            {
                OnTouchedTvController();
            }

            // destroy the TV controller
            noiseController.CancelInvoke("TVnoise");
            noiseController.IsTvOn = false;
            Destroy(other.gameObject);
        }

        // notify that the player touch the light switch
        // the Game Manager is listening to this event 
        // when we call this function the Game Manager will 'turn the light on'
        if (other.gameObject.tag == "LightSwitch")
        {
            OnTouchLightSwitch?.Invoke();

            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //if (other.tag == "Carpet" && isMoving == true)
        //{
        //    StartCoroutine(Stepping(0.01f));
        //}

        if (other.tag == "Floor" && isMoving == true)
        {
            StartCoroutine(Stepping(0));
        }       
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Goal1")
        {
            inKitchen = true;
        }

        if (other.tag == "TvOnCollider")
        {
            OnTurnTvOn?.Invoke();
            noiseController.InvokeRepeating("TVnoise", 1f, 2f);
            Destroy(other);
        }

        if (other.tag == "OutOfBedRoom")
        {
            OnPlayerOutOfBedRoom?.Invoke();
            playerBubble.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Goal1")
        {
            inKitchen = false;
        }
    }    
}
