using UnityEngine;

public class PickSnack : MonoBehaviour
{
//    public GameObject snackThingy;
    private Snack snacky;

    // Start is called before the first frame update
    void Start()
    {
        snacky = GameObject.FindGameObjectWithTag("Player").GetComponent<Snack>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Hit snack");
            snacky.hasSnack = true;
            Destroy(gameObject);
        }
    }
}
