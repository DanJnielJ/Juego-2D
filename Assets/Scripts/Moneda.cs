using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //verificamos si hay colisión en el tag coin
        if (collision.CompareTag("Player"))
        {
            //dasactivar la moneda
            gameObject.SetActive(false);
            //lama al evento, ejecuta todos los métodos necesarios para el conteo
            GestorEventos.IniciarEventoObtenerMoneda();
        }
    }
}
