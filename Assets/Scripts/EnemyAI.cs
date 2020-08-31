using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent agent;
    Transform target;
    NavMeshAgent Zombies;
    Animator Anime;
    bool _isDead = false;

    [SerializeField]
    float StoppingDistance = 2f;
    [SerializeField]
    float ChasingDistance = 1.5f;

    [SerializeField]
    float _damage = 30f;
    float _attackTiming = 2f;
    bool canAttack = true;
    [SerializeField]
    float _rotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Zombies = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);
         if (distance < ChasingDistance && canAttack && !PlayerHealth.Instance._isdead)
        {
            _attackPlayer();
        }

        else if (distance > ChasingDistance && !_isDead)
        {
           _chasePlayer();
        }
       
        
       
     }
    void _chasePlayer()
    {
        Zombies.updateRotation = true;
        Zombies.updatePosition = true;
        Zombies.SetDestination(target.position);
        Anime.SetBool("IsWalking", true);
        Anime.SetBool("IsAttacking", false);
    }

    void _attackPlayer()
    {
        Zombies.updateRotation = false;
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _rotationSpeed);      
        Zombies.updatePosition = false;
        Anime.SetBool("IsWalking", false);
        Anime.SetBool("IsAttacking", true);
        StartCoroutine(_enemyAttack());
    }

    
    
    
    public void EnemyAnime()
    {
        _isDead = true;
        Anime.SetTrigger("IsDead");
        
    }

    IEnumerator _enemyAttack()
    {
        canAttack = false;      
        yield return new WaitForSeconds(0.5f);
        PlayerHealth.Instance._playerStat(_damage);
        yield return new WaitForSeconds(_attackTiming);
        canAttack = true;
     

    }
}
