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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerMovement.OnTouchedTvController += CloseTV;
    }

    private void OnDisable()
    {
        PlayerMovement.OnTouchedTvController -= CloseTV;
    }

    private void CloseTV()
    {
        animator.SetBool("IsTvOn", false);
        Destroy(gameObject);
    }
}
