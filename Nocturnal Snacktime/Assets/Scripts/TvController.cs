using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvController : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayerMovement.OnTurnTvOn += StartBlink;
    }

    private void OnDisable()
    {
        PlayerMovement.OnTurnTvOn -= StartBlink;
    }

    public void StartBlink()
    {
        animator.SetBool("toBlink", true);
    }
}
