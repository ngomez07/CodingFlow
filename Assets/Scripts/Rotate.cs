using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    // declaramos la velocidad de movimiento, cuantas veces la rotamos 360/s
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        // rotate recibe un vector con las direcciones que queremos rotar.
        transform.Rotate(0,0,360*speed*Time.deltaTime);
    }

}
