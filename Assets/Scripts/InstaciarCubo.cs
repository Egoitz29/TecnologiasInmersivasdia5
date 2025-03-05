using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class InstaciarCubo : MonoBehaviour

{
    public GameObject cuboPrefab; // Prefab del cubo (opcional, si usas uno personalizado)
    private GameObject cuboInstanciado; // Referencia al cubo instanciado

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Detecta la tecla "E"
        {
            if (cuboInstanciado == null) // Verifica si el cubo ya existe
            {
                InstanciarCuboEnEscena();
            }
        }
    }

    void InstanciarCuboEnEscena()
    {
        if (cuboPrefab != null)
        {
            // Instancia un cubo desde un prefab si existe
            cuboInstanciado = Instantiate(cuboPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            // Instancia un cubo primitivo si no hay prefab
            cuboInstanciado = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cuboInstanciado.transform.position = new Vector3(0, 1, 0); // Posición inicial
        }
    }
}


