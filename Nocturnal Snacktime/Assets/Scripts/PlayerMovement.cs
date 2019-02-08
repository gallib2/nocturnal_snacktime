using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public HungerController hungerController;
    public NoiseController noiseController;

    public float moveSpeed;
    public float diagonalMoveModifier;
    public bool isRunning = false;
    private float currentSpeed;

    // Use this for initialization
    void Start()
    {

        hungerController = hungerController.GetComponent<HungerController>();
        noiseController = noiseController.GetComponent<NoiseController>();
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
            noiseController.noise += 10;
            noiseController.noisebar.value = noiseController.noise;
        }

        if (other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
    }
}
