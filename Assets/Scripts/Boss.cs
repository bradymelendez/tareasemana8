using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int vidaMaxima = 500;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public Transform jugador;
    public float velocidadCirculo = 2.0f;
    public float radioVisionInicial = 5.0f;
    public float aumentoRadioVision = 1.0f;

    private int vidaActual;
    private float radioVision;
    private float tiempoUltimoDisparo;

    private void Start()
    {
        vidaActual = vidaMaxima;
        radioVision = radioVisionInicial;
        tiempoUltimoDisparo = Time.time;
    }

    private void Update()
    {
        MoverEnCirculo();
        VerificarDisparo();
        AumentarRadioVision();
    }

    private void MoverEnCirculo()
    {
        Vector3 posicionOriginal = transform.position;
        Vector3 posicionActual = new Vector3(
            posicionOriginal.x + Mathf.Sin(Time.time * velocidadCirculo) * radioVision,
            posicionOriginal.y,
            posicionOriginal.z + Mathf.Cos(Time.time * velocidadCirculo) * radioVision
        );
        transform.position = posicionActual;
    }

    private void VerificarDisparo()
    {
        float distanciaAlJugador = Vector3.Distance(jugador.position, transform.position);
        if (distanciaAlJugador <= radioVision)
        {
            if (Time.time - tiempoUltimoDisparo >= 1.0f)
            {
                Disparar();
                tiempoUltimoDisparo = Time.time;
            }
        }
    }

    private void AumentarRadioVision()
    {
        radioVision += aumentoRadioVision * Time.deltaTime;
    }

    private void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
    }

    public void RecibirDanio(int cantidadDanio)
    {
        vidaActual -= cantidadDanio;
        if (vidaActual <= 0)
        {
            vidaActual = 0;
        }
    }
}
