using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;

    public float _currentHealth;
    public float _maxHealth;
    public bool _isdead;
    public Slider _healthSliders;
    public GameObject gameOverPanel;

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
        _healthSliders.value = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       if(_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }

    public void _playerStat(float Damage)
    {
        if(_currentHealth > 0 && _healthSliders.value > 0)
        {
            if (Damage >= _currentHealth)
            {
                Dead();
            }
            else
            {
                _currentHealth -= Damage; //_currentHealth = _currentHealth - Damage;
                _healthSliders.value -= Damage; //_healthSliders = _healthSliders - Damage;
            }
        }
       
    }

    void Dead()
    {
        _currentHealth = 0;        
        _isdead = true;
        _healthSliders.value = 0;
        gameOverPanel.SetActive(true);
        Debug.Log("Player is Dead");
    }
}
