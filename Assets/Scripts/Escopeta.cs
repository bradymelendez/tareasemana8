using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : Arma
{
    public int balasPorRafaga = 3;
    public float dispersi�n = 5f;

    protected override void Start()
    {
        base.Start();
        munici�n = 20; 
        cadenciaDisparo = 1.5f; 
    }

    public override void Disparar()
    {
        base.Disparar();

        if (balaPrefab != null && puntoDisparo != null)
        {
            for (int i = 0; i < balasPorRafaga; i++)
            {
                Quaternion dispersi�nAleatoria = Quaternion.Euler(Random.Range(-dispersi�n, dispersi�n), Random.Range(-dispersi�n, dispersi�n), 0);

                GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation * dispersi�nAleatoria);
                munici�n--;
                Destroy(bala, 3f);
            }

        }
    }

    public override void Recargar(int cantidadMunici�n)
    {
        munici�n += cantidadMunici�n;
    }
}
