using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{

    public GameObject Bala;
    public GameObject CanoDaArma;

    void Start()
    {


    }

    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //INSTANCIA UM GAME OBJECT EM UMA POSIÇÃO E EM UMA ROTAÇÃO
            Instantiate(Bala, CanoDaArma.transform.position, CanoDaArma.transform.rotation);
        }

    }
}
