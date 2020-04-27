using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{

    public bool canCollide;
    public Vector3 worldPosition;
    public int sphereID = 0;
    public Color color;
    public float radius;
    public SphereCollider gameObject;
    public List<SphereCollider> spheres = new List<SphereCollider>();

    public Sphere(bool _canCollide, Vector3 _worldPosition, Color _color, float _radius)
    {
        this.canCollide = _canCollide;
        this.worldPosition = _worldPosition;
        this.sphereID++;
        this.color = _color;
        this.radius = _radius;
    }

    private void Start()
    {
        gameObject = GetComponent<SphereCollider>();
    }

    private void FixedUpdate()
    {
        gameObject.transform.position = worldPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(worldPosition, radius);
        Gizmos.color = (canCollide) ? Color.green : Color.gray;
    }
}

