using UnityEngine;
using System.Collections;

public class FlameScript : MonoBehaviour {
	public GameObject Flame;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnCollisionEnter ( Collision DeadSea)
	{ 
		Debug.Log("OnCollisionEnter ( Collision DeadSea):");
		if ( DeadSea.gameObject.CompareTag ("GameOver"))
		{
			Flame.SetActive (true);
			Debug.Log("Flame.SetActive (true);");
		}
	}

}
