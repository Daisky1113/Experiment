using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

    Vector3 force;
    Vector3 acceleration;
    Vector3 velocity;
    
    private float mass;

    float maxSpeed = 1.0f;

	// Use this for initialization
	void Start () {
        force = Vector3.zero;
        acceleration = Vector3.zero;
        velocity = Vector3.zero;

        mass = 2.0f;
	}
	

    public void Move()
    {

        acceleration = force / mass;
        velocity += acceleration;

        // Time.deltaTimeが時間の最小単位
        // velocity は1frameで進む距離
        // 位置は速度 * 時間で出す
        gameObject.transform.position += ( velocity * Time.deltaTime);
        // 力を初期化
        force = Vector3.zero;
    }

    public void SlowDown(float ratio)
    {
        // F =MA
        ApplyForce(velocity * mass * -1.0f * ratio);
    }

    public void ApplyForce( Vector3 addForce)
    {
        force += addForce;
    }
    public void Reverse()
    {
        gameObject.transform.position -= (velocity * Time.deltaTime);
        velocity *= -1;
    }
}
