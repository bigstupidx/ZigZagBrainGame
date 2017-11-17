using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

    public GameObject objectToLook;
	public GameObject FollowUp;
	public Vector3 Offset;

	// Use this for initialization
	void Start () {
		FollowUp = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void LateUpdate () {

        transform.LookAt(objectToLook.transform.position);
		this.gameObject.transform.position = FollowUp.gameObject.transform.position + Offset ;
		//this.gameObject.transform.rotation = FollowUp.gameObject.transform.rotation;
	}
}
