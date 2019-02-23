using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNocturnalSnacktimeManager : MonoBehaviour
{
    public Reciept recipe;
    public GameObject FinishLevelPanel;

    void Awake()
    {
        // This will keep the panel: "FinishLevelPanels" alive when we restart the level
        GameObject obj = GameObject.FindGameObjectWithTag("UI");
        DontDestroyOnLoad(obj);
    }

    private void Start()
    {
        recipe = recipe.GetComponent<Reciept>();
    }

    private void OnEnable()
    {
        if (FinishLevelPanel != null)
        {
            FinishLevelPanel.SetActive(false);
        }

        PlayerMovement.OnArriveKitchen += CheckIfGameEnd;
        SliderManager.OnRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        if(FinishLevelPanel != null)
        {
            FinishLevelPanel.SetActive(false);
        }

        PlayerMovement.OnArriveKitchen -= CheckIfGameEnd;
        SliderManager.OnRestartGame -= RestartGame;
    }

    public void RestartGame()
    {
        //FinishLevelPanel.SetActive(false);
         SceneManager.LoadScene(0);
    }

    public void CheckIfGameEnd()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        // recipe = recipe.GetComponent<Reciept>();

        // counter for the equal items that in the ingredient and the recipe
        int counter = 0;

        // for every item in the ingredients (ingredients is what the player collected)
        // we check if the ingredient contained in the recipe.
        // if the ingredient contained, we increase the counter
        foreach (GameObject ingredient in inventory.ingredients)
        {
            if (ingredient != null)
            {
                foreach (var recipeItem in recipe.recieptsItmes)
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
        if(counter == recipe.recieptsItmes.Length)
        {
            Debug.Log("End Game is true!!!");
            if (FinishLevelPanel != null)
            {
                FinishLevelPanel.SetActive(true);
            }
        }
        else
        {
            Debug.Log("End Game is FALSE!!!");

        }
    }
}
