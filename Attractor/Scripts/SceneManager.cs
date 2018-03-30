using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject attractorPrefab;
    public GameObject moverPrefab;

    GameObject[] allMover;
    GameObject attractor;
    Mover[] scripts;

    int numOfMover;
    float randomRange;
	// Use this for initialization
	void Start () {
        numOfMover = 10;
        randomRange = 10.0f;

        allMover = new GameObject[numOfMover];
        scripts = new Mover[numOfMover];
        attractor = Instantiate(attractorPrefab, Vector3.zero, Quaternion.identity);
        for(int i =0; i < numOfMover; i++)
        {
            allMover[i] = Instantiate(moverPrefab, RandomVec3(randomRange), Quaternion.identity);
            scripts[i] = allMover[i].GetComponent<Mover>();

            scripts[i].SetMass(0.3f + i * 0.1f);
            allMover[i].transform.localScale = allMover[i].transform.localScale * scripts[i].GetMass();
            allMover[i].transform.position = new Vector3(1.0f * i - numOfMover / 2, 0, 0);
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
