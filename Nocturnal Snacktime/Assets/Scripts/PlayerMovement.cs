using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Slider noisebar;
    public float moveSpeed;
    public float diagonalMoveModifier;
    public bool isRunning = false;
    private float currentSpeed;
    public float noise = 0;
    public float hunger = 0;

    // Use this for initialization
    void Start()
    {
        noisebar.value = noise;
    }

    // Update is called once per frame
    void Update()
    {
        //Lose the game
        if (noise >= 50)
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
}
