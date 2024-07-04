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

    private WaitForSeconds ws;

    public bool isDie = false;

    void Start()
    {
        ws = new WaitForSeconds(0.3f);

        monsterTr = GetComponent<Transform>(); // monsterTr = transform;
        playerTr = GameObject.FindGameObjectWithTag("PLAYER")?.GetComponent<Transform>();

        if (playerTr == null)
        {
            Debug.LogError("플레이어가 없음");
        }

        StartCoroutine(CheckMonsterState());
        //StartCoroutine("CheckMonsterState");
    }

    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            switch (state)
            {
                case State.IDLE:
                    Debug.Log("IDLE");
                    break;

                case State.TRACE:
                    Debug.Log("추적 상태");
                    break;

                case State.ATTACK:
                    Debug.Log("공격 상태");
                    break;

                case State.DIE:
                    break;
            }

            yield return ws;
        }
    }

    IEnumerator CheckMonsterState()
    {
        while (isDie == false)
        {
            //float dist = Vector3.Distance(monsterTr.position, playerTr.position);
            float dist = (monsterTr.position - playerTr.position).sqrMagnitude;

            state = State.IDLE;

            // 추적 사정거리 이내일 경우
            if (dist <= traceDist * traceDist)
            {
                state = State.TRACE;
            }

            // 공격 사정거리 이내일 경우
            if (dist <= attackDist * attackDist)
            {
                state = State.ATTACK;
            }

            yield return ws;
        }
    }

}
