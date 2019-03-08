using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackpack : MonoBehaviour
{
    public bool isMenuOpen = true;
    private GameObject[] menueItems;

    // Start is called before the first frame update
    void Start()
    {
        menueItems = GameObject.FindGameObjectsWithTag("MenuItem");

        CloseMenuItems();
    }

    public void OnMenuClicked()
    {
        if(isMenuOpen == true)
        {
            Debug.Log("close the menue");

            CloseMenuItems();
        }
        else
        {
            Debug.Log("menu open");

            for (int i = 0; i < menueItems.Length; i++)
            {
                menueItems[i].SetActive(true);
            }

            isMenuOpen = true;
        }
    }

    private void CloseMenuItems()
    {
        for (int i = 0; i < menueItems.Length; i++)
        {
            menueItems[i].SetActive(false);
        }

        isMenuOpen = false;
    }
}
