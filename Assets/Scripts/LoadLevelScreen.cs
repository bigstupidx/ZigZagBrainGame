using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevelScreen : MonoBehaviour {


    public GameObject LoadingScreen;
    public Slider slider;
    public Text text; 
    public void LoadLevel(int LevelIndex)
    {
        LoadingScreen.SetActive(true);
        StartCoroutine(LoadingAsynchronously(LevelIndex));
    }
       
    IEnumerator LoadingAsynchronously (int LevelIndex)
    {

        AsyncOperation Operation = SceneManager.LoadSceneAsync(LevelIndex);
       
        while (!Operation.isDone)
        {
            float prograss = Mathf.Clamp01(Operation.progress / 0.9f);
            slider.value = prograss ;
            text.text = prograss * 100 + "%";

            yield return null;
        }
    }

}
