using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorLuces : MonoBehaviour

{
    public string luzTag = "Luz"; // Tag para encontrar las luces

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) // Detecta cuando se presiona la tecla L
        {
            ToggleLights();
        }
    }

    void ToggleLights()
    {
        GameObject[] luces = GameObject.FindGameObjectsWithTag(luzTag); // Busca todos los objetos con la tag "Luz"

        foreach (GameObject luzObjeto in luces)
        {
            Light luz = luzObjeto.GetComponent<Light>(); // Obtiene el componente Light

            if (luz != null)
            {
                luz.enabled = !luz.enabled; // Alterna entre encendido y apagado
            }
        }
    }
}


