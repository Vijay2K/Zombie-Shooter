using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapons : MonoBehaviour
{
    [SerializeField]
    GameObject Pistol, Heavy;
    void Start ()
    {
        Pistol.SetActive(true);
        Heavy.SetActive(false);
    }
   

   public void _pistol ()
    {
        Pistol.SetActive(true);
        Heavy.SetActive(false);
    }

    public void _heavy ()
    {
        Heavy.SetActive(true);
        Pistol.SetActive(false);
        
    }

}
