using UnityEngine;

public class handController : MonoBehaviour
{
    public float timeLimit = 60f;   // 한 바퀴 도는 시간
    float elapsedTime = 0f;
    int cw = -1;
   
    void Update()
    {
        elapsedTime += Time.deltaTime * cw;

        float angle = (elapsedTime / timeLimit) * 360f;
        angle = Mathf.Round(angle / 10f) * 10f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    public void countDirection()
    {
        cw *= -1;
    }
}
