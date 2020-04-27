using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere {
    [HideInInspector]
    public GameObject sphere;
    public Vector3 position;
    [HideInInspector]
    public double radius;
    [HideInInspector]
    public string name;
    [HideInInspector]
    public Color color;

    public Sphere(Vector3 position, double radius, string name, Color color) {
        sphere = new GameObject(name)
        {
            tag = "Sphere"//Add the tag sphere to the object
        };
        this.name = name;
        this.position = position;
        this.radius = radius;
        this.color = color;
    }
}
