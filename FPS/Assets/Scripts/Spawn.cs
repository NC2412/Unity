using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn : MonoBehaviour
{
    Score s;
    PlayerController p;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    Transform pSpawn;
    Transform eSpawn;

    private Text tlives;

    public int enemiesRemaining = 0;
    public int gameEnemies = 3;
	public static int waves;
    int lives = 2;

    float difficultyTimer = 20;

    // Use this for initialization
    void Start()
    {
        tlives = GameObject.Find("Lives").GetComponent<Text>();
        p = FindObjectOfType<PlayerController>();
        s = FindObjectOfType<Score>();

        pSpawn = GameObject.Find("Player Spawn " + Random.Range(1, 4)).transform;
        var player = (GameObject)Instantiate(playerPrefab, pSpawn.transform.position, pSpawn.transform.rotation);
        player.name = "Player";

        for (int i = 0; i < 3; i++)
        {
            eSpawn = GameObject.Find("Enemy Spawn " + Random.Range(1, 4)).transform;
            var enemy = (GameObject)Instantiate(enemyPrefab, eSpawn.transform.position, eSpawn.transform.rotation);
            enemy.gameObject.tag = "Enemy";
            enemiesRemaining++;
        }
    }

    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("Enemy").Length < gameEnemies)
        {
            EnemyRespawn();
            Score.score++;
        }

        if (GameObject.FindGameObjectsWithTag("Player").Length < 1 && lives >= 0)
        {
            PlayerRespawn();
            lives--;
        }
        if (lives < 0)
        {
            Application.LoadLevel("Lose");
        }

        tlives.text = "Lives Left: " + lives;

        difficultyTimer -= Time.deltaTime;
        if (difficultyTimer <= 0)
        {
            difficultyTimer = 20;
            gameEnemies++;
			waves++;
        }
    }

    public void PlayerRespawn()
    {
        Transform pSpawn = GameObject.Find("Player Spawn " + Random.Range(1, 4)).transform;
        var player = (GameObject)Instantiate(playerPrefab, pSpawn.transform.position, pSpawn.transform.rotation);
        player.name = "Player";

    }

    public void EnemyRespawn()
    {
        Transform eSpawn = GameObject.Find("Enemy Spawn " + Random.Range(1, 4)).transform;
        var enemy = (GameObject)Instantiate(enemyPrefab, eSpawn.transform.position, eSpawn.transform.rotation);
        enemy.gameObject.tag = "Enemy";
        enemiesRemaining++;
    }
}
