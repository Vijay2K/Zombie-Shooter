using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnAmmo : MonoBehaviour
{
    public static SpawnAmmo Instance;

    [SerializeField]
    GameObject Ammo;
    [SerializeField]
    Transform spawnPos;
   
    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("AmmoSpawn", 2f, 120f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AmmoSpawn()
    {
        Instantiate(Ammo, spawnPos.transform.position, Quaternion.identity);
               
    }
}
