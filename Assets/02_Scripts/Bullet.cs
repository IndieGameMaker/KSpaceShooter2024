using UnityEngine;

public class Bullet : MonoBehaviour
{
    //private Rigidbody rb;
    [SerializeField] private float force = 1500.0f;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
    }
}
