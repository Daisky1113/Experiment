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

    float constanOfGravitation; // 万有引力定数
    float dir;

	// Use this for initialization
	void Start () {
        numOfMover = 2;
        randomRange = 10.0f;

        allMover = new GameObject[numOfMover];
        scripts = new Mover[numOfMover];
        //attractor = Instantiate(attractorPrefab, Vector3.zero, Quaternion.identity);


        // Moverをインスタンス化
        for(int i =0; i < numOfMover; i++)
        {
            allMover[i] = Instantiate(moverPrefab, RandomVec3(randomRange), Quaternion.identity);
            scripts[i] = allMover[i].GetComponent<Mover>();

            scripts[i].SetMass(1 + i * 0.2f );
            allMover[i].transform.localScale = allMover[i].transform.localScale * scripts[i].GetMass();
            //allMover[i].transform.position = new Vector3(1.0f * i - numOfMover / 2, 0, 0);
            allMover[i].transform.position = RandomVec3(5.0f);
        }

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 randomForce = RandomVec3(0.5f);
            for(int i = 0; i < numOfMover; i++)
            {
                scripts[i].ApplyForce(randomForce);
            }
        }
	}
    Vector3 RandomVec3(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}