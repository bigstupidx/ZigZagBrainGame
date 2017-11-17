using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour
{
   
    public GameObject[] Tiles;
    public GameObject CurrentTile;
    private int RandomTile;
    private int RandonSpawnPoint;


    private static TileManager instance;

    public static TileManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
           return instance;
        }

       
    }

    // Use this for initialization
    void Start ()
    {
        for( int i=0; i < 10; i++)
        {
            SpawnTile();

        }
      
	}
	
    public void SpawnTile()
    {
        int RandomTile = Random.Range(0, 2);
       /// Debug.Log(RandomNumber);

       CurrentTile = (GameObject) Instantiate(Tiles[RandomTile],CurrentTile.transform.GetChild(0).transform.GetChild(RandomTile).position,Quaternion.identity);
        int GemsSlection = Random.Range(0, 10);
        if (GemsSlection == 1)
        {
            CurrentTile.transform.GetChild(1).gameObject.SetActive(true);
           
        }
        else if (GemsSlection == 2)
        {
            CurrentTile.transform.GetChild(2).gameObject.SetActive(true);
        }


		int FireFlies = Random.Range(0, 3);
		if (FireFlies == 1)
		{
			
			CurrentTile.transform.GetChild(3).gameObject.SetActive(true);

		}

    }
}
