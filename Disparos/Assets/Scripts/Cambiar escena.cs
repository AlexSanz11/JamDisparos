using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cambiarescena : MonoBehaviour
{
   public void cambiarescena(int scene)
    {
        Time.timeScale = 1;
        if (scene == 99)
        {
            Application.Quit();
        }
        else 
        {
            SceneManager.LoadScene(scene);
        }
    }
}
