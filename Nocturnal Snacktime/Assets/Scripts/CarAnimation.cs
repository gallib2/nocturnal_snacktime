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
        // if the player touch the car, start the animation of the car
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("isTouchCar", true);
        }
    }
}
