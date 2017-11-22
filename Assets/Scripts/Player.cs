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
	public Text UiGameOverCoins;
	private int CurrentCoins;
	public Text UiMarketCoin;
	private bool checkRotation;
    public Text uiTextCoins;
    public GameObject RagDoll;
    private Vector3 RayDirection;
	public GameObject rayObject;

  

	private bool RayStart;
   
	void Awake()
	{
		isDead = false;
	}
    void Start () {
		//PlayerPrefs.SetInt("Best", 0);
		Score = 0;
		vec3 = Vector3.zero;
        coinScore = PlayerPrefs.GetInt("CoinInt");
        UiCoins.text = coinScore.ToString();
        checkRotation = true;
        RayDirection = Vector3.down;
		CurrentCoins = 0;
       	
    
       // uiTextCoins = GameObject.FindGameObjectWithTag("CoinsText");
        
    }

	public void RayCastStatus(bool enable)
	{
		rayObject.SetActive (enable);
	}



	void Update () {
       
        UiCoins.text = coinScore.ToString();
		UiGameOverCoins.text = CurrentCoins.ToString();
		UiMarketCoin.text = coinScore.ToString ();

		if (!isDead && GameController.GameOnOff && Input.GetMouseButtonDown(0) && GameController.RotationControll) 
        {
            if (checkRotation)
            {
				iTween.RotateAdd (this.gameObject, new Vector3 (0, -90, 0), 0.2f);
                checkRotation = false;
            }
            else
            {
				iTween.RotateAdd (this.gameObject, new Vector3 (0, 90, 0), 0.2f);
                checkRotation = true;
            }

            Score++;
            UiScore.text = Score.ToString();
           
        }
		else if (isDead && !GameController.GameOnOff)
        {
			this.gameObject.SetActive(false);
			GameObject ragdoll=	Instantiate(RagDoll, this.gameObject.transform.GetChild(0).position, this.transform.rotation) as GameObject;
			ragdoll.transform.GetComponentInChildren<Rigidbody> ().AddForce (transform.forward * 100f, ForceMode.Impulse);
			vec3 = Vector3.zero;
            UiGameOverScore.text = UiScore.text;
            int BestScore = PlayerPrefs.GetInt("Best");

            if (Score > BestScore)
            {
                PlayerPrefs.SetInt("Best", Score);
				UiBestScore.text = Score.ToString ();
            }
			else
            UiBestScore.text = BestScore.ToString();

        }

        transform.Translate(vec3 * speed * Time.deltaTime);
       
	}
    
    void OnTriggerEnter (Collider Coin)
    { 
        if (Coin.gameObject.CompareTag("Coin"))
        {

            coinScore = PlayerPrefs.GetInt("CoinInt");
            coinScore = coinScore + 1;
			CurrentCoins = CurrentCoins + 1;
			UiGameOverCoins.text = CurrentCoins.ToString ();
            UiCoins.text = coinScore.ToString();
            Destroy(Coin.gameObject);
            PlayerPrefs.SetInt("CoinInt", coinScore);
            uiTextCoins.text = "+1";
            uiTextCoins.gameObject.SetActive(true);
            Invoke("SetTextOff", 0.13f);

            
        }


        if (Coin.gameObject.CompareTag("Diamond"))
        {
            Debug.Log("Diamond Trigger");
            coinScore = PlayerPrefs.GetInt("CoinInt");
            coinScore = coinScore + 3;
			CurrentCoins = CurrentCoins + 3;
			UiGameOverCoins.text = CurrentCoins.ToString ();
            UiCoins.text = coinScore.ToString();
            Destroy(Coin.gameObject);
            PlayerPrefs.SetInt("CoinInt", coinScore);
           
            uiTextCoins.text = "+3";
            uiTextCoins.gameObject.SetActive(true);
            Invoke("SetTextOff", 0.25f);
        }

    }

    void SetTextOff()
    {
        uiTextCoins.gameObject.SetActive(false);
    }


  
}