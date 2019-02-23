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
        GameObject obj = GameObject.FindGameObjectWithTag("UI");
        // GameObject[] objs = GameObject.FindGameObjectsWithTag("UI");

        //if (objs.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}

        DontDestroyOnLoad(obj);
         //DontDestroyOnLoad(obj);
        //FinishLevelPanel.SetActive(false);

        //if(FinishLevelPanel != null)
        //{
        //    DestroyImmediate(FinishLevelPanel, true);
        //}
    }

    private void Start()
    {
        recipe = recipe.GetComponent<Reciept>();

        //GameObject[] FinishLevelPanels = GameObject.FindGameObjectsWithTag("FinishLevelPanel");

        //Debug.Log("Length: " + FinishLevelPanels.Length);
        //FinishLevelPanel = FinishLevelPanel.GetComponent<GameObject>();
        //FinishLevelPanel.SetActive(false);
    }

    private void OnEnable()
    {
        PlayerMovement.OnArriveKitchen += CheckIfGameEnd;
        // PlayerMovement.OnTouchLightSwitch += LightTurnOn;
        SliderManager.OnRestartGame += RestartGame;
    }

    public void RestartGame()
    {
        //FinishLevelPanel.SetActive(false);
         SceneManager.LoadScene(0);

        //if (FinishLevelPanel != null)
        //{
        //    GameObject[] FinishLevelPanels = GameObject.FindGameObjectsWithTag("FinishLevelPanel");

        //    for (int i = 0; i < FinishLevelPanels.Length; i++)
        //    {
        //        FinishLevelPanels[i].SetActive(false);
        //    }

        //    if (FinishLevelPanels.Length == 0)
        //    {
        //        FinishLevelPanel.SetActive(false);
        //    }

        //    Debug.Log("closing popup menu....");
        //    //FinishLevelPanel.SetActive(false);
        //}

        //SceneManager.LoadScene()
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

            //if(FinishLevelPanel != null)
            //{
            //GameObject[] FinishLevelPanels = GameObject.FindGameObjectsWithTag("FinishLevelPanel");

            //for (int i = 0; i < FinishLevelPanels.Length; i++)
            //{
            //    FinishLevelPanels[i].gameObject.SetActive(true);
            //}

            //if(FinishLevelPanels.Length == 0)
            //{
            //    FinishLevelPanel.SetActive(true);
            //}

            //FinishLevelPanel.SetActive(true);
            //}
            //if(FinishLevelPanel == null)
            //{
            //    GameObject x = Instantiate(FinishLevelPanel, FinishLevelPanel.transform, true);
            //    x.SetActive(true);
            //}
            //else
            //{
            //    FinishLevelPanel.SetActive(true);
            //}
        }
        else
        {
            Debug.Log("End Game is FALSE!!!");

        }
    }

    public void CloseFinishMenu()
    {
        //FinishLevelPanel.SetActive(false);
    }

}
