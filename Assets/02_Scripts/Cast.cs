using UnityEngine;

public class Cast : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f, 1 << 9))
            {
                Collider[] colls = Physics.OverlapSphere(hit.point, 10.0f, 1 << 9);
                foreach (var coll in colls)
                {
                    hit.collider.GetComponent<Rigidbody>().AddExplosionForce(1800.0f, hit.transform.position, 10.0f, 1500.0f);
                }
            }
        }
    }
}
