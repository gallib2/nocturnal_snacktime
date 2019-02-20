using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SliderManager : MonoBehaviour
{
    public HungerController hungerController;
    public NoiseController noiseController;

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
    }
}
