using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public enum State { IDLE, TRACE, ATTACK, DIE };

    [SerializeField] private State state;
    // 공격 사정거리
    [SerializeField] private float attackDist = 2.0f;
    // 추적 사정거리
    [SerializeField] private float traceDist = 10.0f;

    private Transform monsterTr;
    private Transform playerTr;

    void Start()
    {
        monsterTr = GetComponent<Transform>(); // monsterTr = transform;
        playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();

        if (playerTr == null)
        {
            Debug.LogError("플레이어가 없음");
        }
    }

    void Update()
    {

    }
}
