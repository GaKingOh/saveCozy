using UnityEngine;

public class eventController : MonoBehaviour
{
    public GameObject fireplace;
    public GameObject window;
    public GameObject clock;

    float Eventinterveral = 10f;
    float timecheck = 0;
    windowEvent windowEvent;
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
            if (Eventinterveral > 5) Eventinterveral -= 0.5f;
            int eventIdx = Random.Range(0, 3);
            Debug.Log("event idx : " + eventIdx);
            if (eventIdx == 0) fireplace.GetComponent<FireplaceEvent>().Activate();
            else if(eventIdx==1) window.GetComponent<windowEvent>().Activate();
            else if(eventIdx==2) clock.GetComponent<ClockEvent>().Activate();
        }
     //   windowEvent.Activate();
    }


}
