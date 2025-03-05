using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboPuntos : MonoBehaviour
{
    public float rotationSpeed = 3f; // Velocidad de giro en grados por segundo

    private void Update()
    {
        // Rotar continuamente el cubo en los ejes Y y X para hacerlo más visible
        transform.Rotate(new Vector3(15, 30, 45) * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que la esfera tiene el tag "Player"
        {
            GameManager.Instance.CubeCollected(); // Notifica al GameManager
            Destroy(gameObject); // Destruye el cubo al tocar la esfera
        }
    }
}




