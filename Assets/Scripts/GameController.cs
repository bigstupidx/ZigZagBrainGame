using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

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

    public static bool isKinematic = false; 
  
   
    void Start ()
    {

        //PlayerPrefs.SetInt("0", 1);
        
        DialogBox [0].gameObject.SetActive (true);
        GameOnOff = false;
        PlayerSlector = PlayerPrefs.GetInt("Player");
        Players[PlayerSlector].gameObject.SetActive(true);
        ShowBuyButton();
        shop = false;
        //  ShowingHiding[0].SetActive(false);
        //  ShowingHiding[1].SetActive(false);
        Debug.Log(isKinematic);
    }

    void Update ()
    {
       
		if (GameOnOff && !Player.isDead) 
		{
			DialogBox [0].gameObject.SetActive (false);
			DialogBox [1].gameObject.SetActive (true);
		}
		else if (Player.isDead) 
		{
            StartCoroutine(GameOverDelay());			
		}
        ///// 

	}


	public void OnRetry()
	{
		Application.LoadLevel(0);
	}

    public void OnPlay()
    {
        GameOnOff = true;
        Player.vec3 = Vector3.forward;
        ShowingHiding[0].SetActive(true);
        ShowingHiding[1].SetActive(true);
    }

    public void OnPlaySlection()
    {
        DialogBox[0].gameObject.SetActive(false);
        DialogBox[3].gameObject.SetActive(true);
        shop = true;
        ShowingHiding[2].SetActive(false);
        ShowingHiding[3].SetActive(true);
        ShowingHiding[4].SetActive(true);
      

        isKinematic = true;
        Debug.Log(isKinematic);
    }

    /// <summary>
    /// ////////////////////////////////////////////Player Slection Screen
    /// </summary>


    public void PlayerSlection_Nextbtn()
    {
        if ( PlayerSlector != 3)
        {
            Players[PlayerSlector].gameObject.SetActive(false);
            Players[PlayerSlector +1].gameObject.SetActive(true);
            PlayerSlector = PlayerSlector + 1;
            ShowBuyButton();

        }

        /*
        if (PlayerSlector == 0)
        {

            Players[0].gameObject.SetActive(false);
            Players[1].gameObject.SetActive(true);
            PlayerSlector = 1;
            ShowBuyButton();

        }
        else if (PlayerSlector == 1)
        {
            Players[1].gameObject.SetActive(false);
            Players[2].gameObject.SetActive(true);
            PlayerSlector = 2;
            ShowBuyButton();
        }
      
        */
    }

    public void PlayerSlection_Backbtn()
    {
        if( PlayerSlector != 0)
        {
            Players[PlayerSlector].gameObject.SetActive(false);
            Players[PlayerSlector -1].gameObject.SetActive(true);
            PlayerSlector = PlayerSlector -1;
            ShowBuyButton();
        }
        else if ( PlayerSlector == 0)
        {
            BuyButton.gameObject.SetActive(false);
            Lock.gameObject.SetActive(false);
            PriceText.gameObject.SetActive(false);

        }



        /*
        if (PlayerSlector == 1)
        {

            Players[1].gameObject.SetActive(false);
            Players[0].gameObject.SetActive(true);
            PlayerSlector = 0;
            ShowBuyButton();
        }
        else if (PlayerSlector == 2)
        {
            Players[2].gameObject.SetActive(false);
            Players[1].gameObject.SetActive(true);
            PlayerSlector = 1;
            ShowBuyButton();
        }
        */
    }

    public void PlayerSlection_Usebtn()
    {
        PlayerPrefs.SetInt("Player", PlayerSlector);
    }




    public void PlayerSlection_BacktoMainMenubtn()
    {
        DialogBox[3].gameObject.SetActive(false);
        DialogBox[0].gameObject.SetActive(true);
        isKinematic = false;
        Application.LoadLevel(0);
        shop = false;
        ShowingHiding[2].SetActive(true);
        ShowingHiding[3].SetActive(false);
        ShowingHiding[4].SetActive(false);
       
        Debug.Log(isKinematic);

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
        if (PlayerPrefs.GetInt (PlayerSlector.ToString()) == 1)
        {
            BuyButton.gameObject.SetActive(false);
            Lock.gameObject.SetActive(false);
            PriceText.gameObject.SetActive(false);

        }
        else
        {
            BuyButton.gameObject.SetActive(true);
            Lock.gameObject.SetActive(true);
            PriceText.gameObject.SetActive(true);
            PriceText.text = PlayerPrice[PlayerSlector - 1].ToString();

            /*
            if (PlayerSlector == 1)
                PriceText.text = PlayerPrice[PlayerSlector-1].ToString();
            else 
            if(PlayerSlector == 2)
                PriceText.text = PlayerPrice[PlayerSlector-1].ToString();
            else
            if (PlayerSlector == 3)
                PriceText.text = PlayerPrice[PlayerSlector - 1].ToString();
            */
        }
    } 
   
    /// ///////////////////////////////////////////////////////////////////////////////////////
    IEnumerator GameOverDelay()
    {
        yield return new WaitForSeconds(0.5f);
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

}
