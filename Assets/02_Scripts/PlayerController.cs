using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
        외부 입력장치 값 받아오기 

        1. InputManager (Legacy)
        2. InputSystem (new)
    */
    [SerializeField]
    [Range(5, 15)]
    private float moveSpeed = 6.0f;

    [SerializeField]
    private float turnSpeed = 200.0f;

    private float v;
    private float h;
    private float r;

    private Animator animator;

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        r = Input.GetAxis("Mouse X"); // - / +

        MoveAndRotate();
        PlayerAnim();
    }

    private void PlayerAnim()
    {
        animator.SetFloat("forward", v);
        animator.SetFloat("strafe", h);
    }

    private void MoveAndRotate()
    {
        // 이동방향을 계산 : 벡터의 덧셈 연산
        // 벡터의 크기를 1로 변환
        // 벡터의 정규화 , Vector Normalized
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r);
    }
}


/*
    Vector3.forward = new Vector3(0, 0, 1)
    Vector3.up      = new Vector3(0, 1, 0)
    Vector3.right   = new Vector3(1, 0, 0)

    Vector3.one     = new Vector3(1, 1, 1)
    Vector3.zero    = new Vector3(0, 0, 0)
*/