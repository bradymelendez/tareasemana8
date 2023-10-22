using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2 : MonoBehaviour
{
    public float velocidadInicial = 2.0f;
    public float velocidadMaxima = 5.0f;
    public int vida = 60;
    public float tiempoCambioDireccion = 5.0f;
    public float tiempoEntreDisparos = 2.0f;
    public GameObject balaPrefab;
    public Transform puntoDisparo;

    public delegate void Enemigo2VidaCambiada(int nuevaVida);
    public event Enemigo2VidaCambiada OnVidaCambiada;

    private Vector3 direccionMovimiento;
    private float velocidadActual;
    private float tiempoUltimoCambioDireccion;
    private float tiempoUltimoDisparo;

    private void Start()
    {
        velocidadActual = velocidadInicial;

        direccionMovimiento = Vector3.right;

        tiempoUltimoCambioDireccion = Time.time;
        tiempoUltimoDisparo = Time.time;
    }

    private void Update()
    {
        transform.Translate(direccionMovimiento * velocidadActual * Time.deltaTime);
        if (Time.time - tiempoUltimoCambioDireccion >= tiempoCambioDireccion)
        {
            CambiarDireccion();
            tiempoUltimoCambioDireccion = Time.time;
        }
        if (Time.time - tiempoUltimoDisparo >= tiempoEntreDisparos)
        {
            Disparar();
            tiempoUltimoDisparo = Time.time;
        }
        velocidadActual = Mathf.Min(velocidadMaxima, velocidadActual + Time.deltaTime * 0.1f);
    }

    private void CambiarDireccion()
    {
        direccionMovimiento = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f)).normalized;
    }

    private void Disparar()
    {
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        Destroy(bala, 3f);
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
