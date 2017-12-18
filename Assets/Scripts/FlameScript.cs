using UnityEngine;
using System.Collections;

public class FlameScript : MonoBehaviour {
	public GameObject Flame;
	public SoundController SC;
	// Use this for initialization
	void Start () {
	
		SC = FindObjectOfType<SoundController> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter ( Collision DeadSea)
	{ 
		if ( DeadSea.gameObject.CompareTag ("GameOver"))
		{
			SC.playSound ("Lava");
			Flame.SetActive (true);


		}
	}

}
