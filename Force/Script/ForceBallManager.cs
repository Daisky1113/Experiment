using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBallManager : MonoBehaviour {

    public GameObject ballPrefab;
    public static int numOfBall = 10;
    public static GameObject[] allBall = new GameObject[numOfBall];
    // Use this for initialization
    void Start()
    {

        for(int i =0; i < numOfBall; i++)
        {
            allBall[i] = Instantiate(ballPrefab, new Vector3(i * 2.0f - numOfBall,10.0f,0), Quaternion.identity);
            Debug.Log(allBall[i]);
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
