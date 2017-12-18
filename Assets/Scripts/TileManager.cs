using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour
{
   
    public GameObject[] Tiles;
    public GameObject CurrentTile;
    private int RandomTile;
    private int RandonSpawnPoint;
	private int Step;
	private int CheckLeftOrTop;
	private int count;
	private bool GapShifter;


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
		GapShifter = true;
		CheckLeftOrTop = 0;
		count = 0;
        for( int i=0; i < 10; i++)
        {
            SpawnTile();

        }


	}
	
    public void SpawnTile()
    {
		if (GapShifter) 
		{
			if (Player.Score <= 50 && Player.Score >= 0) {
				Step = Random.Range (3, 7);
				GapShifter = false;

			} else if (Player.Score <= 100 && Player.Score > 50) {
				Step = Random.Range (2, 5);
				GapShifter = false;
			} else if (Player.Score > 100) {
				Step = Random.Range (1, 3);
				GapShifter = false;

			} 

		}

		if (Player.Score <= 30) {
			if (CheckLeftOrTop == 0)
			{
				CurrentTile = (GameObject)Instantiate (Tiles [CheckLeftOrTop], CurrentTile.transform.GetChild (0).transform.GetChild (CheckLeftOrTop).position, Quaternion.identity);		
				count++;
				if (count > Step)
				{
					CheckLeftOrTop = 1;
					GapShifter = true;
					count = 0;
				}

			} else if (CheckLeftOrTop == 1) {
				CurrentTile = (GameObject)Instantiate (Tiles [CheckLeftOrTop], CurrentTile.transform.GetChild (0).transform.GetChild (CheckLeftOrTop).position, Quaternion.identity);		
				count++;
				if (count > Step) 
				{
					CheckLeftOrTop = 0;
					GapShifter = true;
					count = 0;
				}
			}
		} 
		else
		{
			int RandomTile = Random.Range(0, 2);
			/// Debug.Log(RandomNumber);

			CurrentTile = (GameObject) Instantiate(Tiles[RandomTile],CurrentTile.transform.GetChild(0).transform.GetChild(RandomTile).position,Quaternion.identity);


		}

		int GemsSlection1 = Random.Range(0, 25);


		if (GemsSlection1 <= 3)
        {
            CurrentTile.transform.GetChild(1).gameObject.SetActive(true);
           
        }
		if (Player.Score >= 50)
		{
			if (GemsSlection1 == 20) 
			{
				CurrentTile.transform.GetChild (2).gameObject.SetActive (true);
			}
		}

		int FireFlies = Random.Range(0, 3);
		if (FireFlies == 1)
		{
			
			CurrentTile.transform.GetChild(3).gameObject.SetActive(true);

		}

    }
}
