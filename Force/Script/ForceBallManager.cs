using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBallManager : MonoBehaviour {

    public GameObject ballPrefab;
    public int numOfBall;
    public  GameObject[] allBall;
    public  ForcedBall[] scripts;
    // Use this for initialization
    void Start()
    {
        numOfBall = 20;
        allBall = new GameObject[numOfBall];
        scripts = new ForcedBall[numOfBall];

        for (int i =0; i < numOfBall; i++)
        {
            float scale = 0.1f + i * 0.1f;
            // インスタンスを配列で管理する
            allBall[i] = Instantiate(ballPrefab, new Vector3(i * 2.0f - numOfBall,10.0f,0), Quaternion.identity);
            // スクリプトを配列で管理する
            scripts[i] = allBall[i].GetComponent<ForcedBall>();

            //scripts[i].mass = 0.1f + i * 0.1f;
            scripts[i].SetMass(0.1f + i * 0.1f);


            allBall[i].transform.localScale = new Vector3(1, 1, 1) * scale;
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
