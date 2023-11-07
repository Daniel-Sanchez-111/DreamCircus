using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Movimiento")]
    public float moveSpeed;

    public bool isSitting;

    [Header("Salto")]
    private bool canDoubleJump;
    public float jumpForce;


    [Header("Componentes")]
    public Rigidbody2D theRB;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform groundCheckpoint;
    public LayerMask whatIsGround;

    [Header("Animator")]
    private Animator anim;
    private SpriteRenderer theSR;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
        //CODIGO PARA EL SALTO DEL PERSONAJE, VERIFICA SI ESTÁ TOCANDO EL SUELO PARA PERMITIR EL DOBLE SALTO, GUARDADO POR SI LLEGARA A USARSE
        isGrounded = Physics2D.OverlapCircle(groundCheckpoint.position, .2f, whatIsGround);

        /*if(isGrounded) {
            canDoubleJump = true;
        }*/

        /*if(Input.GetButtonDown("Jump")){
            if(isGrounded) {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }else
            {
                if(canDoubleJump){
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
            
        }*/
        if (theRB.velocity.x < 0)
        {
            theSR.flipX = true;
        } else if(theRB.velocity.x > 0) {
            theSR.flipX = false;
        }
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isSitting", isSitting);
    }
}
