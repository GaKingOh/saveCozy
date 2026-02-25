using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class woodManager : MonoBehaviour
{
    bool wood1 = false;
    bool wood2 = false;
    bool wood3 = false;
    GameObject[] wood;
    GameObject target;
    public AudioSource audioSource;
    public AudioClip woodPutDown;

    public GameObject firePlaceEvent;
    void Start()
    {
        target = GameObject.Find("Canvas");
        wood = new GameObject[3];

        for (int i = 0; i < target.transform.childCount; i++)
        {
            wood[i] = target.transform.GetChild(i).gameObject;
        }
        audioSource.clip = woodPutDown;
    }
    void playSound()
    {
        audioSource.Play();
    }
    private void Update()
    {
    }
    public void wood1Set()
    {
        wood1 = true;
    }
    public void wood2Set()
    {
        wood2 = true;
    }
    public void wood3Set()
    {
        wood3 = true;
    }
    public void wood1Throw()
    {
        if (wood1)
        {
            playSound();
            firePlaceEvent.GetComponent<FireplaceEvent>().AddWood();
            wood[0].SetActive(false);
            wood1 = false;
        }
    }
    public void wood2Throw()
    {
        if (wood2)
        {
            playSound();
            firePlaceEvent.GetComponent<FireplaceEvent>().AddWood();
            wood[1].SetActive(false);
            wood2 = false;
        }
    }
    public void wood3Throw()
    {
        if (wood3)
        {
            playSound();
            firePlaceEvent.GetComponent<FireplaceEvent>().AddWood();
            wood[2].SetActive(false);
            wood3 = false;
        }
    }
}
