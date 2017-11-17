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
        Ray ray = new Ray(transform.position, Vector3.down);

		Debug.DrawRay (transform.position, transform.TransformDirection (Vector3.down) * 10, Color.red);
		if (Physics.Raycast(transform.position , transform.TransformDirection (Vector3.down) *10, out hit))
        {
			if (hit.collider.CompareTag("GameOver") && GameController.GameOnOff)
            {
				
                Player.isDead = true;
				GameController.GameOnOff = false;
            }
	    }
    }
}
