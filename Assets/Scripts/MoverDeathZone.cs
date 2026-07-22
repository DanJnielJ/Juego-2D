using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDeathZone : MonoBehaviour
{
    public Transform Jugador;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Jugador.position.x, transform.position.y);
    }
}
