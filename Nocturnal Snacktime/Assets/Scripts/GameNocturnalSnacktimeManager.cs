using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNocturnalSnacktimeManager : MonoBehaviour
{
    public Reciept reciept;
    public GameObject roomLight;

    private void OnEnable()
    {
        PlayerMovement.OnArriveKitchen += CheckIfGameEnd;
        PlayerMovement.OnTouchLightSwitch += LightTurnOn;
    }

    public void CheckIfGameEnd()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        reciept = reciept.GetComponent<Reciept>();

        // counter for the equal items that in the ingredient and the recipe
        int counter = 0;

        // for every item in the ingredients (ingredients is what the player collected)
        // we check if the ingredient contained in the recipe.
        // if the ingredient contained, we increase the counter
        foreach (GameObject ingredient in inventory.ingredients)
        {
            if (ingredient != null)
            {
                foreach (var recipeItem in reciept.recieptsItmes)
                {
                    if (recipeItem.name == ingredient.name)
                    {
                        counter++;
                        break;
                    }
                }
            }
        }

        // if the counter is with the same size as the recipeItems,
        // that means we collected all
        if(counter == reciept.recieptsItmes.Length)
        {
            Debug.Log("End Game is true!!!");
        }
        else
        {
            Debug.Log("End Game is FALSE!!!");

        }
    }

    // turn the light of the house (the same color but with less alfa)
    private void LightTurnOn()
    {
        roomLight.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.2f);
    }

}
