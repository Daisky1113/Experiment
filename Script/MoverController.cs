using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverController : MonoBehaviour {

    public GameObject moverPrefab;
    int numOfMover;
    GameObject[] allMover;
    Mover[] m;

    float areaSize;

	// Use this for initialization
	void Start () {
        
        numOfMover = 10;
        allMover = new GameObject[numOfMover];
        m = new Mover[numOfMover];
        areaSize = 10.0f;

        // instatntiare
        for(int i = 0; i < numOfMover; i++)
        {
            allMover[i] = Instantiate(moverPrefab, RandomVec3(areaSize - 1.0f), Quaternion.identity);
            m[i] = allMover[i].GetComponent<Mover>();
            m[i].mass = Random.Range(1.0f, 2.0f);
            // moverのサイズを質量に比例させる
            allMover[i].transform.localScale *= m[i].mass;

            // moverを横一列に整列
            allMover[i].transform.position = new Vector3(i - numOfMover / 2 , 0, 0);
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 RandomForce = RandomVec3(10.0f);
            for (int i = 0; i < numOfMover; i++)
            {
                m[i].ApplyForce(RandomForce);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 RandomForce = RandomVec3(10.0f);
            for (int i = 0; i < numOfMover; i++)
            {
                m[i].Breaking(0.3f);
            }
        }
        for (int i = 0; i < numOfMover; i++)
        {
            if(allMover[i].transform.position.magnitude > areaSize)
            {
                m[i].Reverse();
            }
            m[i].Move();
        }
    }


    public Vector3 RandomVec3(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
