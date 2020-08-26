using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Boid))]
public class Bouncer : MonoBehaviour
{
    public float radius;
    public float knockBack;
    private Boid boid;
    // Start is called before the first frame update
    void Start()
    {
        boid = GetComponent<Boid>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boid.transform.position.magnitude > radius)
        {
            boid.velocity += this.transform.position.normalized * (radius - boid.transform.position.magnitude) * knockBack * Time.deltaTime;
        }
    }
}
