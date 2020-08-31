using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth;

    public static CharacterStat Instance;



    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       if(_currentHealth <= 0)
        {
            Die();
        }
    }


    public void PlayerHealth (float damage)
    {
        _currentHealth -= damage; // _currentHealth = _currentHealth - damage;
    }

    public void Die()
    {

    }

   
}
