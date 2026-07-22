using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContadorMonedas : MonoBehaviour
{
    public TMP_Text Monedas;
    public static int MonedasObtenidas { get; set; } = 0;
    private void Start()
    {
        MonedasObtenidas = 0;
    }
    private void Awake()
    {
        //pasamos al gestor de eventos el cambio en texto cada vez que consigo una moneda
        GestorEventos.EventoObtenerMoneda += Aumentar;
        GestorEventos.EventoObtenerMoneda -= ReinciarMoneda;
    }
    private void Aumentar()
    {
        MonedasObtenidas += 1;
        //monedas reprensta el texto que se muestra en pantalla
        Monedas.text = MonedasObtenidas.ToString();
    }
    private void ReinciarMoneda()
    {
        MonedasObtenidas = 0;
        Monedas.text = MonedasObtenidas.ToString();
    }
    private void OnDestroy()
    {
        GestorEventos.EventoObtenerMoneda -= Aumentar;
        GestorEventos.EventoObtenerMoneda -= ReinciarMoneda;
    }
}
