using UnityEngine;
using System.Collections;

public class colorController : MonoBehaviour {
    private bool changed = false;
    public int count;
    public static Color currentColor;
    public Color Startcolor;
    // Use this for initialization
    void Start ()
    {
      colorChanger();
        //   Startcolor = new Color(4B, BC, 0.4F, 0.5F);
        currentColor = Color.blue;
    }
	
	// Update is called once per frame
	void Update () {
        colorChanger();
   
    }

    void colorChanger()
    {
        if (Player.Score >= 10 && Player.Score % 10 == 0)
        {
            if (!changed)
            {
                if (count == 0)
                {
                    currentColor = Color.red;
                    count = 1;
                }

                else if (count == 1)
                {
                    currentColor = Color.green;
                    count = 2;
                }

                else if (count == 2)
                {
                    currentColor = Color.grey;
                    count = 0;
                }
                changed = true;
            }
        }
        else
        {
            changed = false;
       
      
}

    }
}
