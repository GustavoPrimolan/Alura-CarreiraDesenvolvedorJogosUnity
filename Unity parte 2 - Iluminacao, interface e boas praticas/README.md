<h1>Seção 01 - Interface na Unity</h1>

<h2>Preparando o ambiente</h2>

Neste curso vamos continuar de onde paramos no primeiro curso, então se você tiver um projeto e gostaria de continuar, pode continuar do seu projeto!

Caso queira um projeto para iniciar seu aprendizado, você pode baixar a versão final do projeto do primeiro curso clicando aqui. Lembre-se de extrair a pasta antes de abrir o projeto.

Vamos focar em melhorar o nosso código, resolver bugs e desenvolver novas funcionalidades. Para isso teste bastante o seu jogo durante cada etapa, e verifique se está tudo funcionando! Para não tomar seu tempo no vídeo testamos somente o necessário, mas vale lembrar que é importante sempre conferir com mais profundidade para saber se uma coisa não quebrou outra!

<h2>Fazendo a Vida do Personagem</h2>

Vamos criar uma Vida para o nosso personagem, para que ele não morra somente com um ataque no jogo.

Para isso, vamos definir uma variável do tipo inteiro (integer) com o valor da nossa vida no começo do script ControlaJogador.

public int Vida = 100;

Agora que já temos uma variável, temos que usá-la no código, para evitar que vários scripts mudem seu valor e percamos o controle de onde ela está sendo utilizada. Então, vamos criar um método. Assim, temos a implementação da lógica nesse script, mas podemos chamar este método em vários scripts, e se necessitarmos saber onde ele está sendo utilizado é só buscar pelo método.

Para definir um método temos que colocar seu tipo e nome. Lembre-se de colocar os parâmetros utilizados também nos parênteses.

public void TomarDano ()
{
    Vida -= 30;     
}
Agora temos que chamar esse método onde o jogador deve tomar dano, no caso até agora temos somente uma forma de dano que é no código ControlaInimigo, o método AtacaJogador, então vamos utilizar este método.

void AtacaJogador ()
{
    Jogador.GetComponent<ControlaJogador>().TomarDano();
}

<h2>Game Over ao Perder toda a vida</h2>

Já temos o método e a chamada do método para dar dano ao nosso personagem. Vamos melhorar este método utilizando parâmetros. Os parâmetros fazem com que possamos passar informações para o método dinamicamente, podendo trocar o valor informado a cada chamada se quisermos.

Vamos então criar um parâmetro dentro dos parênteses do nosso método:

public void TomarDano (int dano)
{
    Vida -= dano;     
}
Além disso, vamos criar uma variável que gera um valor aleatório de dano para utilizarmos na chamada do método. Assim, se o jogador tiver muita sorte, ele pode perder com 5 ataques, mas o normal seria ele perder com 4.

Para isso vamos utilizar o Random.Range que é um método do Unity que gera números aleatórios para nós, de um mínimo até um máximo.

void AtacaJogador ()
{
    int dano = Random.Range(20, 30);
    Jogador.GetComponent<ControlaJogador>().TomarDano(dano);
}
As linhas de Game Over não fazem mais sentido no método AtacaJogador do nosso inimigo, já que elas tem que ser atreladas a vida do nosso personagem. Então, vamos trazer estas linhas para o código do personagem. Não precisamos buscar pelo personagem, já que essas variáveis são deste script. Lembre-se de testar se a vida é menor ou igual a zero para dar o Game Over:

public void TomarDano (int dano)
{
    Vida -= dano;
    if(Vida <= 0)
    {
        Time.timeScale = 0;
        TextoGameOver.SetActive(true);
    }        
}

