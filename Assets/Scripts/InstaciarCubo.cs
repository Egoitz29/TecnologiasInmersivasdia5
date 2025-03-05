using System.Collections;
using UnityEngine;

public class InstanciarCubo : MonoBehaviour
{
    private GameObject cuboInstanciado; // Referencia al cubo instanciado

    public Vector3 posicionA = new Vector3(0, 1, 0); // Posici�n inicial
    public Vector3 posicionB = new Vector3(5, 1, 0); // Posici�n final

    public float duracionMovimiento = 2f; // Duraci�n del movimiento en segundos
    public float duracionRotacion = 1.5f; // Duraci�n de la rotaci�n en segundos
    public float tiempoEspera = 1f; // Tiempo de espera antes de volver

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Detecta la tecla "E"
        {
            if (cuboInstanciado == null) // Si el cubo no existe, lo instancia
            {
                InstanciarCubo1();
                StartCoroutine(MoverCubo(posicionA, posicionB, duracionMovimiento));
            }
        }
    }

    void InstanciarCubo1()
    {
        cuboInstanciado = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cuboInstanciado.transform.position = posicionA; // Coloca el cubo en la posici�n inicial
    }

    IEnumerator MoverCubo(Vector3 inicio, Vector3 fin, float duracion)
    {
        float tiempo = 0;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracion;
            cuboInstanciado.transform.position = Vector3.Lerp(inicio, fin, t); // Interpola la posici�n
            yield return null;
        }

        cuboInstanciado.transform.position = fin; // Asegura la posici�n final
        yield return new WaitForSeconds(tiempoEspera); // Espera antes de rotar

        StartCoroutine(RotarCubo(Quaternion.Euler(0, 90, 0), duracionRotacion)); // Inicia la rotaci�n
    }

    IEnumerator RotarCubo(Quaternion rotacionFinal, float duracion)
    {
        Quaternion rotacionInicial = cuboInstanciado.transform.rotation;
        float tiempo = 0;

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracion;
            cuboInstanciado.transform.rotation = Quaternion.Slerp(rotacionInicial, rotacionFinal, t); // Interpola la rotaci�n
            yield return null;
        }

        cuboInstanciado.transform.rotation = rotacionFinal; // Asegura la rotaci�n final
        yield return new WaitForSeconds(tiempoEspera); // Espera antes de volver a la posici�n inicial

        StartCoroutine(VolverAPosicion(duracionMovimiento)); // Primero vuelve a la posici�n
    }

    IEnumerator VolverAPosicion(float duracionMov)
    {
        float tiempo = 0;
        Vector3 posicionInicial = posicionB;
        Vector3 posicionFinal = posicionA;

        while (tiempo < duracionMov)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracionMov;
            cuboInstanciado.transform.position = Vector3.Lerp(posicionInicial, posicionFinal, t); // Vuelve a la posici�n
            yield return null;
        }

        cuboInstanciado.transform.position = posicionFinal; // Asegura la posici�n inicial
        yield return new WaitForSeconds(tiempoEspera); // Espera antes de volver a la rotaci�n original

        StartCoroutine(VolverARotacion(duracionRotacion)); // Luego vuelve a la rotaci�n
    }

    IEnumerator VolverARotacion(float duracionRot)
    {
        float tiempo = 0;
        Quaternion rotacionInicial = Quaternion.Euler(0, 90, 0);
        Quaternion rotacionFinal = Quaternion.identity; // Rotaci�n inicial (sin rotaci�n)

        while (tiempo < duracionRot)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracionRot;
            cuboInstanciado.transform.rotation = Quaternion.Slerp(rotacionInicial, rotacionFinal, t); // Vuelve a la rotaci�n original
            yield return null;
        }

        cuboInstanciado.transform.rotation = rotacionFinal; // Asegura la rotaci�n inicial
    }
}



