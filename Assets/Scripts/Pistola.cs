using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : Arma
{
    protected override void Start()
    {
        base.Start();
        munici�n = 10; // Establece la munici�n inicial de la pistola.
        cadenciaDisparo = 1.0f; // Establece la cadencia de disparo de la pistola.
    }

    public override void Disparar()
    {
        base.Disparar();
        if (balaPrefab != null && puntoDisparo != null)
        {
            Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
            munici�n--;
                
        }
    }
    public override void Recargar(int cantidadMunici�n)
    {
        munici�n += cantidadMunici�n;
    }
}
