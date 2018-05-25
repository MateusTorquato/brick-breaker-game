using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    // Script quando a bolinha "Morre" - Vem do DeathScript
    public void Die(){
        // Destrói a bolinha
        Destroy(gameObject);
        // Procura pelo objeto Paddle (Jogador)
        GameObject paddle = GameObject.FindGameObjectWithTag("Paddle");
        if (paddle){
            // Procura pelo Script do Paddle 
            PaddleScript ps = paddle.GetComponent<PaddleScript>();
            // Executa funçao LoseLives
            ps.LoseLives();
        }
    }
}
