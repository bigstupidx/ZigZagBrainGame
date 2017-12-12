using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript : MonoBehaviour {

	/// <summary>
	/// T//////////////////This Script should give Empty_Game_Object and Music Or Sound is in Herriarchy of Empty_Game_Object 


	public AudioSource Music;

	//public GameObject buttonOFF;
	// Use this for initialization
	void Start () {
		
	}

    //Play Global
    private static BGSoundScript instance = null;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    //Play Gobal End

    // Update is called once per frame
    void Update ()
	{


		
	}


	/*
	public void MusicOnOff()
	{
		if (checkMusic == 0) 
		{
			PlayerPrefs.SetInt ("Music", 1);
			checkMusic = PlayerPrefs.GetInt ("Music");
			Music.gameObject.SetActive (false);
			//buttonOFF.gameObject.SetActive (true);
		}
		else if ( checkMusic == 1)
		{
			PlayerPrefs.SetInt ("Music", 0);
			checkMusic = PlayerPrefs.GetInt ("Music");
			Music.gameObject.SetActive (true);
			//buttonOFF.gameObject.SetActive (false);
		}

	}
*/
}
