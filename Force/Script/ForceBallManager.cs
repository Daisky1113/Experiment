using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBallManager : MonoBehaviour {

    public GameObject ballPrefab;
    int numOfBall;
    // Use this for initialization
    void Start()
    {
        numOfBall = 10;
        for(int i =0; i < numOfBall; i++)
        {
            Instantiate(ballPrefab, new Vector3(i * 2.0f - numOfBall,10.0f,0), Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Vector3 RandomPosition(float range)
    {
        return new Vector3(Random.Range(-range, range), 10.0f, 0);
    }
}
