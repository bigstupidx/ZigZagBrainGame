using UnityEngine;
using System.Collections;

public class IsKinematicPlayer : MonoBehaviour {


	void Update () {
        if (GameController.isKinematic)
        {
            Debug.Log(!GameController.isKinematic);
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
        else if (!GameController.isKinematic)
        {
            Debug.Log(GameController.isKinematic);
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }


    }
}
