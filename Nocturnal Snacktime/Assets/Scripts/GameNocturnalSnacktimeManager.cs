using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNocturnalSnacktimeManager : MonoBehaviour
{
    public Reciept reciept;
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

        Debug.Log("num of items: " + reciept.recieptsItmes.Length);
    }

    // turn the light of the house (the same color but with less alfa)
    private void LightTurnOn()
    {
        roomLight.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.2f);
    }



}
