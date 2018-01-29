using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour {

    public GameObject Jogador;

    //QUANDO VARÍAVEIS SÃO PÚBLICAS É UPPERCAMELCASE OU PASCALCASE
    public float Velocidade = 5;

    
    private Rigidbody rigidbodyInimigo;
    private Animator animatorInimigo;

	void Start () {

        rigidbodyInimigo = GetComponent<Rigidbody>();
        animatorInimigo = GetComponent<Animator>();

        //PEGA O JOGADOR PELA TAG JOGADOR
        Jogador = GameObject.FindGameObjectWithTag("Jogador");
        
        //GERA UM DOS 27 TIPOS DE ZUMBIS QUE ESTÁ NO PREFAB
        //RANDOMIZAR O NÚMERO DE 1 ATÉ 27, POIS 28 NÃO É GERADO
        int geraTipoZumbi = Random.Range(1, 28);

        //GET CHILD PEGA UM FILHO DO OBJETO
        //GEROU O NÚMERO DE 1 A 27 ENTROU NO FILHO DO OBJETO E ATIVOU UM DOS TIPOS DO ZUMBI QUE ESTÁ DENTRO DO ZUMBI
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);

	}
	
	
	void Update () {
		
	}

    private void FixedUpdate()
    {
        
        //PASSA DUAS POSIÇÕES E DA UMA DISTÂNCIA ENTRE AS DUAS POSÍÇÕES
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);


        //ONDE EU QUERO ESTAR MENOS ONDE ESTOU SERÁ A DIREÇÃO QUE OS ZUMBIS DEVERÃO IR
        Vector3 direcao = Jogador.transform.position - transform.position;


        //QUARTERNION É UMA ESTRUTURA UTILIZADA NA UNITY PARA ROTAÇÃO 
        //QUANDO EU QUERO ROTACIONAR O ROTATION É UM QUATERNION
        //LOOK ROTATION PEGA UMA POSIÇÃO E CALCULA QUANTO PRECISO ROTAR
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        GetComponent<Rigidbody>().MoveRotation(novaRotacao);

        //SE A DISTÂNCIA FOR MAIOR QUE 2 O ZUMBI IRÁ ANDAR
        //DOIS PQ O RAIO DO CAPSULE COLLIDER DO ZUMBI E DO JOGADOR É IGUAL A 2 (A SOMA)
        if (distancia > 2.6)
        {

            //ZUMBI IRÁ MOVER PARA A POSIÇÃO + A DIREÇÃO VEZES A VELOCIDADE POR SEGUNDO
            //direcao.normalized FAZ A NORMALIZAÇÃO DA DIREÇÃO PARA QUE A DIREÇÃO NÃO SEJA GRANDE
            rigidbodyInimigo.MovePosition(rigidbodyInimigo.position + direcao.normalized * Velocidade * Time.deltaTime);

            animatorInimigo.SetBool("Atacando", false);
        }
        //QUANDO ELE ESTÁ PERTO ELE ATACA O PERSONAGEM
        //ELE PRECISA ROTACIONAOAR PARA O PERSONAGEM SEMPRE
        else
        {
            animatorInimigo.SetBool("Atacando", true);
        }

    }


    //O NOME DO MÉTODO TEM QUE SER IGUALZINHO AO EVENTO CRIADO NA ANIMAÇÃO
    //NO CASO ESSE EVENTO SERVE PARA ATACAR O ZUMBI DAR DANO NO JOGADOR
    void AtacaJogador()
    {
        //PAUSA O JOGO PARA VER ALGUMA COISA ACONTECENDO
        Time.timeScale = 0;

        //PEGA O JOGADOR E DEPOIS PEGA O SCRIPT QUE ESTÁ VINCULADO COM O JOGADOR
        //NO CASO, O SCRIPT É O CONTROLA JOGADOR
        //ENTÃO IREI PEGAR A VARIÁVEL DE TEXTO DO JOGADOR E SETAR PARA ELA APARECER QUANDO O JOGO PAUSAR
        //SetActive SETA VALOR SE ESTÁ ATIVO OU NÃO ESTÁ ATIVO
        Jogador.GetComponent<ControlaJogador>().TextoGameOver.SetActive(true);


        //SETA VARIAVEL DE VIVO PARA FALSE
        Jogador.GetComponent<ControlaJogador>().vivo = false;

    }



}
