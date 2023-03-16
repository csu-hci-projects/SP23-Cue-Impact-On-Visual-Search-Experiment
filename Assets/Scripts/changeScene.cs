using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour
{
    public int sceneNum;
    public void changetheScene() {
        SceneManager.LoadScene(sceneNum);
    }
    
}