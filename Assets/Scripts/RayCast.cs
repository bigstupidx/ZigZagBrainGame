using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {
    private Vector3 RayDirection;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        RayDirection = Vector3.down;

    }

    // Update is called once per frame
    void Update () {
        
	
		if (GameController.GameOnOff) {

			Ray ray = new Ray (transform.position, Vector3.down);
			Debug.DrawRay (transform.position, -transform.up * 10f, Color.red);
			if (Physics.Raycast (transform.position, -transform.up * 10f, out hit)) {
				if (!hit.collider.CompareTag ("Tile")) {
					Player.isDead = true;
					GameController.GameOnOff = false;
					this.enabled = false;
				}
			}
		}
	}
}
