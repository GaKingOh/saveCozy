using UnityEngine;

public class timerController : MonoBehaviour
{
    public float cooltime = 3f;
    float timeCheck = 0f;

    public Transform mask;

    Vector3 startPos;
    float width;          // 이동 거리
    bool running = false;

    void Start()
    {
        startPos = mask.localPosition;

        // 현재 mask의 가로 크기 기준으로 이동 거리 계산
        width = mask.localScale.x;
    }

    void OnEnable()
    {
        // SetActive(true) 될 때마다 초기화
        ResetBar();
    }
    void ResetBar()
    {
        timeCheck = 0f;
        running = false;
        mask.localPosition = startPos;
    }
    public void setTime(float time)
    {
        cooltime = time;
    }
    public void init()
    {
        timeCheck = 0f;
        running = true;

        mask.localPosition = startPos; // 원위치
    }

    void Update()
    {
        if (!running) return;
        timeCheck += Time.deltaTime;

        float ratio = Mathf.Clamp01(timeCheck / cooltime);

        // 오른쪽 → 왼쪽으로 이동
        float moveAmount = width * ratio;

        mask.localPosition = new Vector3(
            startPos.x - moveAmount,
            startPos.y,
            startPos.z
        );

        if (ratio >= 1f)
            running = false;
    }
}