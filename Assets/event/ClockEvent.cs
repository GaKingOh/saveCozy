using UnityEngine;

public class ClockEvent : GameEvent
{
    public float minTimeLimit = 10f;
    public float maxTimeLimit = 20f;

    public GameObject clockHand;
    public GameObject timerBar;
    protected override void OnActivated()
    {
        duration = Random.Range(minTimeLimit, maxTimeLimit);
        clockHand.GetComponent<handController>().countDirection();

        timerBar.transform.GetChild(1).GetComponent<timerController>().setTime(duration);
        timerBar.SetActive(true);
        timerBar.transform.GetChild(1).GetComponent<timerController>().init();
    }
    protected override void OnTick(float ratio)
    {
        
    }
    protected override void OnResolved()
    {
        timerBar.SetActive(false);
        clockHand.GetComponent<handController>().countDirection();
    }
    protected override void OnFailed()
    {

    }
    protected override void Update()
    {
        if (!IsActive) return;
        timer+=Time.deltaTime;
        if (timer >= duration) Fail();
    }
}
