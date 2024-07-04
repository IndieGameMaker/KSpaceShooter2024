using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public enum State { IDLE, TRACE, ATTACK, DIE };

    [SerializeField] private State state;

    void Start()
    {

    }

    void Update()
    {

    }
}
