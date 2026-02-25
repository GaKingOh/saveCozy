using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireplaceEvent : GameEvent
{
    public float minTimeLimit = 10f;
    public float maxTimeLimit = 15f;

    public SpriteRenderer flame;
    public Light2D fireLight;
    public AudioSource fireSound;

    float startLightIntensity;
    float startVolume;
    Color startColor;
    Vector3 startFlameScale;

    public GameObject timerBar;

    protected override void OnActivated()
    {
        // 이벤트마다 지속시간 랜덤
        duration = Random.Range(minTimeLimit, maxTimeLimit);

        startLightIntensity = fireLight.intensity;
        startVolume = fireSound.volume;
        startColor = flame.color;
        startFlameScale = flame.transform.localScale;

        flame.enabled = true;
        fireLight.enabled = true;
        if (!fireSound.isPlaying) fireSound.Play();

        timerBar.transform.GetChild(1).GetComponent<timerController>().setTime(duration);
        timerBar.SetActive(true);
        timerBar.transform.GetChild(1).GetComponent<timerController>().init();
    }

    protected override void OnTick(float ratio)
    {
        // 🔥 색 어두워짐
        flame.color = new Color(
            startColor.r * ratio,
            startColor.g * ratio,
            startColor.b * ratio,
            startColor.a
        );

        // 🔥 크기 줄어듦
        float minScale = 0.05f;
        float s = Mathf.Lerp(minScale, 1f, ratio);
        flame.transform.localScale = startFlameScale * s;

        // 💡 빛 감소
        fireLight.intensity = startLightIntensity * ratio;

        // 🔊 소리 감소
        fireSound.volume = startVolume * ratio;
    }

    protected override void OnResolved()
    {
        Debug.Log("아");
        flame.color = startColor;
        flame.transform.localScale = startFlameScale;
        fireLight.intensity = startLightIntensity;
        fireSound.volume = startVolume;
    }

    protected override void OnFailed()
    {
        // 실패(완전히 꺼짐)
        flame.enabled = false;
        fireLight.enabled = false;
        fireSound.Stop();

        // 여기서 “이상 현상 발생” 패널티 넣기 가능 (안정도 감소 등)
        // Debug.Log("Fireplace failed!");
    }

    // 플레이어 상호작용으로 해결시키고 싶으면 이렇게 호출
    public void AddWood()
    {
        Resolve(); 
        timerBar.SetActive(false); 
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