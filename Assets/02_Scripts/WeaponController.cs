using System.Collections;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

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
        muzzleFlash.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            PlaySfx();
            StartCoroutine(ShowMuzzleFlash());
        }
    }

    private IEnumerator ShowMuzzleFlash()
    {
        // Texture Offset 변경
        // Random.Range(min, max)
        // 정수 Random.Range(0, 10);   0,1,2,3,...,9
        // 실수 Random.Range(0.0f, 10.0f);   0.0f ~ 10.0f
        // (0, 0), (0.5, 0), (0, 0.5), (0.5, 0.5)
        // Random.Range(0, 2) => (0, 1) * 0.5 => (0, 0.5)
        Vector2 offset = new Vector2(Random.Range(0, 2), Random.Range(0, 2)) * 0.5f;
        muzzleFlash.material.mainTextureOffset = offset;

        // Texture Scale 
        float scale = Random.Range(1.0f, 2.5f);
        muzzleFlash.transform.localScale = Vector3.one * scale;
        //new Vector3(scale, scale, scale);

        // Rotate MuzzleFlash
        float angle = Random.Range(0, 360);
        muzzleFlash.transform.localRotation = Quaternion.Euler(Vector3.forward * angle);

        muzzleFlash.enabled = true;

        yield return new WaitForSeconds(0.2f);

        muzzleFlash.enabled = false;
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
