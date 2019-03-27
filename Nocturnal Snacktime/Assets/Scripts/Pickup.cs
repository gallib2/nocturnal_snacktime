using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    public GameObject pickupEffect;

    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("enter trigerrrrr ");

        Debug.Log("other. is: " + other.tag);

        if(other.CompareTag("Player"))
        {
            Debug.Log("inside if other Player ");
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    // Item can be added to inventory
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    inventory.ingredients[i] = itemButton;
                    Instantiate(pickupEffect, gameObject.transform.position, gameObject.transform.rotation);
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
