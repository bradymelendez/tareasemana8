using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour
{
    public int munici�n;
    public float cadenciaDisparo;
    public GameObject balaPrefab;
    public Transform puntoDisparo;
    public float velocidadDeBala = 100.0f;

    private float tiempo�ltimoDisparo;

    protected virtual void Start()
    {
        tiempo�ltimoDisparo = 0f;
    }

    protected virtual void Update()
    {
        if (Time.time - tiempo�ltimoDisparo >= 1 / cadenciaDisparo)
        {
            if (Input.GetButton("Fire1") && munici�n > 0)
            {
                Disparar();
                tiempo�ltimoDisparo = Time.time;
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
            munici�n--;
            Destroy(bala, 3f);
        }
    }

    public virtual void Recargar(int cantidadMunici�n)
    {
        munici�n += cantidadMunici�n;
    }
}
