using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    // 싱글턴 인스턴스 선언
    public static GameManager instance = null;

    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private TMP_Text scoreText;

    private int score;
    public int Score
    {
        set
        {
            score += value;
            scoreText.text = $"score : <color=#00ff00>{score}</color>";
        }
    }

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

    void Awake()
    {
        // 간단한 사용방법 instance = this;

        // instance 변수가 할당되지 않았을 때
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        // 다른 씬으로 이동했을 때에도 삭제하지 않고 유지함
        DontDestroyOnLoad(this.gameObject);
    }

    void OnEnable()
    {
        //PlayerController.OnPlayerDie += () => IsGameOver = true;
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
