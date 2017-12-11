using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Button_On_Tapping : MonoBehaviour {

	public RectTransform[] ControlButtons ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	Vector2 insidePoints;
	public bool ExclusionOfUIButtons(Vector2 position)
	{ 
		for(int i=0;i<ControlButtons.Length;i++)
		{
			
			if(RectTransformUtility.ScreenPointToLocalPointInRectangle(ControlButtons[i], position,null,out insidePoints))
			{
				if(ControlButtons[i].rect.Contains(insidePoints))
				{
					Debug.Log(ControlButtons[i].name);
					return true; 
				}
				else
				{ 
					Debug.Log( "Outside PointName+ "+ControlButtons[i].name);
				} 
			}
		} 
		return false; 
	}
}
