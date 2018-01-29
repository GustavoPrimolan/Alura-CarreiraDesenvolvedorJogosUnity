using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour {

    public GameObject Zumbi;

    private float contadorTempo = 0;

    //DE UM EM UM SEGUNDO GERA ZUMBI
    public float TempoGerarZumbi = 1;

	void Start () {
		
	}
	
	void Update () {

        //VAI FICAR CONTANDO O TEMPO DO JOGO
        //Time.deltaTime é cada segundo
        contadorTempo += Time.deltaTime;

        Debug.Log(Time.deltaTime);

        if(contadorTempo >= TempoGerarZumbi)
        {
            //INSTANCIA UM ZUMBI NA POSIÇÃO DO GAME OBJECT INVISÍVEL E NA ROTAÇÃO DO GAME OBJECT INVISÍVEL TAMBÉM
            Instantiate(Zumbi, transform.position, transform.rotation);

            //ZERA O RELÓGIO
            contadorTempo = 0;
        }

	}
}
