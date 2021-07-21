using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float velocidade;
    public float ForcaDoPulo;

   

    public bool EstaPulando;

    public bool duploPulo;
  
    private Rigidbody2D rig;
    private Animator animacao;

    void movimento(){

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
        transform.position += movement * Time.deltaTime * velocidade; 
        
        //anda pra direita
        if(Input.GetAxis("Horizontal") > 0f){
            animacao.SetBool("andar",true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        //anda pra esquerda
        if(Input.GetAxis("Horizontal") < 0f){
            animacao.SetBool("andar",true);
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }
        //fica parado
        if(Input.GetAxis("Horizontal") == 0f){
            animacao.SetBool("andar",false);
        }        
    }

    void Start()
    {
        rig         = GetComponent<Rigidbody2D>();
        animacao    = GetComponent<Animator>();
    }


    void Update()
    {
        movimento();
        pular();
    }

    void pular(){
        if(Input.GetButtonDown("Jump")){
            
            if(!EstaPulando){
                rig.AddForce(new Vector2(0f,ForcaDoPulo),ForceMode2D.Impulse);
                duploPulo = true;
                //animacao.SetBool("pular",true);
            }else{
                if(EstaPulando){
                    rig.AddForce(new Vector2(0f,ForcaDoPulo),ForceMode2D.Impulse);
                    duploPulo = false;
                }                
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8 ){
            EstaPulando = false;
            animacao.SetBool("pular",false);
        }

        if(collision.gameObject.tag == "Espinho" ){
            controleJogo.instance.MostrarGameOver();
            Destroy(gameObject);
        } 
        if(collision.gameObject.tag == "SerraGiratoria" ){
            
            controleJogo.instance.MostrarGameOver();
            Destroy(gameObject);
        }         
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 8 ){
            EstaPulando = true;
        }
    }

}
