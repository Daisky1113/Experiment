using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    Vector3 force;
    Vector3 acceleration;
    Vector3 velocity;

    public float mass;


    public void Move()
    {
        acceleration = force / mass;
        velocity += acceleration;
        gameObject.transform.position += velocity * Time.deltaTime;
        force = Vector3.zero;　//力を初期化
    }

    public Vector3 GetStrength()
    {
        return velocity * mass;
    }

    public void Breaking(float ratio)
    {
        ApplyForce(GetStrength() * ratio * -1);
    }

    public void Accelerate(float ratio)
    {
        ApplyForce(GetStrength() * ratio);
    }

    public void Reverse()
    {
        ApplyForce(GetStrength() * -2);
    }

    public void ApplyForce(Vector3 strength)
    {
        force = strength;
    }

    public void GetAttract(float G, GameObject attractor)
    {
        Vector3 dir = attractor.transform.position - gameObject.transform.position;
        float distance = dir.magnitude;
        float attractorMass = attractor.GetComponent<Mover>().mass;
        dir = dir.normalized;
        Vector3 strength = G * attractorMass * this.mass / (distance * distance) * dir;
        ApplyForce(strength);
    }
}
