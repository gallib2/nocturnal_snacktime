using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Exit Game...");
        Application.Quit();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }
}
