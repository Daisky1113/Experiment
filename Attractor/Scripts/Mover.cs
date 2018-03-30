using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    // Use this for initialization
    private float mass;
    Vector3 direction;
    Vector3 acceleration;
    Vector3 velocity;
    private Vector3 force;


	void Start () {
        direction = gameObject.transform.position.normalized * -1;
        acceleration = Vector3.zero;
        velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 location = gameObject.transform.position;

        if (location.magnitude < 0.01f || location.magnitude > 20.0f)
        {
            
            gameObject.transform.position = location.magnitude < 0.1f
                ? location += velocity
                : location -= velocity;

            // 速度を反転させる
            velocity *=-1;
        }

        if (Input.GetMouseButtonDown(0))
        {
            ApplyForce(
               new Vector3(
                   Random.Range(-0.1f, 1f),
                   Random.Range(-0.1f, 1f),
                   Random.Range(-0.1f, 1f)
                )
            );
        }
        Move();

        // 力を初期化
        force = Vector3.zero;
	}

    void Move()
    {
        // トリクルダウン
        // 加速度は力を質量で除算したもの
        // 速度は加速度によって変化する
        // 位置は速度によって変化する
        acceleration = force / mass;
        velocity += acceleration;
        gameObject.transform.position += velocity;
    }


    public void SetMass(float massValue)
    {
        mass = massValue;   
    }
    public float GetMass()
    {
        return mass;
    }
    public void ApplyForce(Vector3 applyForce)
    {
        force += applyForce;
    }
}
