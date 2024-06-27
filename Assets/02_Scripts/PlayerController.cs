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

    void Start()
    {
        Debug.Log("Hello World!");
    }

    void Update()
    {
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        r = Input.GetAxis("Mouse X"); // - / +

        // 이동방향을 계산 : 벡터의 덧셈 연산
        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
        transform.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        Debug.Log("moveDir=" + moveDir.magnitude);// 벡터의 길이
        Debug.Log("moveDir.normalized= " + moveDir.normalized.magnitude); // 크기를 1로 변경한 벡터의 길이


        // transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * v);
        // transform.Translate(Vector3.right * Time.deltaTime * moveSpeed * h);

        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r);

        //transform.position += new Vector3(0, 0, 0.01f) * v;
        //transform.position += Vector3.forward * 0.01f * v;
        // transform.(position) = transform.position + new Vector3(0, 0, 0.01f);
    }
}


/*
    Vector3.forward = new Vector3(0, 0, 1)
    Vector3.up      = new Vector3(0, 1, 0)
    Vector3.right   = new Vector3(1, 0, 0)

    Vector3.one     = new Vector3(1, 1, 1)
    Vector3.zero    = new Vector3(0, 0, 0)
*/