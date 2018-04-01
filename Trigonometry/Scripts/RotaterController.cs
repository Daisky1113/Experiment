using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaterController : MonoBehaviour {

    public GameObject rotaterPrefab;
    GameObject rotater;
    Rotater script;

    float areaSize = 20.0f;
	// Use this for initialization
	void Start () {
        rotater = Instantiate(rotaterPrefab, Vector3.zero, Quaternion.identity);
        script = rotater.GetComponent<Rotater>();
	}
	
	// Update is called once per frame
	void Update () {

        script.Move();
        if (Input.GetMouseButtonDown(0))
        {
            script.ApplyForce(RandomVec3(30.0f));
        }

        if (Input.GetMouseButtonDown(1))
        {
            script.SlowDown(0.5f);
        }

        // オブジェクトがエリアを超えた時の処理
        if(rotater.transform.position.magnitude > areaSize)
        {
            script.Reverse();
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
