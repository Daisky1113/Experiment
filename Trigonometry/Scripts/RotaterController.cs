using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterController : MonoBehaviour {

    //public GameObject rotaterPrefab;
    public GameObject spherePrefab;
    GameObject[] allSphere;
    Rotater[] scripts;
    int numOfSphere;
    //GameObject rotater;
    //Rotater script;
    Vector3 force;

    float areaSize = 20.0f;
	// Use this for initialization
	void Start () {
        numOfSphere = 10;
        allSphere = new GameObject[numOfSphere];
        scripts = new Rotater[numOfSphere];
        
        for(int i =0; i < numOfSphere; i++)
        {
            allSphere[i] = Instantiate(spherePrefab, new Vector3(i * 1.0f - ( numOfSphere / 2 )  ,0,0) , Quaternion.identity);
            scripts[i] = allSphere[i].GetComponent<Rotater>();

            float mass = 2.0f + i * 0.5f; // 質量を徐々に増加させる
            scripts[i].mass = mass;
            allSphere[i].transform.localScale *= (mass * 0.1f); // 質量に基づいてスケールを変化させる 
        }
        //rotater = Instantiate(rotaterPrefab, Vector3.zero, Quaternion.identity);
        //script = rotater.GetComponent<Rotater>();
        force = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {

        for(int i =0; i < numOfSphere; i++)
        {
            if(allSphere[i].transform.position.magnitude > areaSize)
            {
                scripts[i].Reverse();
            }
            scripts[i].Move();
        }
        if (Input.GetMouseButtonDown(0))
        {
            force = RandomVec3(30.0f);
            for (int i = 0; i < numOfSphere; i++)
            {
                scripts[i].ApplyForce(force);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            //for (int i = 0; i < numOfSphere; i++)
            //{
            //    scripts[i].SlowDown(0.7f);
            //}
        }

        //script.Move();
        //if (Input.GetMouseButtonDown(0))
        //{
        //    script.ApplyForce(RandomVec3(30.0f));
        //}

        //if (Input.GetMouseButtonDown(1))
        //{
        //    script.SlowDown(0.5f);
        //}

        //// オブジェクトがエリアを超えた時の処理
        //if(rotater.transform.position.magnitude > areaSize)
        //{
        //    script.Reverse();
        //}
	}

    GameObject GetHeavyObject(GameObject[] objects)
    {
        GameObject heavyObject = objects[0]
            ;
        for(int i = 1; i < objects.Length; i++)
        {
           
        }
    }
    float RandomFloat(float range)
    {
        return Random.Range(-range, range);
    }
    Vector3 RandomVec3(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
