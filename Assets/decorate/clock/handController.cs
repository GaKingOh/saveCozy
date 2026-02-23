using UnityEngine;

public class handController : MonoBehaviour
{
    public float timeLimit = 60f;   // 한 바퀴 도는 시간
    float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        float angle = (elapsedTime / timeLimit) * 360f;

        // 🔥 10도 단위로 스냅
        angle = Mathf.Round(angle / 10f) * 10f;

        transform.rotation = Quaternion.Euler(0f, 0f, -angle);
    }
}
