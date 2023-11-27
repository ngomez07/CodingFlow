using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //este debe ser publico para que el boton acceda a el
    public void StartGame()
    {
        // lo hacemos igual que el finish
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
