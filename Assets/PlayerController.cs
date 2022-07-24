using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    private Rigidbody rb;

    public string propName = "Propulsion";
    public string hName = "Horizontal";
    public string vName = "Vertical";

    public float propForce = 10;

    public Vector3 velocityVector;
    public Vector3 rotation;

    public float propulsionLoss = 2f;
    public float rotationLoss = 2f;

    public ParticleSystem ps;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        velocityVector = Vector3.zero;
        ps.Stop();
    }

    void Update()
    {
        velocityVector = Vector3.Lerp(velocityVector, Vector3.zero, Time.deltaTime * propulsionLoss);
        rotation = Vector3.Lerp(rotation, Vector3.zero, Time.deltaTime * rotationLoss);
        if (Input.GetButton(propName))
        {
            // propulsion
            ps.Play();
            velocityVector = transform.forward * propForce;
        }

        rotation = new Vector3(Input.GetAxis(vName), Input.GetAxis(hName), 0);

        //rotation = Quaternion.Euler(r);
    }

    void FixedUpdate()
    {
        rb.AddForce(velocityVector);
        rb.AddTorque(rotation);
    }
}
