﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcedBall : MonoBehaviour {


    //ニュートンの第二の法則
    //加速度はすべての力の合計を質量で割ったもの

    float mass;

    Vector3 location;
    Vector3 endPoint;
    float defaultPosX, defaultPosZ;

    Vector3 acceleration;
    Vector3 defaulAcceleration;
    Vector3 velocity;
    Vector3 force;


    float maxLength;
    float minLength;

 
	// Use this for initialization
	void Start () {
        //質量をランダムに設定する
        mass = Random.Range(0.1f,5.0f);
        location = gameObject.transform.position;
        defaultPosX = location.x;
        defaultPosZ = location.z;
        endPoint = new Vector3(defaultPosX, 0, defaultPosZ);

        velocity = Vector3.zero;

        // 初期値から目的地までのベクトルを正規化したもの
        acceleration = (location - endPoint).normalized / 600; 
        defaulAcceleration = acceleration;//加速度をキャッシュ
        force = Vector3.zero;

        maxLength = 10.0f;
        minLength = 0.1f;


	}
	
	// Update is called once per frame
	void Update () {

        // 上限下限に達したら方向を反転させる
        Vector3 ballPosition = gameObject.transform.position;

        float posX = ballPosition.x;
        float posY = ballPosition.y;
        float posZ = ballPosition.z;

        if(posY < minLength || posY > maxLength)
        {
            // 目的地を通りすぎたときの処理
            gameObject.transform.position = posY < minLength 
                ? new Vector3(posX, minLength, posZ) 
                : new Vector3(posX, maxLength, posZ);

            velocity = Vector3.zero; // 速度を初期化
        }


            // マウスが押されたら加速度を増加させる
       if (Input.GetMouseButtonDown(0))
       {
            ApplyForce(new Vector3(0, - 0.1f, 0));
       }

        Move();
        force = Vector3.zero;
        acceleration = defaulAcceleration;
	}

    void Move()
    {
        // トリクルダウン
        // 力を加速度に変換する
        acceleration = force;
        //加速度を速度に変換
        velocity += acceleration;
        //速度を位置に変換
        gameObject.transform.position += velocity;
    }

    void ApplyForce(Vector3 anyForce)
    {
        //外的な力が加わったらforceにキャッシュする
        // 分配法則が適応できるので先に計算して結果だけ保存する
        force += (anyForce / mass);
    }
}
