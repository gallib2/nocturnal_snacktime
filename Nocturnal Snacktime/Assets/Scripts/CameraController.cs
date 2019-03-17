using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Animator animator;
    public Animation anim;

    float shakeAmount = 0;

    public GameObject followTarget;
    private Vector3 targetPosition;
    public float moveSpeed;

    private void Awake()
    {
        //animator = GetComponent<Animator>();
        //animator.SetBool("isGameStart", true);

        //anim = GetComponent<Animation>();


    }

    private void Start()
    {
        //anim.Play();

        //animator = GetComponent<Animator>();
        //animator.SetBool("isGameStart", true);
    }

    // Update is called once per frame
    void Update()
    {
       //Debug.Log("is animation playing " + anim.isPlaying);

        //if(!anim.isPlaying)
        //{
            //animator.SetBool("isGameStart", false);
            targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
       // }
    }

    private void OnEnable()
    {
        PlayerMovement.OnTouchedObstacle += Shake;
        Debug.Log("Signed to event");
    }

    private void OnDisable()
    {
        PlayerMovement.OnTouchedObstacle -= Shake;
    }

    //Shake camera and then stop
    public void Shake()
    {
        shakeAmount = 0.25f;
        InvokeRepeating("BeginShake", 0, 0.01f);
        Invoke("StopShake", 0.1f);
        Debug.Log("Shook!");
    }

    //Camera shake function
    void BeginShake()
    {
        if (shakeAmount > 0)
        {
            Vector3 camPos = gameObject.transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;
            camPos.x += offsetX;
            camPos.y += offsetY;
            gameObject.transform.position = camPos;
        }
    }

    //Stop the camera shake an put camera back on player
    void StopShake()
    {
        CancelInvoke("BeginShake");
        gameObject.transform.position = targetPosition;
    }
}
