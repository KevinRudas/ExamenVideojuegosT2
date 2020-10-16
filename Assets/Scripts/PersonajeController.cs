using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    private const int ANIMATION_PARADO = 0;
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_SALTAR = 2;
    private const int ANIMATION_LANZAR = 3;
    private const int ANIMATION_DESLIZAR = 4;
    private const int ANIMATION_MORIR = 5;
    private const int ANIMATION_CAER = 6;
    private const int ANIMATION_SUBIR = 7;
    private bool morir = false;


    public int direccionKunai = 0;
    public int vidas=3; 
    public Transform kunaiD;
    public Transform kunaiI;
    public GameObject kunaDer;
    public GameObject kunaiIzq;
  
    
    
    public PuntajeController puntajeObject;
    
    
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sr;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();
        
        
        Debug.Log(puntajeObject.GetPoints());
    }

    // Update is called once per frame
    void Update()
    {
        if (!morir)
        {
            Caida();
            chequeoDevidas();
            Debug.Log(rb.velocity.y);
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetInteger("Estado", ANIMATION_PARADO);

            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(10, rb.velocity.y);
                animator.SetInteger("Estado", ANIMATION_CORRER);
                _transform.localScale=new Vector3(0.3734069f,0.4092748f);
                direccionKunai = 0;


            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-10, rb.velocity.y);
                animator.SetInteger("Estado", ANIMATION_CORRER);
                _transform.localScale=new Vector3(-0.3734069f,0.4092748f);
                direccionKunai = 1;

            }

            if (Input.GetKey(KeyCode.C))
            {
                animator.SetInteger("Estado", ANIMATION_DESLIZAR);

            }

            if (Input.GetKey(KeyCode.Z))
            {
                if ( rb.velocity.y<-1)
                {
                    animator.SetInteger("Estado", ANIMATION_CAER);
                    rb.velocity = new Vector2(rb.velocity.x, -5);
                }

            }

            if (Input.GetKey(KeyCode.A))
            {
                animator.SetInteger("Estado", ANIMATION_SUBIR);

            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetInteger("Estado", ANIMATION_SALTAR);
                rb.velocity = new Vector2(rb.velocity.x, 20);

            }
            


            if (Input.GetKeyUp(KeyCode.X))
            {
                animator.SetInteger("Estado", ANIMATION_LANZAR);
                if (direccionKunai == 0)
                {
                    Instantiate(kunaDer, kunaiD.position, Quaternion.Euler(0f,0f,45f));
                }
                if (direccionKunai == 1)
                {
                    Instantiate(kunaiIzq, kunaiI.position, Quaternion.Euler(0f,0f,-45f));
                }
            }
        }
        else
        {
            Morir();
        }
    }

    void Morir()
    {
       
            animator.SetInteger("Estado", ANIMATION_MORIR);
        

    }

   
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "zombie")
        {
           vidas=vidas-1;

        }

    }

    private void chequeoDevidas()
    {
        if (vidas==0)
        {
            morir = true;
        }
    }

    public void Caida()
    {
        if ( rb.velocity.y<-30)
        {
            morir = true;
        }
        
    }

    }

