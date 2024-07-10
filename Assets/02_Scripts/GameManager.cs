using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject monsterPrefab;
    [SerializeField] private List<Transform> points = new List<Transform>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.Find("SpawnPointGroup")?.GetComponentsInChildren<Transform>(points);

        InvokeRepeating("CreateMonsters", 2.0f, 3.0f);
    }

    void CreateMonsters()
    {
        int idx = UnityEngine.Random.Range(1, points.Count);
        Instantiate(monsterPrefab, points[idx].position, Quaternion.identity);
    }
}
