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

    void Start()
    {
        Debug.Log("Hello World!");
    }

    void Update()
    {
        v = Input.GetAxis("Vertical"); // -1.0f ~ 0.0f ~ +1.0f
        Debug.Log(v);
    }
}
