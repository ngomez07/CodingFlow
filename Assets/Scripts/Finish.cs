using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    // esta vez no necesitamos el [SerializeField] porque solo tenemos un audio
    private AudioSource finishSound;
    // Vamos a agregar un bool para solucionar que el jugador se mueve despues de tocar el finish
    private bool levelCompleted = false;

    void Start()
    {
        finishSound = GetComponent<AudioSource>(); // no se confunde ya podemos agregarlo por script   
    }

    // como el collider es trigger usamos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // de la misma forma que hacemos el de muerte
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            finishSound.Play();
            levelCompleted = true;
            // vamos a usar el invoke para que se demore un poco
            Invoke("CompleteLevel", 2f); //va a esperar 2s y encuentra la primera funcion con el nombre
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }



}
