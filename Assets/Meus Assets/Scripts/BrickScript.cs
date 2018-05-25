using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

    // Cada tijolo tem hitpoits. Dessa forma, pode ter tijolo que quebra somente depois de x colisões
    static int numBricks = 0;
    public int hitPoint = 1;
    // Use this for initialization
    void Start() {
        // Saber quantos bricks tem em jogo para saber quando trocar de cena
        numBricks++;
    }

    public void zeraBricks(){
        numBricks = 0;
    }
    private void OnCollisionEnter(Collision collision) {
        // Blocos com hitpoints diferentes demoram mais para serem destruídos
        // Quando algo entra em contato com o tijolo (no caso, só a bolinha irá conseguir entrar em contato), diminui um hitPoint
        hitPoint--;
        // Se o número de hitpoits for zero ou menos, irá "Matar" o tijolo, pois sua vida zerou
        if (hitPoint < 1) {
            KillBrick();
        }
    }

    private void KillBrick(){
        // Quando o tijolo morre, decrementa o número de tijolos e destrói o objeto
        AudioSource brickSound = GameObject.Find("BrickBreakerSound").GetComponent<AudioSource>();
        if (brickSound)
            brickSound.Play();
        numBricks--;
        Destroy(gameObject);
        // Procura o script do paddle 
        PaddleScript p = GameObject.FindGameObjectWithTag(tag: "Paddle").GetComponent<PaddleScript>();
        // Adiciona um ponto para cada tijolo quebrado
        p.addPoint(1);
        if (numBricks < 1) {
            //Carrega cena 2
            // Se o número de tijolos for zero ou menos, carrega cena 2
            if (p.getLevel() == 1) {
                AudioSource nl = GameObject.Find(name: "NextLevelSound").GetComponent<AudioSource>();
                if (nl)
                    nl.Play();
                p.incLevel();
                Application.LoadLevel("Cena02");
            }
            else {
                GameObject paddle = GameObject.FindGameObjectWithTag("Paddle");
                Destroy(paddle);
                GameObject l = p.ReturnLives();
                Destroy(l);
                BrickScript brick = GameObject.FindGameObjectWithTag("Brick").GetComponent<BrickScript>();
                brick.zeraBricks();
                Application.LoadLevel("EndGame");

            }
        }
    }
}
