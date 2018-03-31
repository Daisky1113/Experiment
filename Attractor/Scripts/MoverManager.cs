using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverManager : MonoBehaviour {

    public float attraction;

    public GameObject moverPrefab;
    GameObject[] allMovers;
    Mover[] moverScripts;
    int numOfMover;

	// Use this for initialization
	void Start () {

        attraction = 1.0f; //　万有引力定数

        numOfMover = 10;
        allMovers = new GameObject[numOfMover];
        moverScripts = new Mover[numOfMover];
	    for(int i = 0; i < numOfMover; i++)
        {
            allMovers[i] = Instantiate(moverPrefab, RandomVec3(10.0f), Quaternion.identity);
            moverScripts[i] = allMovers[i].GetComponent<Mover>();

            moverScripts[i].SetMass(Random.Range(2.0f, 3.0f)); // 質量をランダムに設定

            allMovers[i].transform.position = RandomVec3(5.0f); // ポジションんをランダムに設定
            allMovers[i].transform.localScale *= moverScripts[i].GetMass();　// 質量からメッシュの大きさを変更
        }	
	}
	
	// Update is called once per frame
	void Update () {
        for(int i =1; i < numOfMover; i++)
        {
            moverScripts[i].GetAttract(0.01f, allMovers[0]);
        }
	}

    Vector3 GetAttract() 
    {
        Vector3 dir = allMovers[0].transform.position - allMovers[1].transform.position;
        float distance = dir.magnitude;
        dir = dir.normalized;

        float m = attraction * moverScripts[0].GetMass() * moverScripts[1].GetMass() / (distance * distance);

        return dir * m;
    }

    Vector3 RandomVec3(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
