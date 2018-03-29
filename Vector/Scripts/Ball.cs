using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    float mass;

    Vector3 location;
    Vector3 velocity;
    Vector3 acceleration;
    Vector3 defaultAcceleration;
    float gravity;
    int direction;
    //float speed;



	// Use this for initialization
	void Start () {
        //重さ
        mass = 1.0f;

        //位置
        location = gameObject.transform.position;

        // 速度
        velocity = Vector3.zero;

        // 方向：初期-1
        direction = -1;

        // 加速度
        acceleration = location.normalized / 600;

        // 加速度をキャッシュ
        defaultAcceleration = acceleration;

        // 重力
        gravity = 9.806f / 60;

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position = gameObject.transform.position;
        float posX = position.x;
        float posY = position.y;
        float posZ = position.z;
        
        //下限と上限にきたら方向を反転させる

        if (posY < 0.0f || posY > 10.0f)
        {
            // 通り過ぎた場合は下限、上限に移動させる
            gameObject.transform.position = posY < 0.0f ? new Vector3(posX, 0, posZ) : new Vector3(posX, 10.0f, posZ);

            // 速度を初期化
            velocity = Vector3.zero;

            // 方向を反転
            direction *= -1;
        }

        //　目的地の半分の距離に来たら減速する

        Move();
	}

    void Move()
    {
        // トリクルダウン
        //位置は速度によって変化し、速度は加速度によって変化する
        velocity += acceleration;
        gameObject.transform.position += velocity * direction;
    }
}
