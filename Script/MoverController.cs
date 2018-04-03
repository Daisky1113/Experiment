using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverController : MonoBehaviour {

    public GameObject moverPrefab;
    int numOfMover;
    GameObject[] allMover;
    Mover[] m;

    float areaSize;

    GameObject heavyMover;

	// Use this for initialization
	void Start () {
        
        numOfMover = 2000;
        allMover = new GameObject[numOfMover];
        m = new Mover[numOfMover];
        areaSize = 20.0f;

        // instatntiare
        for(int i = 0; i < numOfMover; i++)
        {
            allMover[i] = Instantiate(moverPrefab, RandomVec3(10.0f), Quaternion.identity);
            m[i] = allMover[i].GetComponent<Mover>();
            m[i].mass = Random.Range(1.0f, 2.0f);
            // moverのサイズを質量に比例させる
            allMover[i].transform.localScale *= m[i].mass;

            // moverを横一列に整列
            //allMover[i].transform.position = new Vector3(i - numOfMover / 2 , 0, 0);

            // moverをランダムに配置
            //allMover[i].transform.position = RandomVec3(areaSize - 3.0f);
        }
        // heavyMoverを決定する
        heavyMover = allMover[0];
        m[0].mass = 90.0f;

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
            {
                m[0].Breaking(0.2f);
            }
        }

        for (int i = 0; i < numOfMover; i++)
        {


            //    // moverに引力を適用する
            if (allMover[i] != heavyMover) // mover[i]がheavyMoverでない時に実行
            {
                m[i].GetRepulsive(1.7f, heavyMover);
            }

            //    // moverを移動させる
            //    m[i].Move();
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
