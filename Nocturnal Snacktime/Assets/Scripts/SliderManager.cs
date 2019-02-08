using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SliderManager : MonoBehaviour
{
    public HungerController hungerController;
    public NoiseController noiseController;

    public float cook1 = 0;
    bool cooking1 = false;

    bool food1 = false;
    bool food2 = false;

    // Start is called before the first frame update
    void Start()
    {
        hungerController = hungerController.GetComponent<HungerController>();
        noiseController = noiseController.GetComponent<NoiseController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Lose the game
        if (noiseController.noise >= 50 || hungerController.hunger >= 50)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetButton("Interact"))
        {
            cook1 = Mathf.PingPong(Time.time * 7, hungerController.hungerbar.maxValue);
            hungerController.hungerbar.value = cook1;
            cooking1 = true;
        }
        else if ((cook1 < 3 || cook1 > 7) && (cooking1 == true))
        {
            noiseController.noise += 30;
            noiseController.noisebar.value = noiseController.noise;
            cooking1 = false;
            cook1 = 0;
            hungerController.hungerbar.value = cook1;
        }
        else if ((cook1 > 3 || cook1 < 7) && (cooking1 == true))
        {
            food1 = true;
            cooking1 = false;
            Debug.Log("Cooked!");
        }
    }
}
