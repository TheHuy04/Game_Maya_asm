using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAttack : MonoBehaviour
{
    private AudioManager audiomanager;
    public GameObject enemyDeathEffect; 
    private bool isDead = false;
    public Text scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScoreUI();
    }
    private void Awake()
    {
        audiomanager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            audiomanager.PlaySFX(audiomanager.attackClip);
            KillEnemy(collision.gameObject);
            AddScore(1);
        }
    }

    void AddScore(int points)
    {
        score += points; // Cộng điểm
        UpdateScoreUI(); // Cập nhật điểm trên UI
    }

    void UpdateScoreUI()
    {
        // Cập nhật hiển thị điểm trên màn hình
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    void KillEnemy(GameObject enemy)
    {
        Debug.Log("Enemy has been killed!");

     
        if (enemyDeathEffect != null)
        {
            Instantiate(enemyDeathEffect, enemy.transform.position, Quaternion.identity);
        }

     
        Destroy(enemy);
    }

}
