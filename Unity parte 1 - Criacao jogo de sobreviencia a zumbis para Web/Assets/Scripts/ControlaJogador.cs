using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//BIBLIOTECA NECESSÁRIA PARA LIDAR COM AS CENAS PARA QUE SEJA POSSÍVEL REINICIÁ-LAS
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour {

    public float Velocidade = 5;
    private Vector3 direcao;

    //LAYER MASK É UMA CAMADA PARA MASCARAR TUDO MENOS O CHÃO
    public LayerMask MascaraChao;

    //TEXTO DO GAME OVER QUE APARECE SÓ QUANDO O ZUMBI BATE NO JOGADOR
    //ESSE VALOR É SETADO TRUE NO SCRIPT DO INIMIGO
    public GameObject TextoGameOver;

    //VARIÁVEL QUE MOSTRA SE O JOGADOR ESTÁ VIVO OU MORTO
    //COMEÇA COMO VIVO
    public bool vivo = true;

    private Rigidbody rigidbodyJogador;
    private Animator animatorJogador;


    //QUANDO O JOGO RECOMEÇAR O JOGO VOLTA PARA UM
    private void Start()
    {
        Time.timeScale = 1;
        rigidbodyJogador = GetComponent<Rigidbody>();
        animatorJogador = GetComponent<Animator>();
    }


    void Update () {

        //PEGA AS ENTRADAS NA HORIZONTAL (A; D; SETA ESQUERDA; SETA DIREITA)
        float eixoX = Input.GetAxis("Horizontal");
        //PEGA AS ENTRADAS NA VERTICAL (W; S; SETA CIMA; SETA BAIXO)
        float eixoZ = Input.GetAxis("Vertical");

        //ARMAZENA OS VALORES DAS DIREÇÕES X,Y,Z 
        direcao = new Vector3(eixoX, 0, eixoZ);

        //MOVIMENTA NA DIRECAO DO TECLADO
        //MOVIMENTA DIREÇÃO E MULTIPLICA PELO TEMPO QUE UNITY DEMORA EM RODAR CADA QUADRO
        //VELOCIDADE POR SEGUNDO
        //MOVENDO UM QUADRADO POR SEGUNDO VEZES 10
        //transform.Translate(direcao * velocidade * Time.deltaTime);

        //SE AS TRÊS DIMENSÕES NÃO FOREM IGUAL A 0
        if (direcao != Vector3.zero){
            //PUXA ANIMATOR DENTRO DO CÓDIGO
            //TUDO ASSOCIADO AO PERSONAGEM É CHAMADO DE COMPONENTE
            //TEXTO DO PARÂMETRO DA ANIMAÇÃO TEM QUE SER IDENTICO AO DA UNITY
            animatorJogador.SetBool("Movendo", true);
        }
        else
        {
            //SE NÃO ELE NÃO ESTÁ MOVENDO E O PARÂMETRO MOVENDO VIRA FALSE
            animatorJogador.SetBool("Movendo", false);
        }



        //SE O JOGADOR ESTIVER MORTO
        if(vivo == false)
        {
            //SE ELE CLICAR NO JOGO COMO SE FOSSE ATIRAR, O JOGO É REINICIADO
            if (Input.GetButtonDown("Fire1"))
            {
                //REINICIA A CENA game
                SceneManager.LoadScene("game");
            }
        }
	}


    //MÉTODO ESPECÍFICO PARA FÍSICA
    //FixedUpdate VAI RODAR EM UM TEMPO FIXO QUE É 0,02 SEGUNDOS O PADRÃO DE RODAR
    //ESSA É A DIFERENÇA DO UPDATE COM O FIXED UPDATE
    //IDEPENDENTE SE EU TENHO FRAME DE JOGO OU NÃO
    //UNITY COMPUTA A FÍSICA MESMO QUE O JOGO NÃO TENHA FRAMES
    private void FixedUpdate()
    {

        //PEGA A POSIÇÃO QUE O PERSONAGEM ESTÁ E SOMA COM A DIREÇÃO QUE O PERSONAGEM TEM QUE IR
        rigidbodyJogador.MovePosition(rigidbodyJogador.position + (direcao * Velocidade * Time.deltaTime));


        //ROTAÇÃO DO PERSONAGEM - UTILIZANDO O Rigidbody E É POR ISSO QUE ESTÁ COLOCANDO NO MÉTODO FixedUpdate()
        //VARIÁVEL DO TIPO RAIO
        //Camera com C maiúsculo É A CÂMERA GERAL
        //.main É A CÂMERA PRINCIPAL
        //CÂMERA PRINCIPAL VAI PEGAR O RAIO DA POSIÇÃO DO RAIO
        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);


        //VAI DESENHAR O RAIO
        //PRIMEIRO PARÂMETRO = ORIGEM DO RAIO
        //SEGUNDO PARÂMETRO = DISTÂNCIA MULTIPLICADO POR 100 PARA CONSEGUIR ENXERGAR O RAIO
        //TERCEIRO PARÂMETRO = COR
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        //PEGA O RAIO QUE ESTOU GERANDO E PEGA A POSIÇÃO ONDE QUE ELE BATE COM ALGUMA COISA
        //ONDE O RAIO VAI BATER NO CHÃO
        RaycastHit impacto;

        //VOU GERAR UM RAIO COM A FÍSICA DA UNITY
        //O RAIO, O IMPACTO E ATÉ ONDE O RAIO VAI
        //out É UMA VARIÁVEL QUE FALA QUE O VALOR É NENHUM
        if (Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            //PEGA O PONTO DE IMPACTO DO RAIO A PARTIR DA MINHA POSIÇÃO
            //TENHO O PONTO DE IMPACTO BASEADO NA POSIÇÃO DO MEU JOGADOR
            //CANCELA O RAIO EM Y PARA NÃO OLHAR PARA BAIXO OU PARA CIMA
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            //CANCELA O Y DELA PARA QUE O JOGADOR E O Y DELA ESTEJAM NA MESMA ALTURA
            posicaoMiraJogador.y = transform.position.y;

            //VALER A ROTAÇÃO CRIA UM QUATERNION
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            rigidbodyJogador.MoveRotation(novaRotacao);
        }

    }

}
