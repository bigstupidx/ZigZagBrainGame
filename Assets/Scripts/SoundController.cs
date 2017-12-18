using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {


	public AudioSource music;
	public AudioSource sound;
	public AudioClip[] sounds;

	private static SoundController instance = null;
	void Awake(){
		sound =  GameObject.Find ("Sound").GetComponent<AudioSource>() ;
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(this.gameObject);
			return;
		}
		Destroy(this.gameObject);
	}

	public  void playSound(string soundName)
	{
		for (int i = 0; i < sounds.Length; i++) {
			if ( sound &&  sounds [i].name == soundName)
				sound.PlayOneShot (sounds [i]);
		
		}



	}

	public void SetMusicVolume(float val)
	{
		music.volume = val;
		PlayerPrefs.SetFloat ("Music", music.volume);

	}

	public void SetSoundVolume(float val)
	{
		sound.volume = val;
		PlayerPrefs.SetFloat ("Sound", sound.volume);
	}

}
