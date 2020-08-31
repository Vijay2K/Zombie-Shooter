using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUps : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    Gun _gunScript;
    [SerializeField]
    float pickUpDistance = 2f;
    public Camera mainCam;
   
    public LayerMask Layer;
    
    
    void Start()
    {
        mainCam = Camera.main;
        _gunScript = GetComponentInChildren<Gun>();
        
       
    }

    void Update()
    {
        ray = mainCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, pickUpDistance, Layer))
        {
            if(_gunScript._carryingAmmo < _gunScript._maxCarryingAmmo)
            {
                if (hit.transform.tag == "Ammo")
                {
                    Destroy(hit.transform.gameObject);
                    _gunScript._carryingAmmo = _gunScript._maxCarryingAmmo;
                    _gunScript.UpdateAmmo();
                   
                }
            }
            
        }

    }

    public void PickAmmo()
    {
       
    }
}
