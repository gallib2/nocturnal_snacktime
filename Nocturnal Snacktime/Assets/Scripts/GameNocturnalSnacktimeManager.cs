using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNocturnalSnacktimeManager : MonoBehaviour
{
    Reciept reciept;
    public GameObject roomLight;

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
        PlayerMovement.OnTouchLightSwitch += LightTurnOn;
    }

    public void CheckIfGameEnd()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        reciept = reciept.GetComponent<Reciept>();

        Debug.Log("inentory " + inventory.slots.Length);
        Debug.Log("rec childs" + reciept.GetComponentsInChildren<GameObject>().Length);

    }

    private void LightTurnOn()
    {
        roomLight.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.2f); //Color.white;
    }



}
