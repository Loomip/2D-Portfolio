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

    //1. ������ // �ӵ�

    private IEnumerator RandomMove()
    {
        isMoving = true;

        yield return new WaitForSeconds(Random.Range(1f, 5f));
        animator.SetBool("isWalk", true);
        // ������ ���� ����
        rendemVector = (Random.insideUnitCircle * 3).normalized;
        // ������ ���� ���� �Ÿ�
        float moveDistance = 1f;
        Vector2 targetPosition = (Vector2)transform.position + rendemVector * moveDistance;

        while ((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(1f);
        animator.SetBool("isWalk", false);
        isMoving = false;
    }
    //2. �ڵ� ���� ��ġ �̵�
    //3. �ڵ����� �ö󰡴� ����ġ
    //4. �ִ� ���� �� ���� �ö󰡴� ����ġ
    //5. ���� ���� ������ ������������ ���� �ݴ�������� (���� ������ �ٸ� ��ġ��)
    //6. ��ġ �� ���� ���� �� ���� �� ��Ȯ

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
