using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    void OnCollisionEnter(Collision coll)
    {
        //if (coll.collider.tag == "BULLET")
        if (coll.collider.CompareTag("BULLET")) // GC 발생하지 않음.
        {
            Destroy(coll.gameObject);
        }
    }
}

/*
    Collider 컴포넌트의 IsTrigger 언체크

    OnCollisionEnter  => 1
    OnCollisionStay   => n
    OnCollisionExit   => 1

    Collider 컴포넌트의 IsTrigger 체크

    OnTriggerEnter
    OnTriggerStay
    OnTriggerExit

    # 충돌콜백함수가 호출되는 필수조건

     1. 양쪽 객체에 Collider 컴포넌트를 보유
     2. 이동하는 객체에는 반드시 Rigidbody 컴포넌트가 있어야 함

*/