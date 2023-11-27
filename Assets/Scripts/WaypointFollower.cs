using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    // queremos ponerle un array para que podamos ponerle varios waypoints
    // si le ponemos de a un objeto tendriamos que modificarlo por cada vez que hagamos esto

    [SerializeField] private GameObject[] waypoints; 
    // recuerda que los waypoints siguen siendo objetos, usamos los [] porque queremos que sea un arreglo

    private int currentWaypointIndex = 0; // esta variable va a estraer los indices de los waypoints.
    [SerializeField] private float speed = 2f; // movimientos


    private void Update()
    {
        // Vector2.Distance(), calcula la distancia entre dos vectores.
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position)<.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        // movimiento de la pataforma.
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime*speed);
        
    }
}
