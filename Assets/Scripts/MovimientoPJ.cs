using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPJ : MonoBehaviour
{
    //creamos variable del componente Rigidbody, se crea el objeto rb
    private Rigidbody2D rb;
    [Header("Movimiento")]
    //move es la variable del movimiento horizontal
    float moveH = 0;
    public float velocidadMove;
    [Range(0, 0.3f)]
    [SerializeField]
    float suavizadorMove;
    //variable que permite guardar la velocidad de movimiento del jugador
    private Vector2 velocidad = Vector2.zero;
    //permite determinar la dirección del jugador
    private bool miraDelante = true;
    [Header("Salto")]
    //fuerza del salto
    public float fuerzaSalto;
    //permite determinar si el jugador está en el suelo 
    public Transform controllerSuelo;
    //indentifica el suelo
    public LayerMask suelo;
    //elemento agregado para determinar el tamaño del pj en relación al suelo
    public Vector2 caja;
    //cambia cuando toca el suelo
    public bool esSuelo;
    //indica cuando el pj salto
    public bool saltar = false;
    [Header("Animación")]
    private Animator animator;
    // Start is called before the first frame update
    float xInit, yInit;

    private AudioSource audioSource;

    void Start()
    {
        //obtenemos el componente
        rb = GetComponent<Rigidbody2D>();
        //inicamos el animator
        animator = GetComponent<Animator>();
        xInit = -8;
        yInit = -2;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //obtener el valor de entrada del movimiento horizontal (A, D)
        moveH = Input.GetAxisRaw("Horizontal") * velocidadMove;
        //indicamos cuando debe moverse la animación
        //abs es valor absoluto que deja siempre en positivo para controlar mejor la animación 
        animator.SetFloat("Horizontal", Math.Abs(moveH));

        //verifica si presiono espacio y está en el suelo 
        if (Input.GetButtonDown("Jump") && esSuelo)
        {
            saltar = true;
            audioSource.Play();
            
           
        }
           
    }
    //FixedUpdate es llamado una vez por frame y se actualiza al mover el objeto
    private void FixedUpdate()
    {
        //si la variable saltar es verdadera entonces aplicamos fuera hacia
        //arriaba en el eje y del objeto
        esSuelo = Physics2D.OverlapBox(controllerSuelo.position, caja, 0, suelo);
        //verificamos si el personaje está en el sueldo o no
        animator.SetBool("esSuelo", esSuelo);
        //invoca la función que permite el moviemiento del personaje
        Mover(moveH * Time.fixedDeltaTime, saltar);
        saltar = false;
       
        
       
    }
    //método que perite mover el objeto luego de presionar A o D o las flechas
    private void Mover(float mover, bool salto)
    {
       
        //movement es un vector de movimiento con las velocidades del eje x e y 
        Vector2 movement = new Vector2(mover, rb.velocity.y);
        // asignamos la velocidad del Rigidbody
        rb.velocity = Vector2.SmoothDamp(rb.velocity, movement, ref velocidad, suavizadorMove);
        //si el jugador se mueve a la derecha y esta mirando a la izquierda se gira


        if (mover > 0 && !miraDelante)
        {
            Girar();
        }
        else if (mover < 0 && miraDelante)
        {
            Girar();
        }
        if (esSuelo && salto)
        {
            esSuelo = false;
            //aplicar fuerza para el salto
            //ForceMode2d.Impulse es para que la fuerza sea instantanea 
            rb.AddForce(new Vector2(0, fuerzaSalto), ForceMode2D.Impulse);
        }
    }

    private void Girar()
    {
        //cambia el valor de trua a false o de false a true
        miraDelante = !miraDelante;
        //obtemenos la posición actual
        Vector2 scale = transform.localScale;
        //multiplicamos *-1 para cambiar la orientación 
        scale.x *= -1; //scale.x = scale.x*-1
        //se asigna la posición nueva
        transform.localScale = scale;
    }
    public void Resetear()
    {
        transform.position = new Vector2(xInit, yInit);
    }
    private void OnDrawGizmos()
    {
        //color del gizmo
        Gizmos.color = Color.red;
        //dibujamos en el editor de unity para visualizar el área de detección del suelo
        Gizmos.DrawWireCube(controllerSuelo.position, caja);
    }
}
