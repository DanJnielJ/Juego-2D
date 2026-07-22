using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorIntentos : MonoBehaviour
{
    public TMP_Text Contador;
    public static int Intentos { get; private set; } = 0;
    // Start is called before the first frame update
    void Start()
    {
        Intentos = 0;
    }

    private void Awake()
    {
        GestorEventos.EventoMuerte += AumentarIntento;
    }

    private void AumentarIntento()
    {
        Intentos++;
        Contador.text = Intentos.ToString();
    }

    private void ReiniciarIntentos()
    {
        Intentos = 0;
        Contador.text = Intentos.ToString();
    }

    private void OnDestroy()
    {
        GestorEventos.EventoMuerte -= AumentarIntento;
        GestorEventos.EventoMuerte -= ReiniciarIntentos;
    }

}
