using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject Canvas;
	public Image[] LogoImages;
	public GameObject[] DialogBox;
    public GameObject[] Players;
    public static bool GameOnOff;
    private  int PlayerSlector;
    public GameObject BuyButton;
    public GameObject Lock;
    public Text PriceText;
	public GameObject EnoughPrice;
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
	public SoundController SC;
	public Slider Music;
	public Slider Sound;

    void Start ()
    {
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		RotationControll = false;
		shop = false;
		Player.isDead = false;
        DialogBox [0].gameObject.SetActive (true);
		GameOnOff = false;
        PlayerSlector = PlayerPrefs.GetInt("Player");
        Players[PlayerSlector].gameObject.SetActive(true);
        ShowBuyButton();
		FindObjectOfType<Player> ().RayCastStatus (false);
		PlayerPrefs.SetInt("0", 1);
		ShowingHiding [13].SetActive (false);

		Music.GetComponent<Slider> ().enabled = true;
		Sound.GetComponent<Slider> ().enabled = true;
		if (PlayerPrefs.GetInt ("FirstStart") == 0) 
		{
			SC.music.volume = 1f;
			SC.sound.volume = 1f;
			PlayerPrefs.SetInt ("FirstStart", 1);
		} 
		else
		{
			Music.value = PlayerPrefs.GetFloat ("Music");
			SC.music.volume = Music.value;
			Sound.value = PlayerPrefs.GetFloat ("Sound");
			SC.sound.volume = Sound.value;


		}
	
		SC=FindObjectOfType<SoundController>();

		if (PlayerPrefs.GetInt ("Restart") == 1) 
		{
			OnPlay ();
			PlayerPrefs.SetInt ("Restart", 0);
		}
    }


	public void UpdateSlider()
	{

		SC.music.volume = Music.value;
		SC.sound.volume = Sound.value;

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

		UpdateSlider ();


	}

	public void Exit()
	{
		SC.playSound ("Button");
		Application.Quit ();
	}

	public void OnRetry()
	{


	//	Application.LoadLevel(0);
	}

    public void OnPlay()
    {
		SC.playSound ("Button");
		ShowingHiding[0].SetActive(true);
		ShowingHiding[1].SetActive(true);
		ShowingHiding[6].SetActive(true);
		ShowingHiding[7].SetActive(true);
		//ShowingHiding[9].SetActive(true);
		GameOnOff = true;
		StartCoroutine (SetActiveOffText ());

    }

	void DeadSolution()
	{
		RayStart = true;
	}
    public void OnPlaySlection()
    {
		SC.playSound ("Button");
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
		SC.playSound ("Button");
		DialogBox [4].SetActive (true);
	}

	public void SaveMusicSetting()
	{
		SC.playSound ("Button");
		SC.SetMusicVolume (Music.value);
		SC.SetSoundVolume (Sound.value);
		PlayerPrefs.Save ();
		DialogBox [4].SetActive (false);

	}

	public void Pause_btn()
	{
		SC.playSound ("Button");
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
		SC.playSound ("Button");
		StartCoroutine (SetActiveOffText ());

		FindObjectOfType<Player> ().GetComponent<Animator> ().SetBool ("Run", true);

		ShowingHiding[0].SetActive(true);
		ShowingHiding[1].SetActive(true);
		ShowingHiding[6].SetActive(true);
		ShowingHiding[7].SetActive(true);
		ShowingHiding[10].SetActive(false);

	}

	public void OnRestart()
	{
		PlayerPrefs.SetInt ("Restart" , 1);
	}


	/// ////////////////////////////////////////////Player Slection Screen
  


    public void PlayerSlection_Nextbtn()
    {
		SC.playSound ("Button");
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
		
		SC.playSound ("Button");
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
		SC.playSound ("Button");
        PlayerPrefs.SetInt("Player", PlayerSlector);
		Application.LoadLevel (0);
		//ShowBuyButton ();
    }

    public void PlayerSlection_BacktoMainMenubtn()
    {
		SC.playSound ("Button");
        DialogBox[3].gameObject.SetActive(false);
        DialogBox[0].gameObject.SetActive(true);
		ShowingHiding[5].SetActive(true);
        isKinematic = false;
        shop = false;
        ShowingHiding[2].SetActive(true);
        ShowingHiding[3].SetActive(false);
        ShowingHiding[4].SetActive(false);
		LogoImages [1].gameObject.SetActive (true);
		LogoImages [0].gameObject.SetActive (true);
    }

    public void OnBuyButton()
    {
		SC.playSound ("Button");
		if (Player.coinScore >= PlayerPrice [PlayerSlector - 1]) {
			BuyButton.gameObject.SetActive (false);
			PlayerPrefs.SetInt ((PlayerSlector).ToString (), 1);
			Sold = PlayerPrefs.GetInt ((PlayerSlector - 1).ToString ());
			PlayerPrefs.SetInt ("CoinInt", (Player.coinScore - PlayerPrice [PlayerSlector - 1]));
			Player.coinScore = PlayerPrefs.GetInt ("CoinInt");
            
		} else 
		{
			StartCoroutine (EnoughPriceTimer ());
		}
        ShowBuyButton();

    }

	IEnumerator EnoughPriceTimer()
	{
		EnoughPrice.gameObject.SetActive (true);
		yield return new WaitForSeconds (1f);
		EnoughPrice.gameObject.SetActive (false);
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



	IEnumerator SetActiveOffText()
	{		
		for (int i = 3; i >= 1; i--)
		{ 
			
			CountDown.text = i.ToString ();
			CountDown.gameObject.SetActive (true);
			//yield return new WaitForSeconds (1);
			yield return StartCoroutine(TimeScale0CoRoutine.WaitForRealTime(1));
			CountDown.gameObject.SetActive (false);
		}
		CountDown.gameObject.SetActive (true);
		CountDown.text = "Go !!!";
		//yield return new WaitForSeconds (0.9f);
		yield return StartCoroutine(TimeScale0CoRoutine.WaitForRealTime(0.9f));
		CountDown.gameObject.SetActive (false);
		RotationControll = true;
		StartScroing = true;
		WaitForPlay ();
		ShowingHiding[9].SetActive(true);

	}

	public void ShowCanvas()
	{
		Canvas.SetActive (true);
	}

	public void LogoImage1()
	{
		LogoImages [0].gameObject.SetActive (false);
	}
	public void LogoImage2()
	{
		LogoImages [1].gameObject.SetActive (false);
	}



	public void RateUS()
	{
		SC.playSound ("Button");
		Application.OpenURL ("https://www.facebook.com/braingamesstd/");
	}
}
