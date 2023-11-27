using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll; // variable referencia al box collider del jugador
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround; // variable para pasar la capa

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    // variable para el audiosource, no vamos a usar get component porque no vamos a porderlas diferenciar
    // vamos a agregar varios audiosource. vamos a agregarlo...
    [SerializeField] private AudioSource jumpSoundEffect;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>(); // asignamos el collider para el codigo
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        //left will be -1, right will be 1, por eso es axis y no button
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * dirX, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            // usando && revisamos las dos cosas y la funcion retorna verdadero o falso
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            // agregamos el sonido
            jumpSoundEffect.Play();
        }

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        // este debe ser un if, porque como cuando estamos en el aire,
        // queremos que tenga mas prioridad, por eso no es else if
        // ponemos .1, porque nunca es exactamente 0, por eso jugamos con este valor.

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        // usamos (int)state, para pasar el entero correspondiente y no el nombre
        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 1f, jumpableGround);
        // ahora revisa si la caja que creamos, esta sobrelapando con la capa para saltar.
        //0f porque la caja no debe rotar.
        // .1f, porque queremos moverla hacia abajo para asegurar sobrelapar,
        // coll.bounds para sacar las dimancione sy el centro de la caja nueva que estamos haciendo con BoxCast.
        // return porque es una funcion es un metodo y no un procedimiento.
    }
}
