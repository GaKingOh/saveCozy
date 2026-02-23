using UnityEngine;

public class zkey : MonoBehaviour
{
    public GameObject Zkey;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.tag == "Player") Zkey.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Zkey.SetActive(false);
    }
}
