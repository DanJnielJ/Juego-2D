using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorEventos : MonoBehaviour
{
    //declarar un envento que invocará a obtener moneda
    public static event Action EventoObtenerMoneda;
    public static event Action EventoMuerte;
    public static event Action EventoGanar;
    public static void IniciarEventoObtenerMoneda()
    {
        EventoObtenerMoneda?.Invoke();
    }
    public static void IniciarEventoMuerte()
    {
        EventoMuerte?.Invoke();
    }
    public static void IniciarEventoGanar()
    {
        EventoGanar?.Invoke();
    }
}
