using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonGravity : MonoBehaviour {

    // Use this for initialization
    public ConstantForce gravity;

    void Start () {
        //gravity = gameObject.AddComponent<ConstantForce>();
        //gameObject.GetComponent<Rigidbody>().useGravity = false;
        //gravity.force = new Vector3(0.0f, -1.4f, 0.0f);

        Physics.gravity = new Vector3(0, -0.165F, 0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
