using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Boid))]
public class CollisionBehavior : MonoBehaviour
{

    private Boid boid;
    public float searchRadius;

    // Start is called before the first frame update
    void Start()
    {
        boid = GetComponent<Boid>();   
    }

    // Update is called once per frame
    void Update()
    {
        var boids = FindObjectsOfType<Boid>();
        var average = Vector3.zero;
        var found = 0;
        foreach (var boid in boids.Where(b => b != boid))
        {
            var diff = boid.transform.position - this.transform.position;
            if(diff.magnitude < searchRadius)
            {
                average += diff;
                found++;
            }
        }


        if (found > 0 && (Time.time % 10 < 5))
        {
            average = average / found;
            boid.velocity += (Vector3.Lerp(boid.velocity, average, average.magnitude / searchRadius));
        }


    }
}
