using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : MonoBehaviour
{
    public float velocidadInicial = 2.0f;
    public float velocidadMaxima = 5.0f;
    public int vida = 50;

    public delegate void Enemigo1VidaCambiada(int nuevaVida);
    public event Enemigo1VidaCambiada OnVidaCambiada;

    private Vector3 direccionMovimiento = Vector3.left;
    private float velocidadActual;

    private void Start()
    {
        velocidadActual = velocidadInicial;
    }

    private void Update()
    {
        transform.Translate(direccionMovimiento * velocidadActual * Time.deltaTime);

        velocidadActual = Mathf.Min(velocidadMaxima, velocidadActual + Time.deltaTime * 0.1f);
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
