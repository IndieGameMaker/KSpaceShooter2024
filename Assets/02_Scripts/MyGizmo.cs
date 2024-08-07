using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    public Color _color = Color.green;
    public float _radius = 0.3f;

    void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
