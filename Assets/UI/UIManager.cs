using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_Text vidaText;
    public TMP_Text municiónText;
    public TMP_Text enemigosEliminadosText;
    public GameObject pantallaInicio;
    public GameObject pantallaDerrota;
    public GameObject pantallaVictoria;

    private void Start()
    {
        ActualizarVida(100);
        ActualizarMunición(30);
        ActualizarEnemigosEliminados(0);
        MostrarPantallaInicio();
    }

    public void ActualizarVida(int vida)
    {
        vidaText.text = "Vida: " + vida;
    }

    public void ActualizarMunición(int munición)
    {
        municiónText.text = "Munición: " + munición;
    }

    public void ActualizarEnemigosEliminados(int cantidad)
    {
        enemigosEliminadosText.text = "Enemigos Eliminados: " + cantidad;
    }

    public void MostrarPantallaInicio()
    {
        pantallaInicio.SetActive(true);
        pantallaDerrota.SetActive(false);
        pantallaVictoria.SetActive(false);
    }

    public void MostrarPantallaDerrota()
    {
        pantallaInicio.SetActive(false);
        pantallaDerrota.SetActive(true);
        pantallaVictoria.SetActive(false);
    }

    public void MostrarPantallaVictoria()
    {
        pantallaInicio.SetActive(false);
        pantallaDerrota.SetActive(false);
        pantallaVictoria.SetActive(true);
    }
}
