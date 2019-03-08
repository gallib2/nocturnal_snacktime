using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reciept : MonoBehaviour
{
    public Text recieptText;

    public Image[] recieptsItmes;
    public int recieptSize;

    private Vector2 initialPosition;

    //void Awake()
    //{
    //    DontDestroyOnLoad(this.gameObject);
    //}

    // Start is called before the first frame update
    void Start()
    {
        //recieptText.text = " 1 X Cheery";

        //initialPosition = new Vector2(-82, 100);
        //int offsetY = 6;

        //for (int i = 0; i < recieptsItmes.Length; i++)
        //{
        //   // recieptsItmes[i].transform.position = new Vector2(initialPosition.x, initialPosition.y + offsetY);
        //    Vector2 position = new Vector2(initialPosition.x, initialPosition.y + offsetY);
        //    Instantiate(recieptsItmes[i], position, Quaternion.identity);

        //    recieptsItmes[i].transform.parent = (gameObject.transform);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
