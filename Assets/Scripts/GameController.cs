using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject Canvas;
	public GameObject[] DialogBox;
    public GameObject[] Players;
    public static bool GameOnOff;
    private  int PlayerSlector;
   // private int PlayerNumber;
    public GameObject BuyButton;
    public GameObject Lock;
    public Text PriceText;
    public int[] PlayerPrice;
    public int Sold;
    public static bool shop;
    public GameObject[] ShowingHiding;
	public GameObject Selected;
    public static bool isKinematic = false; 
	public Text CountDown;
	public static bool RayStart;
	public static bool RotationControll;
	public static bool StartScroing = false;

    void Start ()
    {
		RotationControll = false;
		shop = false;
        //PlayerPrefs.SetInt("0", 1);
		Player.isDead = false;
        DialogBox [0].gameObject.SetActive (true);
		GameOnOff = false;
        PlayerSlector = PlayerPrefs.GetInt("Player");
        Players[PlayerSlector].gameObject.SetActive(true);
        ShowBuyButton();
		FindObjectOfType<Player> ().RayCastStatus (false);
		PlayerPrefs.SetInt("0", 1);



    }

    void Update ()
    {
       
		if (GameOnOff && !Player.isDead) 
		{
			DialogBox [0].gameObject.SetActive (false);
			DialogBox [1].gameObject.SetActive (true);
		}
		else if (Player.isDead && !GameOnOff) 
		{
            StartCoroutine(GameOverDelay());			
		}


	}

	public void Exit()
	{
		Application.Quit ();
	}

	public void OnRetry()
	{
	//	Application.LoadLevel(0);
	}

    public void OnPlay()
    {

		ShowingHiding[0].SetActive(true);
		ShowingHiding[1].SetActive(true);
		ShowingHiding[6].SetActive(true);
		ShowingHiding[7].SetActive(true);
		ShowingHiding[9].SetActive(true);
		GameOnOff = true;
		StartCoroutine (SetActiveOffText ());
		Invoke ("WaitForPlay" , 4f);
    }

	void DeadSolution()
	{
		RayStart = true;
	}
    public void OnPlaySlection()
    {
        DialogBox[0].gameObject.SetActive(false);
		ShowingHiding[5].SetActive(false);
        DialogBox[3].gameObject.SetActive(true);
        shop = true;
        ShowingHiding[2].SetActive(false);
        ShowingHiding[3].SetActive(true);
		ShowingHiding[6].SetActive(false);
		ShowingHiding[0].SetActive(false);
		ShowingHiding[1].SetActive(false);
		ShowingHiding[13].SetActive(false);
        isKinematic = true;
		FindObjectOfType<Player> ().GetComponent<Animator> ().SetBool ("Market", true);
    }

 
	public void Setting_btn()
	{
		DialogBox [0].SetActive (false);
		DialogBox [4].SetActive (true);
	}

	public void Pause_btn()
	{
		FindObjectOfType<Player> ().GetComponent<Animator> ().SetBool ("Run", false);
		Time.timeScale = 0;
		ShowingHiding[0].SetActive(false);
		ShowingHiding[1].SetActive(false);
		ShowingHiding[6].SetActive(false);
		ShowingHiding[7].SetActive(false);
		ShowingHiding[9].SetActive(false);

		ShowingHiding[10].SetActive(true);
	}

	public void Resume_btn()
	{
		Time.timeScale = 1;
		FindObjectOfType<Player> ().GetComponent<Animator> ().SetBool ("Run", true);

		ShowingHiding[0].SetActive(true);
		ShowingHiding[1].SetActive(true);
		ShowingHiding[6].SetActive(true);
		ShowingHiding[7].SetActive(true);
		ShowingHiding[9].SetActive(true);

		ShowingHiding[10].SetActive(false);

	}
	/// ////////////////////////////////////////////Player Slection Screen
  


    public void PlayerSlection_Nextbtn()
    {
		
		if (PlayerSlector < 6) 
		{
			ShowingHiding [11].SetActive (true);
			Players [PlayerSlector].gameObject.SetActive (false);
			Players [PlayerSlector + 1].gameObject.SetActive (true);
			PlayerSlector = PlayerSlector + 1;
			ShowBuyButton ();

		}
		else 
		{
			Players [PlayerSlector].gameObject.SetActive (false);
			Players [PlayerSlector + 1].gameObject.SetActive (true);
			PlayerSlector = PlayerSlector + 1;
			ShowBuyButton ();
			ShowingHiding [12].SetActive (false);
		}
		FindObjectOfType<Player> ().GetComponent<Animator> ().SetBool ("Market", true);
    }

    public void PlayerSlection_Backbtn()
    {
		
       
		if( PlayerSlector > 1)
        {
			ShowingHiding [12].SetActive (true);
            Players[PlayerSlector].gameObject.SetActive(false);
            Players[PlayerSlector -1].gameObject.SetActive(true);
            PlayerSlector = PlayerSlector -1;
            ShowBuyButton();

        }

		else 
		{
			Players[PlayerSlector].gameObject.SetActive(false);
			Players[PlayerSlector -1].gameObject.SetActive(true);
			PlayerSlector = PlayerSlector -1;
			ShowBuyButton();
			ShowingHiding [11].SetActive (false);
		}
		FindObjectOfType<Player> ().GetComponent<Animator> ().SetBool ("Market", true);

    }

    public void PlayerSlection_Usebtn()
    {
        PlayerPrefs.SetInt("Player", PlayerSlector);
		Application.LoadLevel (0);
		//ShowBuyButton ();
    }

    public void PlayerSlection_BacktoMainMenubtn()
    {
        DialogBox[3].gameObject.SetActive(false);
        DialogBox[0].gameObject.SetActive(true);
		ShowingHiding[5].SetActive(true);
        isKinematic = false;
        Application.LoadLevel(0);
        shop = false;
        ShowingHiding[2].SetActive(true);
        ShowingHiding[3].SetActive(false);
        ShowingHiding[4].SetActive(false);
    }

    public void OnBuyButton()
    {
        if (Player.coinScore >= PlayerPrice[PlayerSlector-1])
        {
            BuyButton.gameObject.SetActive(false);
            PlayerPrefs.SetInt((PlayerSlector).ToString(), 1);
            Sold = PlayerPrefs.GetInt((PlayerSlector - 1).ToString());
            PlayerPrefs.SetInt("CoinInt", (Player.coinScore - PlayerPrice[PlayerSlector - 1]));
            Player.coinScore = PlayerPrefs.GetInt("CoinInt");
            
        }
        ShowBuyButton();

    }


    private void ShowBuyButton()
	{
			
		if (PlayerPrefs.GetInt (PlayerSlector.ToString ()) == 1) {
			BuyButton.gameObject.SetActive (false);
			Lock.gameObject.SetActive (false);
			PriceText.gameObject.SetActive (false);
			ShowingHiding [8].gameObject.SetActive (false);

		} else {
			BuyButton.gameObject.SetActive (true);
			Lock.gameObject.SetActive (true);
			PriceText.gameObject.SetActive (true);
			ShowingHiding [8].gameObject.SetActive (true);
			if (PlayerSlector != 0)
				PriceText.text = PlayerPrice [PlayerSlector - 1].ToString ();
		}

		if (PlayerSlector == PlayerPrefs.GetInt ("Player")) {
			Debug.Log ("This is your Player");
			ShowingHiding [4].SetActive (true);
		} else
			ShowingHiding [4].SetActive (false);

		if (PlayerSlector == 0)
			ShowingHiding [11].gameObject.SetActive (false);
		else if (PlayerSlector == 7)
			ShowingHiding [12].gameObject.SetActive (false);
		else 
		{
			ShowingHiding [11].gameObject.SetActive (true);	
			ShowingHiding [12].gameObject.SetActive (true);	
		}
	}
   
  									 ///////////////////////////////////////////////////////////////////////////////////////
    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(2.5f);
        DialogBox[1].gameObject.SetActive(false);
        DialogBox[2].gameObject.SetActive(true);

    }

    public void Reset()
    {
        PlayerPrefs.SetInt("0", 1);
        PlayerPrefs.SetInt("1", 0);
        PlayerPrefs.SetInt("2", 0);
        PlayerPrefs.SetInt("3", 0);

    }

	void WaitForPlay()
	{
		
		Player.vec3 = Vector3.forward;

		FindObjectOfType<Player>().gameObject.GetComponent<Animator> ().SetBool ("Run" , true);
		FindObjectOfType<Player> ().RayCastStatus (true);
		InvokeRepeating ("ScoreUpdater", 1f,0.5f);
		Time.timeScale = 1;
		//StartScroing = true;
	}

	void ScoreUpdater ()
	{
		Player.Score++;
		if (!Player.isDead)
		FindObjectOfType<Player> ().UiScore.text  = Player.Score.ToString ();
	}

	void TimeScale()
	{
		Time.timeScale = 1;
	}

	IEnumerator SetActiveOffText()
	{		
		for (int i = 3; i >= 1; i--)
		{ 
			
			CountDown.text = i.ToString ();
			CountDown.gameObject.SetActive (true);
			yield return new WaitForSeconds (1);
			CountDown.gameObject.SetActive (false);
		}
		CountDown.gameObject.SetActive (true);
		CountDown.text = "Go !!!";
		yield return new WaitForSeconds (0.9f);
		CountDown.gameObject.SetActive (false);
		RotationControll = true;
		StartScroing = true;
	}

	public void ShowCanvas()
	{
		Canvas.SetActive (true);
	}
}
