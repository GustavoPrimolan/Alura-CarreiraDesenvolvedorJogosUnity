using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour {

    public float Velocidade = 20;

    private Rigidbody rigidbodyBala;

    private void Start()
    {
        rigidbodyBala = GetComponent<Rigidbody>();   
    }

    private void FixedUpdate()
    {

        //tranform.forward É O PARA FRENTE DA BALA
        rigidbodyBala.MovePosition(GetComponent<Rigidbody>().position + transform.forward * Velocidade * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider objetoDeColisao)
    {
        Debug.Log(objetoDeColisao.tag);
        //SE A TAG DO OBJETO DE COLISÃO FOR INIMIGO O OBJETO É DESTRUÍDO
        if (objetoDeColisao.tag == "Inimigo") { 
            //DESTROI O OBJETO QUE COLIDIU
            Destroy(objetoDeColisao.gameObject);

        }

        //SE COLIDIU COM QUALQUER COISA A BALA TEM QUE SER DESTRUÍDA
        //GAME OBJECT COM G MINÚSCULO É O GAME OBJECT QUE TEM O SCRIPT - NO CASO A BALA
        Destroy(gameObject);
    }
}


