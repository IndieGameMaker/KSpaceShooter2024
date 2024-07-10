using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private List<Transform> points = new List<Transform>();

    private bool isGameOver = false;

    // 프로퍼티 정의
    public bool IsGameOver
    {
        get { return isGameOver; }
        set
        {
            isGameOver = value;
            if (isGameOver)
            {
                // CancelInvoke(nameof(CreateMonster));
                StopCoroutine(CreateMonsters());
            }
        }

    }

    void OnEnable()
    {
        PlayerController.OnPlayerDie += () => IsGameOver = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //getter => bool aaa = GameManager.IsGameOver;
        //setter => GameManager.IsGameOver = true;

        GameObject.Find("SpawnPointGroup")?.GetComponentsInChildren<Transform>(points);
        StartCoroutine(CreateMonsters());
        //InvokeRepeating(nameof(CreateMonsters), 2.0f, 3.0f);
    }

    IEnumerator CreateMonsters()
    {
        yield return new WaitForSeconds(2.0f);

        while (!isGameOver)
        {
            int idx = UnityEngine.Random.Range(1, points.Count);
            Instantiate(monsterPrefab, points[idx].position, Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }
    }
}
