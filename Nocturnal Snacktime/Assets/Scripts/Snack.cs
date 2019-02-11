using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class Snack : MonoBehaviour
{
    public HungerController hungerController;
    public NoiseController noiseController;

    public bool hasSnack;
    public bool snackEaten;

//    private void Start()
//    {
//        snackStatus = hasSnack;
//        eatenStatus = snackEaten;
//    }
//    private void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.CompareTag("Player") && hasSnack == false)
//        {
//            hasSnack = true;
//        }
//    }

    private void Update()
    {

        //Pressing the "E" button will make the player open the snack pack and eat it
        if (Input.GetKeyDown(KeyCode.E) && hasSnack)
        {
            hasSnack = false;
            noiseController.noise += 20;
            noiseController.noisebar.value = noiseController.noise;
            hungerController.hunger -= 20;
            hungerController.hungerbar.value = hungerController.hunger;
            snackEaten = true;
        }

        if (snackEaten)
        {
            Invoke("resetSnack", 0.5f);
        }
    }

    private void resetSnack()
    {
        snackEaten = false;
    }
}


