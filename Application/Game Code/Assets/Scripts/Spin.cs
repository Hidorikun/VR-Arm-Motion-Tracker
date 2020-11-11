using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public float speed = 20f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.up * speed * Time.deltaTime); 
	}

    public void flipSpin()
    {
        Debug.Log("clicked"); 
        speed = -speed; 
    }
}
