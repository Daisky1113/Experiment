using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    Vector3 force;
    Vector3 acceleration;
    Vector3 velocity;

    public float mass;

	// Use this for initialization
	void Start () {
        mass = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {
        acceleration = force / mass;
        velocity += acceleration;
        gameObject.transform.position += velocity * Time.deltaTime;
        force = Vector3.zero;
    }

    public void Reverse()
    {
        velocity *= -1;
    }

    public void ApplyForce(Vector3 strength)
    {
        force = strength;
    }
}
