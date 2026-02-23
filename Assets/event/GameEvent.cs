using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public abstract class GameEvent : MonoBehaviour
{
    public float duration = 10f;
    protected float timer;
    public bool IsActive { get ; private set; }

    public void Activate() // 실행 함수
    {
        if (IsActive) return;
        IsActive = true;
        timer = 0f;
        OnActivated();
    }

    public void Resolve() // 해결 전환 함수
    {
        if (IsActive) return;
        IsActive = false;
        OnResolved();
    }
    protected void Fail() // 실패 전환 함수
    {
        if(!IsActive) return;
        IsActive = false;
        OnFailed();
    }
    protected virtual void Update()
    {
        if (!IsActive) return;
        timer += Time.deltaTime;
        float ratio = Mathf.Clamp01(1f - timer / duration);
        OnTick(ratio);

        if (timer >= duration) Fail();
    }
    protected abstract void OnActivated(); // start 같은 함수
    protected abstract void OnTick(float ratio); // 매 프레임 실행하는 함수
    protected abstract void OnResolved();
    protected abstract void OnFailed();
}
