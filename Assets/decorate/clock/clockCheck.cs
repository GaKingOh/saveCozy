using UnityEngine;

public class clockCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public CapsuleCollider2D playerCol;
    public GameObject clockEvent; 
    bool player = false;
    // Update is called once per frame
    void Update()
    {
        if (!playerCol.IsTouching(gameObject.GetComponent<BoxCollider2D>())) return;
        if(Input.GetKeyDown(KeyCode.G) && player)
        {
            clockEvent.GetComponent<ClockEvent>().Resolve();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player = false;
        }
    }
}
