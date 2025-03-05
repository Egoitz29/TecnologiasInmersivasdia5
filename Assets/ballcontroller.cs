using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour

{
    public float forceAmount = 10f; // Fuerza aplicada a la bola
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtiene el Rigidbody
    }

    void FixedUpdate()
    {
        Vector3 forceDirection = Vector3.zero;

        // Controles básicos
        if (Input.GetKey(KeyCode.W)) forceDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) forceDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A)) forceDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) forceDirection += Vector3.right;

        // Aplica la fuerza en la dirección deseada
        rb.AddForce(forceDirection * forceAmount, ForceMode.Impulse);
    }
}


