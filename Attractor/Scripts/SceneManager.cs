using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject attractorPrefab;
    public GameObject moverPrefab;

    GameObject[] allMover;
    GameObject attractor;

    int numOfMover;
    float randomRange;
	// Use this for initialization
	void Start () {
        numOfMover = 10;
        randomRange = 10.0f;

        allMover = new GameObject[numOfMover];

        attractor = Instantiate(attractorPrefab, Vector3.zero, Quaternion.identity);
        for(int i =0; i < numOfMover; i++)
        {
            allMover[i] = Instantiate(moverPrefab, RandomVec3(randomRange), Quaternion.identity);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    Vector3 RandomVec3(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
