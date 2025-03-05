using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour


{
    public static GameManager Instance;

    private int remainingCubes;
    private int collectedCubes = 0;

    public TextMeshProUGUI cubeCounterText; // Referencia al UI

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        remainingCubes = GameObject.FindGameObjectsWithTag("Cube").Length; // Contar los cubos en la escena
        UpdateUI(); // Actualizar la interfaz desde el inicio
    }

    public void CubeCollected()
    {
        collectedCubes++; // Aumenta el contador de recogidos
        remainingCubes--; // Reduce los cubos restantes

        UpdateUI(); // Actualiza el texto en pantalla

        if (remainingCubes <= 0)
        {
            Debug.Log("�Has ganado! Todos los cubos han sido recogidos.");
        }
    }

    void UpdateUI()
    {
        if (cubeCounterText != null)
        {
            cubeCounterText.text = "Cubos recogidos: " + collectedCubes;
        }
    }
}

