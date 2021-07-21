using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maca : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;
    public GameObject coletado;

     public int Pontuacao;

    void Start()
    {
        sr      = GetComponent<SpriteRenderer>();
        circle  = GetComponent<CircleCollider2D>();
    }

 
 
    void OnTriggerEnter2D(Collider2D collider){
        
        if(collider.gameObject.tag =="Player"){
            sr.enabled      = false;
            circle.enabled  = false;
            coletado.SetActive(true);

            controleJogo.instance.PontuacaoTotal+=Pontuacao;
            controleJogo.instance.AtualizarPontuacaoTexto();
            

            Destroy(gameObject,0.25f);
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        
    }    
}
