using UnityEngine;
using System.Collections;

public class CoinRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       this.gameObject.transform.Rotate(1, 0, 0);
	}
}
