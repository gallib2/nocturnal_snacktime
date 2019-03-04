using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAnimation : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsTvOn", false);
    }

    private void OnEnable()
    {
        PlayerMovement.OnTouchedTvController += CloseTV;
        PlayerMovement.OnTurnTvOn += OpenTv;
    }

    private void OnDisable()
    {
        PlayerMovement.OnTouchedTvController -= CloseTV;
        PlayerMovement.OnTurnTvOn -= OpenTv;
    }

    private void CloseTV()
    {
        Debug.Log("enter function CloseTV....");
        animator.SetBool("IsTvOn", false);
        Destroy(gameObject);
    }

    private void OpenTv()
    {
        Debug.Log("enter function OpenTv....");
        animator.SetBool("IsTvOn", true);
    }
}
