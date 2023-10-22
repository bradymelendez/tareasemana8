using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : Arma
{
    public int balasPorRafaga = 3;
    public float dispersión = 5f;

    protected override void Start()
    {
        base.Start();
        munición = 20; 
        cadenciaDisparo = 1.5f; 
    }

    public override void Disparar()
    {
        base.Disparar();

        if (balaPrefab != null && puntoDisparo != null)
        {
            for (int i = 0; i < balasPorRafaga; i++)
            {
                Quaternion dispersiónAleatoria = Quaternion.Euler(Random.Range(-dispersión, dispersión), Random.Range(-dispersión, dispersión), 0);

                GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation * dispersiónAleatoria);
                munición--;
                Destroy(bala, 3f);
            }

        }
    }

    public override void Recargar(int cantidadMunición)
    {
        munición += cantidadMunición;
    }
}
