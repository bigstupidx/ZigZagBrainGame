using UnityEngine;
using System.Collections;

public class Tiles : MonoBehaviour {

 

    void Start()
    {
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TileManager.Instance.SpawnTile();
          	 StartCoroutine(FallDown());
        }
    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(0.5f);
     //   this.gameObject.GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(3f);
		Destroy (this.gameObject);


    }
}