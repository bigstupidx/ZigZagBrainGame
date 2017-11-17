using UnityEngine;
using System.Collections;

public class CameraContoller : MonoBehaviour {

    private Vector3 Offsets;
	private GameObject player;
    public GameObject OffsetsForCamera;
    

  
    void Start()
    {
		player = GameObject.FindGameObjectWithTag ("Player");
		Offsets = transform.position -  player.gameObject.transform.position;
    }


    void LateUpdate()
    {

		if (Player.isDead == false && !GameController.shop)
			transform.position = player.gameObject.transform.position + Offsets;
		else if (GameController.shop) 
		{
			this.gameObject.transform.position = OffsetsForCamera.gameObject.transform.position;
			this.gameObject.transform.rotation = OffsetsForCamera.gameObject.transform.rotation;
			this.gameObject.GetComponent<Camera> ().orthographic = false;
			this.gameObject.GetComponent<Camera> ().fieldOfView = 16;
		} 
		else if (Player.isDead) 
		{

		}
    }

}
