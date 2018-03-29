using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour {
    public GameObject ballPrefab;
    Vector3 ballPosition;
    GameObject ball;
    int numOfBall;
	// Use this for initialization
	void Start () {
        
        numOfBall = 20;
        CreateInstance(numOfBall);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void CreateInstance(int number)
    {
        for(int i =0; i < number; i++)
        {
            ballPosition = new Vector3(Random.Range(-2.0f,2.0f), 10.0f, Random.Range(-2.0f, 2.0f));
            ball = Instantiate(ballPrefab,ballPosition,Quaternion.identity);
        }
    }
}
