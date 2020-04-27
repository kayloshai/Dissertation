using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    
    [Range(0, 10)]
    public int maxObjects;

    public List<GameObject> spheres = new List<GameObject>();
    public Vector3 worldPosition;
    public float radius;
    public Color color;
    public int sphereID = 0;

    public Object(Vector3 _position, float _radius) {
        worldPosition = _position;
        radius = _radius;
    }

    private void Start()
    {
        for (int i = 0; i < maxObjects; i++) {
            createSphere();
        }
    }

    void createSphere() {
        GameObject sphere = new GameObject("Sphere " + sphereID);
        Object sphereObj = new Object(pos(), 2.0f);
        sphere.transform.position = sphereObj.worldPosition;
        sphere.gameObject.AddComponent<SphereCollider>();
        sphere.gameObject.GetComponent<SphereCollider>().center = sphereObj.worldPosition;
        sphere.gameObject.GetComponent<SphereCollider>().radius = sphereObj.radius;
        spheres.Add(sphere);
        sphereID++;
    }

    Vector3 pos() {
        return new Vector3(Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f), Random.Range(1.0f, 10.0f));
    }
    private void OnDrawGizmos()
    {
        if (gameObject.GetComponent<SphereCollider>() == true) {
            Gizmos.DrawWireSphere(transform.position, radius);
            Gizmos.color = Color.green;
        }
    }
}
