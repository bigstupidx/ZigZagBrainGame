using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

    public GameObject objectToLook;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(objectToLook.transform.position);

	}
}
