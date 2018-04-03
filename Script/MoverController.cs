using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverController : MonoBehaviour {

    public GameObject moverPrefab;
    GameObject mover;
    Mover m;

    float areaSize;
	// Use this for initialization
	void Start () {
        areaSize = 10.0f;
        mover = Instantiate(moverPrefab,Vector3.zero,Quaternion.identity);
        m = mover.GetComponent<Mover>();
        m.mass = 10.0f;
        Debug.Log(m.mass);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            m.ApplyForce(RandomVec3(10.0f));
        }
        if (mover.transform.position.magnitude > areaSize)
        {
            m.Reverse();
        }
        if (Input.GetMouseButtonDown(1))
        {
            m.Breaking(0.3f);
        }
        m.Move();
	}
    public Vector3 RandomVec3(float range)
    {
        return new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));
    }
}
