using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
        외부 입력장치 값 받아오기 

        1. InputManager (Legacy)
        2. InputSystem (new)
    */

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

        transform.Translate(Vector3.forward * 0.01f * v);
        transform.Rotate(Vector3.up * 100.0f * r);

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