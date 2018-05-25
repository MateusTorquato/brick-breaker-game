using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleScript : MonoBehaviour {

    public float Speed;
    public GameObject ballPrefab;
    GameObject ballPaddle = null;
    public Vector3 ballPosition;
    int lives = 3;
    int score = 0;
    int level = 1;
    GameObject Lives = null;
    public GUISkin scoreBoard;

    public GameObject ReturnLives(){
        return Lives;
    }

    // Use this for initialization
    void Start() {
        ballPosition = new Vector3(0, y: 0.9f, z: 0);
        Lives = GameObject.Find("Lives");
        //Velocidade do Paddle para 10
        Speed = 10;
        // Spawna a bola
        Lives.GetComponent<Text>().text = "Lives: " + lives;
        //SpawnBall();
    }

    // Incrementa ponto
    public void addPoint(int p){
        score += p;
    }

    // Monta o Score na tela
    private void OnGUI(){
        // Skin com fonte e tamanho padrão
        GUI.skin = scoreBoard;
        GUI.Label(position: new Rect(x: 10, y: 10, width: 300, height: 100), text: "Score: " + score);
    }

    public void SpawnBall(){
        // Se setou o prefab da bola, cria ela.
        if (ballPrefab) {
            // Instancia a bola já em sua posição correta - No centro do paddle
            ballPaddle = Instantiate(original: ballPrefab, position: transform.position + ballPosition, rotation: Quaternion.identity );
        }
    }

    public void LoseLives(){
        if (Lives){
            // Decrementa a vida
            lives--;
            Lives.GetComponent<Text>().text = "Lives: " + lives;
            // Se o número de vidas ainda for maior do que zero, spawna a bola novamente
            if (lives > 0){
                SpawnBall();
            }else{
                Destroy(gameObject);
                Destroy(Lives);
                BrickScript b = GameObject.FindGameObjectWithTag("Brick").GetComponent<BrickScript>();
                b.zeraBricks();
                // se não, carrega a tela de game over
                Application.LoadLevel("GameOver");

            }
        }
    }
    
    // Update is called once per frame
    void Update(){
        // Esquerda/Direita 
        transform.Translate(x: Speed * Time.deltaTime * Input.GetAxis(axisName: "Horizontal"), y: 0, z: 0);
        // Script para respeitar as paredes
        Vector3 posClamp = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);
        posClamp.x = Mathf.Clamp(transform.position.x, -6.9f, 6.9f);
        transform.position = posClamp;

        // Enquanto a bolinha estiver no Paddle, irá fazer isso
        if (ballPaddle){
            // Seta a a posição da bolinha um pouco acima do Paddle
            ballPaddle.GetComponent<Rigidbody>().position = transform.position + ballPosition;
            // Lançar a bola se apertar espaço
            if (Input.GetButtonDown("LaunchBall")){
                AudioSource brickSound = GameObject.Find("LaunchBallSound").GetComponent<AudioSource>();
                if (brickSound)
                    brickSound.Play();
                // Para habilitar novamente os componentes de física
                ballPaddle.GetComponent<Rigidbody>().isKinematic = false;
                // Lança a bola na direção que está andando
                ballPaddle.GetComponent<Rigidbody>().AddForce(x: 300f * Input.GetAxis(axisName: "Horizontal"), y: 300f, z: 0);
                // Agora a bola não estara mais no paddle
                ballPaddle = null;
            }
        }
        if (Input.GetKey("b")){
            Debug.Log("test");
            ForceNextLevel();
        }

    }

    public void OnLevelWasLoaded(int level){
        SpawnBall();
    }

    void OnCollisionEnter(Collision collision){
        foreach(ContactPoint contact in collision.contacts){
            if (contact.thisCollider == GetComponent<Collider>()){
                //Ponto de contato do Paddle
                float Value = contact.point.x - transform.position.x;
                contact.otherCollider.GetComponent<Rigidbody>().AddForce(300f * Value, 0, 0);
            }
        }
    }

    public int getLevel(){
        return level;
    }

    public void incLevel(){
        level++;
    }

    private void ForceNextLevel()
    {
        PaddleScript p = GameObject.FindGameObjectWithTag(tag: "Paddle").GetComponent<PaddleScript>();
        //Carrega cena 2
        // Se o número de tijolos for zero ou menos, carrega cena 2
        if (p.getLevel() == 1)
        {
            AudioSource nl = GameObject.Find(name: "NextLevelSound").GetComponent<AudioSource>();
            if (nl)
                nl.Play();
            p.incLevel();
            Application.LoadLevel("Cena02");
        }
        else
        {
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