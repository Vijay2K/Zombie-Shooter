using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public float health = 50f;
    EnemyAI _enemyAI;
    [HideInInspector]
    public int AddingScore = 5;

    // Start is called before the first frame update
    void Start()
    {
        _enemyAI = GetComponent<EnemyAI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void _TakeDamage(float amount)
    {
        health -= amount;
        if (health == 0f)
        {
            Die();
        }

    }
    void Die()
    {
        _enemyAI.EnemyAnime();
        
        Destroy(gameObject, 1f);
        ScoreManager.Score += AddingScore;
        
    }
}
