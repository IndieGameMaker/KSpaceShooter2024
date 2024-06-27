using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform firePos;  // 총알이 생성될 위치정보
    [SerializeField] private GameObject bulletPrefab;  // 총알 프리팹

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // 총알을 동적으로 생성
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        }
    }
}
