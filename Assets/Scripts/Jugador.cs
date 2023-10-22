using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public int vida = 100;
    public Arma armaActual;

    // Definir un delegado para gestionar eventos relacionados con la vida del jugador.
    public delegate void JugadorVidaCambiada(int nuevaVida);
    public event JugadorVidaCambiada OnVidaCambiada;

    private void Start()
    {
        armaActual = new Pistola();
    }

    private void Update()
    {
        Mover();
        Disparar();
    }

    private void Mover()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);
        transform.Translate(movimiento * velocidadMovimiento * Time.deltaTime);
    }

    private void Disparar()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            armaActual.Disparar();
        }
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
