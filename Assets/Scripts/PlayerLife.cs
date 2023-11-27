using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb; // RigidBody para cambiar el dinamico por estatico.
    private Animator anim;

    //Variable de soundeffect
    [SerializeField] private AudioSource deathSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        anim = GetComponent<Animator>(); // asignamos animacion
        rb = GetComponent<Rigidbody2D>(); // asignamos cuerpo rigido
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //puedes usar tambien collision.gameObject.tag == ""
        if (collision.gameObject.CompareTag("Trap"))
        {
            // metodo separado para hacerlo mas eficiente.
            Die();
        }
        
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; // asi es como se cambia con codio el Body Types
        anim.SetTrigger("death");
        deathSoundEffect.Play(); //sonido de muerto
    }

    // meotod de reinicio
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
