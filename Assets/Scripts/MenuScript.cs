using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuScript : MonoBehaviour
{
	public Slider slider;

	void Awake()
	{
		slider.value = PlayerPrefs.GetFloat ("Difficult");

	}

	//This function gets called by the save button 
	public   void SaveDifficult(float a)
	{
		PlayerPrefs.SetFloat("Difficult", a);
		Debug.Log("SAVED Difficult"+PlayerPrefs.GetFloat("Difficult"));
	}

    //This function gets called by the load button 
    public static float LoadDifficult()
	{
		Debug.Log ("LOADED Diffcult "+PlayerPrefs.GetFloat("Difficult"));
		return PlayerPrefs.GetFloat("Difficult");
	}

    //This function gets called by the play button 
    public void PlayGame()
	{
		SceneManager.LoadScene("Main");
	}

	public void Exit(){
		//SceneManager.UnloadSceneAsync ("Main");
		//SceneManager.UnloadSceneAsync ("Menu");
		Debug.Log("Quit");
		Application.Quit();
	}




}
