using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float speed;
	public static Vector3 vec3;
	public static bool isDead;
	public static int Score;
	public Text UiScore;
    public Text UiCoins;
    public Text UiBestScore;
	public Text UiGameOverScore;
    public static int coinScore;
    private bool checkRotation;
    public Text uiTextCoins;
    public GameObject RagDoll;
    private Vector3 RayDirection;
    RaycastHit hit;
   
    void Start () {
		Score = 0;
		vec3 = Vector3.zero;
        isDead = false;
        coinScore = PlayerPrefs.GetInt("CoinInt");
        UiCoins.text = coinScore.ToString();
        checkRotation = true;
        
        RayDirection = Vector3.down;

       
    
       // uiTextCoins = GameObject.FindGameObjectWithTag("CoinsText");
        
    }


	void Update () {
       
        UiCoins.text = coinScore.ToString();
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast (ray, out hit , 0.5f))
        {
            if (hit.collider.CompareTag("Tile"))
            {
                isDead = false;
            }
            
        }


        if (!isDead && GameController.GameOnOff && Input.GetMouseButtonDown(0))
        {
            if (checkRotation)
            {
                transform.Rotate(0, -90, 0);
                checkRotation = false;
            }
            else
            {
                transform.Rotate(0, 90, 0);
                checkRotation = true;
            }

            Score++;
            UiScore.text = Score.ToString();
           
        }
        else if (isDead)
        {
            Debug.Log("isDead");
            vec3 = Vector3.down;
            UiGameOverScore.text = UiScore.text;
            int BestScore = PlayerPrefs.GetInt("Best");

            if (Score > BestScore)
            {
                PlayerPrefs.SetInt("Best", Score);
            }
            UiBestScore.text = BestScore.ToString();

        }

        transform.Translate(vec3 * speed * Time.deltaTime);
       
	}
    /*
	void OnTriggerExit ( Collider Obj)
	{
		Debug.Log ("OnTriggerExit");
		if (Obj.tag== "Tile") 
		{
			RaycastHit Hit;
			Ray raydown = new Ray (transform.position, Vector3.down);

            if (!Physics.Raycast( raydown , out Hit ))
				{ 
					isDead = true;  
				}  
		}
    }
    */
    void OnTriggerEnter (Collider Coin)
    { 
        if (Coin.gameObject.CompareTag("Coin"))
        {

            coinScore = PlayerPrefs.GetInt("CoinInt");
            coinScore = coinScore + 3;
            UiCoins.text = coinScore.ToString();
            Destroy(Coin.gameObject);
            PlayerPrefs.SetInt("CoinInt", coinScore);
            uiTextCoins.text = "+3";
            uiTextCoins.gameObject.SetActive(true);
            Invoke("SetTextOff", 0.13f);

            
        }


        if (Coin.gameObject.CompareTag("Diamond"))
        {
            Debug.Log("Diamond Trigger");
            coinScore = PlayerPrefs.GetInt("CoinInt");
            coinScore = coinScore + 5;
            UiCoins.text = coinScore.ToString();
            Destroy(Coin.gameObject);
            PlayerPrefs.SetInt("CoinInt", coinScore);
           
            uiTextCoins.text = "+5";
            uiTextCoins.gameObject.SetActive(true);
            Invoke("SetTextOff", 0.25f);
        }

        /*
        if (Coin.gameObject.CompareTag("GameOver"))
        {

            vec3 = Vector3.zero;
            isDead = true;
            this.gameObject.SetActive(false);
            Instantiate(RagDoll, this.gameObject.transform.GetChild(0).position, this.transform.rotation);
            //   Time.timeScale = 0;
        }
        */
    }



    void OnCollisionEnter (Collision DeadSea)
    {

        if (DeadSea.gameObject.CompareTag("GameOver"))
        {
           
            vec3 = Vector3.zero;
            isDead = true;
            this.gameObject.SetActive(false);
            Instantiate(RagDoll, this.gameObject.transform.GetChild(0).position, this.transform.rotation);
            //   Time.timeScale = 0;
        }

    }

    void SetTextOff()
    {
        uiTextCoins.gameObject.SetActive(false);
    }
  
}