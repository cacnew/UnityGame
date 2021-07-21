using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 using UnityEngine.SceneManagement;


public class controleJogo : MonoBehaviour
{

    public int PontuacaoTotal;
    public static controleJogo instance;
    
    public Text PontuacaoTexto;

    public GameObject gameOver;

     
    
    void Start()
    {
        instance = this;
        
    }

    public void AtualizarPontuacaoTexto(){
        PontuacaoTexto.text = PontuacaoTotal.ToString();
    }


    public void MostrarGameOver(){
        gameOver.SetActive(true);

    }

    public void RestartGame(string levelName){
        SceneManager.LoadScene(levelName);
    }    
}
