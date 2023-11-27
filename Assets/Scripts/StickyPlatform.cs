using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // para activar los triggers usamos esta forma de codigo, asi distinguismo entre los colliders, ahora vamos a usar triggers.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // queremos ponerlo como un hijo de la plataforma, para esto:
            collision.gameObject.transform.SetParent(transform);
            // ojo el transform del set parent, es el transform de la plataforma que tiene el script
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // ahora en vez el transform de la plataforma queremos quitarle esto entonces ponemos null
            collision.gameObject.transform.SetParent(null);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    // como solo tenemos un jugador no tenemos que agregar un detect porque solo tenemos un jugador
    //    // por esto no tenemos que usar un tag como lo hicimos con las frutas
    //    if (collision.gameObject.name == "Player")
    //    {
    //        // queremos ponerlo como un hijo de la plataforma, para esto:
    //        collision.gameObject.transform.SetParent(transform);
    //        // ojo el transform del set parent, es el transform de la plataforma que tiene el script
    //    }
    //}

    //// ahora vamos a hacer uno para cuando el jugador no esta tocando la plataforma.
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "Player")
    //    {
    //        // ahora en vez el transform de la plataforma queremos quitarle esto entonces ponemos null
    //        collision.gameObject.transform.SetParent(null);
    //    }
    //}
}
