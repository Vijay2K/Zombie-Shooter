using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class FollowPlayer : MonoBehaviour
{
    GameObject Player;
    NavMeshAgent Zombies;
    public float StoppingDistance = 2f;
    public float DamageAmount = 5f;
    [SerializeField]
    float _attackTime = 2f;
    bool CanAttack;
    
    Animator ZombieAttack;
    
    // Start is called before the first frame update
    void Start()
    {
        Zombies = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");

        ZombieAttack = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if(distance < StoppingDistance)
        {
           
            Attackplayer();
                    
        }
        else
        {
            ChasePlayer();
        }
       
    }

    void ChasePlayer()
    {
        Zombies.isStopped = false;
        Zombies.SetDestination(Player.transform.position);
    }
    void StopEnemy ()
    {
        Zombies.isStopped = true;
    }

    void Attackplayer()
    {
        StopEnemy();
        ZombieAttack.SetTrigger("Attack");
        StartCoroutine(AttackTime());
    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(0.5f);      
        CharacterStat.Instance.PlayerHealth(DamageAmount);
        yield return new WaitForSeconds(_attackTime);
        CanAttack = true;
    }

}
