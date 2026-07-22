using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    //SendMessager sirve para acceder a los métodos
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<MovimientoPJ>().SendMessage("Resetear");
    }
}
