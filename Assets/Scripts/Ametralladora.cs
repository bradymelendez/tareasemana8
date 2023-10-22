using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ametralladora : Arma
{
    public float tiempoEntreDisparos = 0.3f;

    private bool disparando;

    protected override void Start()
    {
        base.Start();
        munición = 100; // Establece la munición inicial de la ametralladora.
        cadenciaDisparo = 0f; // La ametralladora dispara automáticamente, por lo que la cadencia es 0.
    }

    protected override void Update()
    {
        base.Update();
        if (Input.GetButton("Fire1"))
        {
            if (!disparando)
            {
                disparando = true;
                InvokeRepeating("Disparar", 0f, tiempoEntreDisparos);
            }
        }
        else
        {
            disparando = false;
            CancelInvoke("Disparar");
        }
    }

    public override void Disparar()
    {
        base.Disparar();
        if (balaPrefab != null && puntoDisparo != null)
        {
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
            munición--;
            Destroy(bala, 3f);
        }
    }

    public override void Recargar(int cantidadMunición)
    {
        munición += cantidadMunición;
    }
}

