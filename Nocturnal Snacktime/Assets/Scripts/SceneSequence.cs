using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;

    public GameObject playerBubble;

    private void Awake()
    {
        playerBubble.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TheSequence());
    }

    IEnumerator TheSequence()
    {
        yield return new WaitForSeconds(7);
        Cam2.SetActive(true);
        Cam1.SetActive(false);
        playerBubble.SetActive(true);
    }

}
