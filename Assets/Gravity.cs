using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // requiere el componente rigidbody y de no tenerlo lo agrega
public class Gravity : MonoBehaviour
{

    private Rigidbody rb;

    public Transform target;

    public float force = 9.81f; // gravedad de la tierra, la luna tiene 1.62

    void Awake() // corre antes de arrancar la escena
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void FixedUpdate()
    {
        // calcular la posicion de la luna con respecto a la de la nave
        //target.position
        // cual es el vector mas directo entre los 2 puntos
        Vector3 gravity = (target.position - transform.position).normalized * force;
        rb.AddForce(gravity);
    }

}
