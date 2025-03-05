using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class InstaciarCubo : MonoBehaviour

{
    public GameObject cuboPrefab; // Prefab del cubo (opcional)
    private GameObject cuboInstanciado; // Referencia al cubo instanciado

    public Vector3 posicionA = new Vector3(0, 1, 0); // Posición inicial
    public Vector3 posicionB = new Vector3(5, 1, 0); // Posición final

    public float duracionMovimiento = 2f; // Duración del movimiento en segundos

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Detecta la tecla "E"
        {
            if (cuboInstanciado == null) // Si el cubo no existe, lo instancia
            {
                InstanciarCubo();
                StartCoroutine(MoverCubo(posicionA, posicionB, duracionMovimiento)); // Inicia el movimiento
            }
        }
    }

    void InstanciarCubo()
    {
        if (cuboPrefab != null)
        {
            cuboInstanciado = Instantiate(cuboPrefab, posicionA, Quaternion.identity);
        }
        else
        {
            cuboInstanciado = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cuboInstanciado.transform.position = posicionA; // Coloca el cubo en la posición inicial
        }
    }

    IEnumerator MoverCubo(Vector3 inicio, Vector3 fin, float duracion)
    {
        float tiempo = 0;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracion; // Normaliza el tiempo (0 a 1)
            cuboInstanciado.transform.position = Vector3.Lerp(inicio, fin, t); // Interpola entre A y B
            yield return null; // Espera hasta el siguiente frame
        }

        cuboInstanciado.transform.position = fin; // Asegura que termine en la posición exacta
    }
}



