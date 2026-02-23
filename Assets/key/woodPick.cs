using UnityEngine;

public class woodPick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Sprite hereSprite;
    GameObject[] wood;
    GameObject target;
    GameObject woodManager;
    bool pick = false;
    void Start()
    {
        hereSprite = GetComponent<SpriteRenderer>().sprite;
        target = GameObject.Find("Canvas");
        wood = new GameObject[3];
        for (int i = 0; i < target.transform.childCount; i++)
        {
            wood[i] = target.transform.GetChild(i).gameObject;
        }

        woodManager = GameObject.Find("woodManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && pick)
        {
            if (hereSprite.name == "box1_0")
            {
                wood[0].SetActive(true);
                woodManager.GetComponent<woodManager>().wood1Set();
            }
            else if (hereSprite.name == "box2_0")
            {
                wood[1].SetActive(true);
                woodManager.GetComponent<woodManager>().wood2Set();
            }
        
            else if (hereSprite.name == "box3_0")
            {
                wood[2].SetActive(true);
                woodManager.GetComponent<woodManager>().wood3Set();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "Player") pick = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pick = false;
    }
}
