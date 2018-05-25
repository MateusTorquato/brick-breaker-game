using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

    // Quando entra em colisão com o objeto Death (invisivel abaixo do Paddle), executa isso
    private void OnTriggerEnter(Collider other){
        // Procura pelo script da bola e executa o método Die
        BallScript b = other.GetComponent<BallScript>();
        if (b){
            b.Die();
        }
    }
}
