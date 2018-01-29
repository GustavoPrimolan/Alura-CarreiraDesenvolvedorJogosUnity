using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaCamera : MonoBehaviour {

    //QUALQUER OBJETO DO JOGO É CHAMADO DE GAME OBJECT
    public GameObject Jogador;
    private Vector3 distanciaCompensar;

    //MÉTODO START RODA APENAS UMA VEZ QUE É NO COMEÇO DO JOGO
	void Start () {
        //DISTANCIA VAI SER A DIFERENTE DA POSIÇÃO DA CÂMERA E DO JOGADOR
        //CALCULA APENAS UMA VEZ
        distanciaCompensar = transform.position - Jogador.transform.position;
	}
	
	
	void Update () {
        //APENAS SOMO A POSIÇÃO DO JOGADOR COM A DISTÂNCIA PARA COMPENSAR
        transform.position = Jogador.transform.position + distanciaCompensar;
	}
}
