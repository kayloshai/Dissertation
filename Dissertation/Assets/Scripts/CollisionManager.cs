using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public Sphere sphere;
    public List<Sphere> spheres = new List<Sphere>();

    public int squared(int num) { return num * num; }
    public bool Check_Collision(List<Sphere> _spheres)
    {
        int distance = (int)Mathf.Abs(Mathf.Sqrt(squared(Mathf.RoundToInt(_spheres[0].worldPosition.x - _spheres[1].worldPosition.x))) +
                                      Mathf.Sqrt(squared(Mathf.RoundToInt(_spheres[0].worldPosition.y - _spheres[1].worldPosition.y))));
        distance -= Mathf.RoundToInt(_spheres[0].radius);
        distance -= Mathf.RoundToInt(_spheres[1].radius);

        if (distance <= 0)
            return true;
        return false;
    }
}
