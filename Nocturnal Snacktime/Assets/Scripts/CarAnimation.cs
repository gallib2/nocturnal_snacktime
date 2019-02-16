using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimation : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isTouchCar", false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("OnCollisionEnter2D CAR");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Insert IF CAR Collision");
            animator.SetBool("isTouchCar", true);
        }
    }
}
