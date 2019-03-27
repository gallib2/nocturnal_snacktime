using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameNocturnalSnacktimeManager : MonoBehaviour
{
    public RoomLight roomLight;
    public Reciept recipe;
    public GameObject FinishLevelPanel;
    private bool isGameRunning = true;
    public AudioSource caughtsound;

    void Awake()
    {
        // This will keep the panel: "FinishLevelPanels" alive when we restart the level
        GameObject obj = GameObject.FindGameObjectWithTag("UI");
        DontDestroyOnLoad(obj);
    }

    private void Start()
    {
        recipe = recipe.GetComponent<Reciept>();
        roomLight = roomLight.GetComponent<RoomLight>();
    }

    private void Update()
    {
        bool toPauseGame = Input.GetKeyDown(KeyCode.P) && isGameRunning;
        bool toResumeGame = Input.GetKeyDown(KeyCode.P) && !isGameRunning;

        if (toPauseGame)
        {
            Time.timeScale = 0;
            isGameRunning = false;
            // SceneManager.LoadScene(1, LoadSceneMode.Additive);
        }

        if(toResumeGame)
        {
            Time.timeScale = 1;
            isGameRunning = true;
        }
    }

    private void OnEnable()
    {
        if (FinishLevelPanel != null)
        {
            FinishLevelPanel.SetActive(false);
        }

        PlayerMovement.OnArriveKitchen += CheckIfGameEnd;
        SliderManager.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        if(FinishLevelPanel != null)
        {
            FinishLevelPanel.SetActive(false);
        }

        PlayerMovement.OnArriveKitchen -= CheckIfGameEnd;
        SliderManager.OnGameOver -= GameOver;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver()
    {
        caughtsound.PlayOneShot(caughtsound.clip);
        const int secondToWait = 2;

        StartCoroutine(PresentGameOverMenuWithWaiting(secondToWait));
        roomLight.StartEndGameAnimation();
    }

    IEnumerator PresentGameOverMenuWithWaiting(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevel +1 > 3 ? 2 : currentLevel + 1;

        SceneManager.LoadScene(nextLevelIndex);
    }


    public void CheckIfGameEnd()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

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
