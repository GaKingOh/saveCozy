using UnityEngine;

public class foot : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 0.5f;

    [Header("Area 제한")]
    public Collider2D walkAreaCollider;      // “안에서만 걸을 수 있는” 영역 콜라이더
    public CircleCollider2D footCollider;    // 플레이어 발(원) 콜라이더

    Rigidbody2D rb;
    Animator playerAni;
    SpriteRenderer sp;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAni = GameObject.Find("playerSprite").GetComponent<Animator>();
        sp = GameObject.Find("playerSprite").GetComponent<SpriteRenderer>();
        if (footCollider == null) footCollider = GetComponent<CircleCollider2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x != 0 || y != 0)
        {
            playerAni.SetBool("iswalk", true);
            if (x > 0) sp.flipX = false;
            else if(x < 0) sp.flipX = true;
        }
        else
        {
            playerAni.SetBool("iswalk", false);
        }
            Vector2 input = new Vector2(x, y);
        if (input.sqrMagnitude > 1f) input.Normalize();

        Vector2 nextPos = rb.position + input * speed * Time.fixedDeltaTime * 0.5f;

        // ✅ 발 원이 "영역 콜라이더 안"에 완전히 포함되는지 검사
        if (IsCircleFullyInside(walkAreaCollider, nextPos, footCollider.radius, footCollider.offset))
        {
            rb.MovePosition(nextPos);
        }
        else
        {
            TrySlide(nextPos, input);
        }

    }

    bool IsCircleFullyInside(Collider2D area, Vector2 centerPos, float radius, Vector2 localOffset)
    {
        // 발 콜라이더 offset을 월드 좌표로 반영
        Vector2 worldCenter = centerPos + (Vector2)transform.TransformVector(localOffset);

        // 원의 여러 방향(8방향 + 중심)을 area가 모두 포함하면 "완전히 안"으로 간주
        Vector2[] dirs =
        {
            Vector2.zero,
            Vector2.right, Vector2.left, Vector2.up, Vector2.down,
            (Vector2.right + Vector2.up).normalized,
            (Vector2.left + Vector2.up).normalized,
            (Vector2.right + Vector2.down).normalized,
            (Vector2.left + Vector2.down).normalized
        };

        foreach (var d in dirs)
        {
            Vector2 p = worldCenter + d * radius;
            if (!area.OverlapPoint(p)) return false;
        }
        return true;
    }

    void TrySlide(Vector2 blockedNextPos, Vector2 input)
    {
        // 벽에 막히면 X만 / Y만 따로 시도해서 "벽 타고 움직이기" 느낌 주기
        Vector2 cur = rb.position;

        Vector2 tryX = new Vector2(blockedNextPos.x, cur.y);
        if (IsCircleFullyInside(walkAreaCollider, tryX, footCollider.radius, footCollider.offset))
        {
            rb.MovePosition(tryX);
            return;
        }

        Vector2 tryY = new Vector2(cur.x, blockedNextPos.y);
        if (IsCircleFullyInside(walkAreaCollider, tryY, footCollider.radius, footCollider.offset))
        {
            rb.MovePosition(tryY);
            return;
        }
        // 둘 다 안되면 정지
    }
}
