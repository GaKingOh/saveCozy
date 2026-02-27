using UnityEngine;

public class windowEvent : GameEvent
{
    public GameObject skull;
    public float minTimeLimit = 15f;
    public float maxTimeLimit = 15f;
    Vector3 startPos;
    Vector3 targetPos;
    bool moveStop = false;
    public GameObject timerBar;
    protected override void OnActivated()
    {
        if (skull.activeSelf) return;
        else skull.SetActive(true);
        Debug.Log("Çß´Ù!!");
        moveStop = false;
        duration = Random.Range(minTimeLimit, maxTimeLimit);
        startPos = skull.transform.position;
        targetPos = startPos + new Vector3(0f, 0.5f, 0f);

        timerBar.transform.GetChild(1).GetComponent<timerController>().setTime(duration);
        timerBar.SetActive(true);
        timerBar.transform.GetChild(1).GetComponent<timerController>().init();
    }

    protected override void OnTick(float ratio)
    {
        if (skull == null || moveStop) return;
        float progress = 1f - ratio;
        if (progress >= 1f)
        {
            moveStop = true;
            skull.transform.position = targetPos;
            return;
        }
        skull.transform.position = Vector3.Lerp(startPos, targetPos, progress);
    }
    protected override void OnResolved()
    {
        skull.transform.position = startPos;
        skull.SetActive(false);
        moveStop = true;
        timerBar.SetActive(false);
    }

    protected override void OnFailed()
    {
    //    throw new System.NotImplementedException();
    }
    protected override void Update()
    {
        if (!IsActive) return;
        timer += Time.deltaTime;
        float ratio = Mathf.Clamp01(1f - timer / duration);
        OnTick(ratio);

        if (timer >= duration) Fail();
    }
}
