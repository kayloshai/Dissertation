using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [HideInInspector]
    public const int maxSpheres = 10;
    public Sphere[] sphereArray = new Sphere[maxSpheres];
    
    [HideInInspector]
    public List<Color> colors = new List<Color>() {Color.green, 
                                                    Color.yellow, Color.blue, 
                                                    Color.white, Color.cyan,
                                                    Color.gray};
    public bool CheckCollision = false;
    public int numberOfSpheres = 2;

    private void Start(){
        if (numberOfSpheres > maxSpheres) { numberOfSpheres = maxSpheres; }
        drawSpheres(numberOfSpheres);
        /// <summary>
        /// Only is the tag is 'Sphere' will it add to the spheres list
        /// </summary>
        //if (gameObject.tag == "Sphere") {
        //    spheres.Add(GetComponent<GameObject>());
        //}
        //print(spheres.Count);
    }
    private void FixedUpdate(){
        if (CheckCollision){
            Check_Foreach(sphereArray);
        }
    }

    /// <summary>
    /// randomPosition will generate a random vector3 position in the scene for the object.
    /// </summary>
    /// <returns>new vector3</returns>
    Vector3 randomPosition() { return new Vector3(Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f), Random.Range(1.0f, 5.0f)); }

    /// <summary>
    /// randomRadius will generate a random float radius in the scene for the object.
    /// </summary>
    /// <returns>float radius</returns>
    float randomRadius() { return Random.Range(0.1f, 1.0f); }

    /// <summary>
    /// randomColor will generate a random number between 0 and the lengeth of the colors list.
    /// this number will choose the corisponding color in the list.
    /// </summary>
    /// <returns>int color</returns>
    Color randomColor() { return colors[Random.Range(0, colors.Count - 1)] ; }

    /// <summary>
    /// To help with computation usage, this function will take in a number and times it by its self and return the result.
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    float squared(double num) { return (float)(num * num); }

    public void drawSpheres(int numSpheres){
        for (int i = 0; i < numSpheres; i++){
            sphereArray[i] = new Sphere(randomPosition(), randomRadius(), "Sphere" + i, randomColor());//Create the sphere object
            sphereArray[i].sphere.AddComponent<SphereCollider>();
            sphereArray[i].sphere.GetComponent<SphereCollider>().center = sphereArray[i].position;
            sphereArray[i].sphere.GetComponent<SphereCollider>().radius = (float)sphereArray[i].radius;
        }
    }

    public void Check_Foreach(Sphere[] _sphereArray){
        for (int p = 0; p < _sphereArray.Length; p++){
            for (int q = 0; q < _sphereArray.Length; q++){
                if (q == p) { continue; }
                checkCollision(_sphereArray[p], _sphereArray[q]);
            }
        }
    }

    public bool checkCollision(Sphere s1, Sphere s2) {
        double distance, radii_sum;
        double distance_x = s1.position.x - s2.position.x;
        double distance_y = s1.position.y - s2.position.y;
        double distance_z = s1.position.z - s2.position.z;
        distance = Mathf.Sqrt(squared(distance_x) + (squared(distance_y) + squared(distance_z)));
        radii_sum = s1.radius + s2.radius;
        if (distance < radii_sum){
            s1.color = Color.black;
            s2.color = Color.black;
            return true;
        }
        return false;
    }
    private void OnDrawGizmos()
    {
        if (sphereArray == null) { return; }
        foreach (Sphere v in sphereArray)
        {
            Gizmos.color = v.color;
            Vector3 newPosition = v.position + v.sphere.transform.position;
            Gizmos.DrawWireSphere(newPosition, (float)v.radius);
        }
    }
}
