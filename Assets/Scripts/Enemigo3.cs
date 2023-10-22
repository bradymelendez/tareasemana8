using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3 : MonoBehaviour
{
    public float velocidadInicial = 2.0f;
    public float velocidadMaxima = 5.0f;
    public int vida = 80;
    public float tiempoCambioDireccion = 5.0f;
    public float tiempoDisparo = 2.0f;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public Transform jugador;

    public delegate void Enemigo3VidaCambiada(int nuevaVida);
    public event Enemigo3VidaCambiada OnVidaCambiada;

    private Vector3 direccionMovimiento;
    private float velocidadActual;
    private float tiempoUltimoCambioDireccion;
    private float tiempoUltimoDisparo;

    private void Start()
    {
        velocidadActual = velocidadInicial;

        tiempoUltimoCambioDireccion = Time.time;
        tiempoUltimoDisparo = Time.time;

        direccionMovimiento = Vector3.right;
    }
    private void Update()
    {
        transform.Translate(direccionMovimiento * velocidadActual * Time.deltaTime);

        if (Time.time - tiempoUltimoCambioDireccion >= tiempoCambioDireccion)
        {
            CambiarDireccion();
            tiempoUltimoCambioDireccion = Time.time;
        }

        if (Time.time - tiempoUltimoDisparo >= tiempoDisparo)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }

        velocidadActual = Mathf.Min(velocidadMaxima, velocidadActual + Time.deltaTime * 0.1f);
    }

    private void CambiarDireccion()
    {
        direccionMovimiento = (jugador.position - transform.position).normalized;
    }

    private void Disparar()
    {

        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
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
