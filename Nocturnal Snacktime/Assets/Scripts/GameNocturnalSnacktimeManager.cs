using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNocturnalSnacktimeManager : MonoBehaviour
{
    Reciept reciept;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerMovement.OnArriveKitchen += CheckIfGameEnd;
    }

    public void CheckIfGameEnd()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        reciept = reciept.GetComponent<Reciept>();

        Debug.Log("inentory " + inventory.slots.Length);
        Debug.Log("rec childs" + reciept.GetComponentsInChildren<GameObject>().Length);

    }



}
