using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;

public class SceneChanger: MonoBehaviour {  
	public void Scene1() {  
		SceneManager.LoadScene("WelcomeScene");  
	}  

	public void SceneWithFirebase() {
		DD_Asset_Menu_UI_Screen.ChangeSearch("firebase");
		SceneManager.LoadScene("DD_ARFoundation_GooglePoly");
	}  
	public void SceneWithGooglePoly() {
		DD_Asset_Menu_UI_Screen.ChangeSearch("poly");
		SceneManager.LoadScene("DD_ARFoundation_GooglePoly");  
	}      	

	public void Scene3() {  
		SceneManager.LoadScene("Scene3");  
	}  
}  