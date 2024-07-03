using System;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    private int hitCount;

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("BULLET"))
        {
            if (++hitCount == 3)
            {
                ExpBarrel();
            }
        }
    }

    private void ExpBarrel()
    {
        // Random Impact Position 
        Vector3 impactPoint = UnityEngine.Random.insideUnitSphere * 1.5f;

        var rb = this.gameObject.AddComponent<Rigidbody>();
        rb.AddExplosionForce(1500.0f, transform.position + impactPoint, 5.0f, 1800.0f);

        Destroy(this.gameObject, 2.5f);
    }
}
