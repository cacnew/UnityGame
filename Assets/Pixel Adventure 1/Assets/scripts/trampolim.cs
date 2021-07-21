using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolim : MonoBehaviour
{

    public float forcaPulo;


    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Player" ){

             collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f,forcaPulo),ForceMode2D.Impulse);
        }
      
    }
}
