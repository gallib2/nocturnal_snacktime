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

        Debug.Log("reciept.recieptsItmes[0]: " + reciept.recieptsItmes[0].name);
        //Debug.Log("inventory.ingredients[0]: " + inventory.ingredients[0].name);
        //bool isEqual = inventory.ingredients[0].name == reciept.recieptsItmes[0].name;
        //Debug.Log("isEqual " + isEqual);

        // bool[] isCollectAll = new bool[reciept.recieptsItmes.Length];

        // List<bool> isCollectAll = new List<bool>();

        int counter = 0;

        foreach (GameObject ingredient in inventory.ingredients)
        {
            if (ingredient != null)
            {
                foreach (var recipeItem in reciept.recieptsItmes)
                {
                    if (recipeItem.name == ingredient.name)
                    {
                        // isCollectAll.Add(true);
                        counter++;
                        break;
                    }
                }
            }
        }

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
