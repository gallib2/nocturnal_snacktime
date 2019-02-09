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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMenuClicked()
    {
        Debug.Log("enter the funcitons");

        if(isMenuOpen == true)
        {
            Debug.Log("close the menue");

            Debug.Log("num of items" + menueItems.Length);

            for (int i = 0; i < menueItems.Length; i++)
            {
                menueItems[i].SetActive(false);
            }

            isMenuOpen = false;
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
}
