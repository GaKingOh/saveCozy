using UnityEngine;
using UnityEngine.UIElements;

public class windowCheck : MonoBehaviour
{
    public CapsuleCollider2D playerCol;
    public GameObject windowEvent;
    bool player = false;

    private void Update()
    {
        if (!playerCol.IsTouching(gameObject.GetComponent<BoxCollider2D>())) return;
        if (Input.GetKeyDown(KeyCode.G) && player)
        {
           windowEvent.GetComponent<windowEvent>().Resolve();
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
