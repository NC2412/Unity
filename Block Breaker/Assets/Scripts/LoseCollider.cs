using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private string text;
    private Ball ball;
    private Paddle paddle;
    private LevelManager levelManager;
    private Vector3 paddleToBallVector;
    public int lives;

    void Start ()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        ball = GameObject.FindObjectOfType<Ball>();
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    void Update ()
    {
        text = "Lives: " + lives;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        lives--;
        if (lives <= 0)
        {
            levelManager.LoadLevel("Lose");
        }
        ball.transform.position = paddle.transform.position + paddleToBallVector;
    }
}
