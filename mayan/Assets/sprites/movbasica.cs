using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movbasica : MonoBehaviour
{
    [Header("Conf Player")]
    public float velocidade;
    public float movimentoHorizontal;
    private Rigidbody2D rbPlayer;
    public float forcaPulo;
    public Transform posicaoSensor;
    public bool sensor;


    //criar uma vari�vel para verificar a dire��o
    public bool verificarDirecaoPersonagem;

    //Configurando tiro
    public GameObject municao;
    public Transform posicaoTiro;
    public float velocidadeTiro;


    private Animator anim;
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        verificarChao();
        movimentoHorizontal = Input.GetAxisRaw("Horizontal");

        rbPlayer.velocity = new Vector2(movimentoHorizontal*velocidade, rbPlayer.velocity.y);

        
        
           
        

        if (Input.GetButtonDown("Jump") && sensor==true)
        {
            rbPlayer.AddForce(new Vector2(0, forcaPulo));
        }
        if(movimentoHorizontal > 0 && verificarDirecaoPersonagem == true)
        {
            Flip();
        }if (movimentoHorizontal < 0 && verificarDirecaoPersonagem == false)
        {
            Flip();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Atirar();
        }

        anim.SetInteger("run", (int)movimentoHorizontal);
        anim.SetBool("sensor",sensor);
    }


    public void verificarChao()
    {
        sensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.1f); 
    }

    public void Flip()
    {
        verificarDirecaoPersonagem = !verificarDirecaoPersonagem;

        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y,transform.localScale.z);
        velocidadeTiro *= -1;
        municao.GetComponent<SpriteRenderer>().flipX = verificarDirecaoPersonagem;
    }


    public void Atirar()
    {
        GameObject temporario = Instantiate(municao);
        temporario.transform.position = posicaoTiro.position;
        temporario.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeTiro, 0);
        anim.SetTrigger("Shoot");
    }
}
