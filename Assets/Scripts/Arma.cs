using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour
{
    public int munición;
    public float cadenciaDisparo;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float velocidadDeBala = 100.0f;

    private float tiempoÚltimoDisparo;

    protected virtual void Start()
    {
        tiempoÚltimoDisparo = 0f;
    }

    protected virtual void Update()
    {
        if (Time.time - tiempoÚltimoDisparo >= 1 / cadenciaDisparo)
        {
            if (Input.GetButton("Fire1") && munición > 0)
            {
                Disparar();
                tiempoÚltimoDisparo = Time.time;
            }
        }
    }

    public virtual void Disparar()
    {
        if (balaPrefab != null && puntoDisparo != null)
        {
            GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
            Rigidbody rb = bala.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = puntoDisparo.forward * velocidadDeBala;
            }
            munición--;
            Destroy(bala, 3f);
        }
    }

    public virtual void Recargar(int cantidadMunición)
    {
        munición += cantidadMunición;
    }
}
