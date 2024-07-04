using System.Collections;
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

    public bool isDie = false;

    void Start()
    {
        monsterTr = GetComponent<Transform>(); // monsterTr = transform;
        playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();

        if (playerTr == null)
        {
            Debug.LogError("플레이어가 없음");
        }

        StartCoroutine(CheckMonsterState());
        //StartCoroutine("CheckMonsterState");
    }

    IEnumerator CheckMonsterState()
    {
        while (isDie == false)
        {
            float dist = Vector3.Distance(monsterTr.position, playerTr.position);

            state = State.IDLE;

            // 공격 사정거리 이내일 경우
            if (dist <= attackDist)
            {
                state = State.ATTACK;
            }
            // 추적 사정거리 이내일 경우
            if (dist <= traceDist)
            {
                state = State.TRACE;
            }


            yield return new WaitForSeconds(0.3f);
        }
    }

}
