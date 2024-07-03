using System;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform firePos;  // 총알이 생성될 위치정보
    [SerializeField] private GameObject bulletPrefab;  // 총알 프리팹
    [SerializeField] private AudioClip fireSfx;  // 총소리 오디오 클립

    [SerializeField] private MeshRenderer muzzleFlash;

    private new AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzleFlash = firePos.GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            PlaySfx();
        }
    }

    private void PlaySfx()
    {
        audio.PlayOneShot(fireSfx, 0.8f);
    }

    private void Fire()
    {
        // 총알을 동적으로 생성
        Instantiate(bulletPrefab, firePos.position, firePos.rotation);
    }
}
