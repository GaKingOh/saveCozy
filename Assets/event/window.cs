using UnityEngine;

public class window : GameEvent
{
    GameObject skull;
    Vector3 startPos;
    Vector3 targetPos;

    protected override void OnActivated()
    {
        skull = GameObject.Find("skull");

        if (skull == null) return;

        startPos = skull.transform.position;
        targetPos = startPos + new Vector3(0f, 0.05f, 0f);
    }

    protected override void OnTick(float ratio)
    {
        if (skull == null) return;
        float progress = 1f - ratio; // 0 -> 1
        skull.transform.position = Vector3.Lerp(startPos, targetPos, progress);
    }
    protected override void OnResolved()
    {
    //    throw new System.NotImplementedException();
    }

    protected override void OnFailed()
    {
    //    throw new System.NotImplementedException();
    }
}
