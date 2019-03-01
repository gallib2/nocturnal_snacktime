using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLight : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayerMovement.OnTouchLightSwitch += LightTurnOn;
    }

    private void OnDisable()
    {
        PlayerMovement.OnTouchLightSwitch -= LightTurnOn;
    }

    // turn the light of the house (the same color but with less alfa)
    private void LightTurnOn()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.2f);
        // GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.2f);

    }

    public void StartEndGameAnimation()
    {
        animator.SetBool("isDead", true);
    }
}
