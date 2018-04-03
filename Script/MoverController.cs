using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverController : MonoBehaviour {

    public GameObject moverPrefab;
    int numOfMover;
    GameObject[] allMover;
    Mover[] m;

    float areaSize;

    float G;
    bool flg;
    GameObject heavyMover;

	// Use this for initialization
	void Start () {
        
        numOfMover = 10000;
        allMover = new GameObject[numOfMover];
        m = new Mover[numOfMover];
        areaSize = 20.0f;
        flg = true;
        G = 6.6f;
        // instatntiare
        for(int i = 0; i < numOfMover; i++)
        {
            allMover[i] = Instantiate(moverPrefab, RandomVec3(10.0f),Quaternion.identity);
            m[i] = allMover[i].GetComponent<Mover>();
            m[i].mass = Random.Range(1.0f, 2.0f);
            // moverのサイズを質量に比例させる
            allMover[i].transform.localScale *= 0.3f;

            // moverを横一列に整列
            //allMover[i].transform.position = new Vector3(i - numOfMover / 2 , 0, 0);

            // moverをランダムに配置
            //allMover[i].transform.position = RandomVec3(areaSize - 3.0f);
        }
        // heavyMoverを決定する
        
        heavyMover = allMover[0];
        heavyMover.transform.localScale *= 10.0f;
        m[0].mass = 100.0f;

        //for(int i = 1; i < numOfMover; i++)
        //{
        //    // heavyMoverよりallMover[i]が重かったらheavyMoverを更新する
        //    if(m[i].mass > heavyMover.GetComponent<Mover>().mass)
        //    {
        //        heavyMover = allMover[i];
        //    }
        //}

 

        //Debug.Log(System.Array.IndexOf(allMover, heavyMover));

	}
	
	// Update is called once per frame
	void Update () {

        // moverにランダムな力を適用する
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 RandomForce = RandomVec3(1600.0f);
            //for (int i = 0; i < numOfMover; i++)
            //{
            //    m[i].ApplyForce(RandomForce);
            //}
            m[0].ApplyForce(RandomForce);
        }

        // moverを減速させる
        if (Input.GetMouseButtonDown(1))
        {
            //Vector3 RandomForce = RandomVec3(1.0f);
            //for (int i = 0; i < numOfMover; i++)
            m[0].Breaking(0.9f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            flg = !flg;
        }

        for (int i = 0; i < numOfMover; i++)
        {


            if (flg)
            {
                if (allMover[i] != heavyMover) // mover[i]がheavyMoverでない時に実行
                {
                    m[i].GetAttract(G, heavyMover);
                }

            }
            else
            {
                if (allMover[i] != heavyMover) // mover[i]がheavyMoverでない時に実行
                {
                    m[i].GetRepulsive(G, heavyMover);
                }
            }

        }

        if(heavyMover.transform.position.magnitude > areaSize)
        {
            m[0].Reverse();
        }
    }

    public Vector3 RandomVec3(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
