using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo4 : MonoBehaviour
{
    public float velocidadCirculo = 2.0f;
    public float radioVisionInicial = 5.0f;
    public float aumentoRadioVision = 1.0f;
    public int vida = 100;
    public GameObject balaPrefab;
    public Transform jugador;

    public delegate void Enemigo4VidaCambiada(int nuevaVida);
    public event Enemigo4VidaCambiada OnVidaCambiada;

    private float radioVision;
    private float tiempoUltimoDisparo;

    private void Start()
    {
        radioVision = radioVisionInicial;
        tiempoUltimoDisparo = Time.time;
    }

    private void Update()
    {
        Vector3 posicionOriginal = transform.position;
        Vector3 posicionActual = new Vector3(
            posicionOriginal.x + Mathf.Sin(Time.time * velocidadCirculo) * radioVision,
            posicionOriginal.y,
            posicionOriginal.z + Mathf.Cos(Time.time * velocidadCirculo) * radioVision
        );
        transform.position = posicionActual;

        float distanciaAlJugador = Vector3.Distance(jugador.position, transform.position);
        if (distanciaAlJugador <= radioVision)
        {
            Disparar();
        }
        radioVision += aumentoRadioVision * Time.deltaTime;
    }

    private void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, transform.position, Quaternion.identity);

    }

    public void RecibirDanio(int cantidadDanio)
    {
        vida -= cantidadDanio;
        if (vida <= 0)
        {
            vida = 0;
        }
        OnVidaCambiada?.Invoke(vida);
    }
}
