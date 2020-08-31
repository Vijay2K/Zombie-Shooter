using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    GameObject[] zombies;
    [SerializeField]
    Transform[] SpawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ZombieSpawn", 2f, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth.Instance._isdead == true)
        {
            CancelInvoke("ZombieSpawn");
        }
    }

    void ZombieSpawn()
    {
        int RandomSpawn = Random.Range(0, zombies.Length);
        int RandomPos = Mathf.RoundToInt(Random.Range(0f, SpawnPos.Length));
        
        GameObject _zombies = Instantiate(zombies[RandomSpawn],SpawnPos[RandomPos].transform.position, Quaternion.identity);

        

    }

   
}
