using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0; //cantidad de cherries

    [SerializeField] private Text cherriesText;

    //variable de sonido para recolectar frutas
    [SerializeField] private AudioSource collectionSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            //asi sabemos que chocamos con la fruta.
            Destroy(collision.gameObject);
            //Hacemos sonido de recollectar
            collectionSoundEffect.Play();
            cherries++; // sumo una cada vez que pasa.
            cherriesText.text = "Cherries: " + cherries;
        }
    }
}
