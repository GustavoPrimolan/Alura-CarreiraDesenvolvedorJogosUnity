<h1>Se��o 01 - Interface na Unity</h1>

<h2>Preparando o ambiente</h2>

Neste curso vamos continuar de onde paramos no primeiro curso, ent�o se voc� tiver um projeto e gostaria de continuar, pode continuar do seu projeto!

Caso queira um projeto para iniciar seu aprendizado, voc� pode baixar a vers�o final do projeto do primeiro curso clicando aqui. Lembre-se de extrair a pasta antes de abrir o projeto.

Vamos focar em melhorar o nosso c�digo, resolver bugs e desenvolver novas funcionalidades. Para isso teste bastante o seu jogo durante cada etapa, e verifique se est� tudo funcionando! Para n�o tomar seu tempo no v�deo testamos somente o necess�rio, mas vale lembrar que � importante sempre conferir com mais profundidade para saber se uma coisa n�o quebrou outra!

<h2>Fazendo a Vida do Personagem</h2>

Vamos criar uma Vida para o nosso personagem, para que ele n�o morra somente com um ataque no jogo.

Para isso, vamos definir uma vari�vel do tipo inteiro (integer) com o valor da nossa vida no come�o do script ControlaJogador.

public int Vida = 100;

Agora que j� temos uma vari�vel, temos que us�-la no c�digo, para evitar que v�rios scripts mudem seu valor e percamos o controle de onde ela est� sendo utilizada. Ent�o, vamos criar um m�todo. Assim, temos a implementa��o da l�gica nesse script, mas podemos chamar este m�todo em v�rios scripts, e se necessitarmos saber onde ele est� sendo utilizado � s� buscar pelo m�todo.

Para definir um m�todo temos que colocar seu tipo e nome. Lembre-se de colocar os par�metros utilizados tamb�m nos par�nteses.

public void TomarDano ()
{
    Vida -= 30;     
}
Agora temos que chamar esse m�todo onde o jogador deve tomar dano, no caso at� agora temos somente uma forma de dano que � no c�digo ControlaInimigo, o m�todo AtacaJogador, ent�o vamos utilizar este m�todo.

void AtacaJogador ()
{
    Jogador.GetComponent<ControlaJogador>().TomarDano();
}

<h2>Game Over ao Perder toda a vida</h2>

J� temos o m�todo e a chamada do m�todo para dar dano ao nosso personagem. Vamos melhorar este m�todo utilizando par�metros. Os par�metros fazem com que possamos passar informa��es para o m�todo dinamicamente, podendo trocar o valor informado a cada chamada se quisermos.

Vamos ent�o criar um par�metro dentro dos par�nteses do nosso m�todo:

public void TomarDano (int dano)
{
    Vida -= dano;     
}
Al�m disso, vamos criar uma vari�vel que gera um valor aleat�rio de dano para utilizarmos na chamada do m�todo. Assim, se o jogador tiver muita sorte, ele pode perder com 5 ataques, mas o normal seria ele perder com 4.

Para isso vamos utilizar o Random.Range que � um m�todo do Unity que gera n�meros aleat�rios para n�s, de um m�nimo at� um m�ximo.

void AtacaJogador ()
{
    int dano = Random.Range(20, 30);
    Jogador.GetComponent<ControlaJogador>().TomarDano(dano);
}
As linhas de Game Over n�o fazem mais sentido no m�todo AtacaJogador do nosso inimigo, j� que elas tem que ser atreladas a vida do nosso personagem. Ent�o, vamos trazer estas linhas para o c�digo do personagem. N�o precisamos buscar pelo personagem, j� que essas vari�veis s�o deste script. Lembre-se de testar se a vida � menor ou igual a zero para dar o Game Over:

public void TomarDano (int dano)
{
    Vida -= dano;
    if(Vida <= 0)
    {
        Time.timeScale = 0;
        TextoGameOver.SetActive(true);
    }        
}

