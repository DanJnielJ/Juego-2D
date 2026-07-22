using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoFondo : MonoBehaviour
{
    public Vector2 velocidadMovimiento;
    Vector2 offset;
    Material material;
    Rigidbody2D player;
    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        offset = (player.velocity.x * 0.1f) * velocidadMovimiento * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
