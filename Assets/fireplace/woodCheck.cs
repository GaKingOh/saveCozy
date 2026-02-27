using UnityEngine;

public class woodCheck : MonoBehaviour
{
    public GameObject woodManager;
    public CapsuleCollider2D playerCol;
    // Update is called once per frame
    bool player = false; // 플레이어가 옆에 있는지 확인하는 변수
    void Update()
    {
        if (!playerCol.IsTouching(gameObject.GetComponent<BoxCollider2D>())) return;
        if (Input.GetKeyDown(KeyCode.Q) && player)
        {
            woodManager.GetComponent<woodManager>().wood1Throw();
        }
        else if (Input.GetKeyDown(KeyCode.W) && player)
        {
            woodManager.GetComponent<woodManager>().wood2Throw();
        }
        else if (Input.GetKeyDown(KeyCode.E) && player)
        {
            woodManager.GetComponent<woodManager>().wood3Throw();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            player = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            player = false;
        }
    }
}
