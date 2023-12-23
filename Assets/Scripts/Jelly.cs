using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    public int speed;
    public Vector2 rendemVector;
    public Animator animator;
    public Collider2D collider;
    private bool isMoving = false;

    //1. 움직임 // 속도

    private IEnumerator RandomMove()
    {
        isMoving = true;

        yield return new WaitForSeconds(Random.Range(1f, 5f));
        animator.SetBool("isWalk", true);
        // 랜덤한 방향 결정
        rendemVector = (Random.insideUnitCircle).normalized;
        // 랜덤한 방향 일정 거리
        float moveDistance = 3f;
        Vector2 targetPosition = (Vector2)transform.position + rendemVector * moveDistance;

        if (!isMoving)
        {
            animator.SetBool("isWalk", false);
            yield break; // 코루틴 종료
        }

        while ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime);
            yield return null;
        }
        animator.SetBool("isWalk", false);
        isMoving = false;
    }
    //3. 자동으로 올라가는 경험치
    //4. 최대 렙과 각 렙에 올라가는 경험치
    //5. 젤리 끼리 닿으면 스쳐지나가지 말고 반대방향으로 (벽에 닿으면 다른 위치로)

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Jelly"))
        {
            StopCoroutine(RandomMove());
            isMoving = false;
        }
    }

    //6. 터치 후 렙에 따른 돈 생성 및 수확

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        collider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!isMoving)
        {
            StartCoroutine(RandomMove());
        }
    }
}
