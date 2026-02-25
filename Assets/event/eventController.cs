using UnityEngine;

public class eventController : MonoBehaviour
{
    public GameObject fireplace;
    public GameObject window;
    public GameObject clock;

    float Eventinterveral = 10f;
    float timecheck = 0;
    window windowEvent;
    private void Start()
    {
        
    }
    private void Update()
    {
        timecheck += Time.deltaTime;
    //    Debug.Log(timecheck);
        if(timecheck - Eventinterveral >0)
        {
            timecheck = 0;

            int idx = 1;
            if (idx == 0) fireplace.GetComponent<FireplaceEvent>().Activate();
            else if(idx==1) window.GetComponent<window>().Activate();
        }
     //   windowEvent.Activate();
    }

}
