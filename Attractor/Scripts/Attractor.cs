using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour {


    // 重力（引力)
    // F = G * m1 * m2 / ( r * r ) * r^
    // 引力は万有引力定数に物体１と物体2の質量を乗算したものを物体１と物体２の距離の二乗で除算し
    // それに物体１から物体２への単位ベクトルを乗算したもので出る


    public float mass;
	// Use this for initialization
	void Start () {
        mass = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
