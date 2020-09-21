using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.SceneManagement;  
public class SceneChanger: MonoBehaviour {  
    public void Scene1() {  
        SceneManager.LoadScene("WelcomeScene");  
    }  
    public void Scene2() { 
        Debug.Log("faz algo?");
        SceneManager.LoadScene("DD_ARFoundation_GooglePoly");  
    }  
    public void Scene3() {  
        SceneManager.LoadScene("Scene3");  
    }  
}  