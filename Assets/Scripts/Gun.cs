using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField]
    float DamageEnemy = 10f;
    public float Range;
    bool firing;
    public ParticleSystem MuzzuleFlash;
    public ParticleSystem ImpactEffect;
    public AudioSource ShootingSound;
    Animator Heavy;

    //Ammo and Reloading
    public int _currentAmmo = 12;
    public int _maxAmmo = 12;
    public int _carryingAmmo = 60;
    public int _maxCarryingAmmo = 60;
    bool _isReloading = false;
    Animator _reloadAnime;

    public Text currentAmmo;
    public Text carryingAmmo;
    
    bool _isAnimating = false;
    

    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Heavy = GetComponent<Animator>();
        _reloadAnime = GetComponent<Animator>();
       
        UpdateAmmo();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (firing == true)
        {
            Shoot();
            
        }
        
    }
    public void PointersDown()
    {
        firing = true;
        if (!_isAnimating)
        {
         
            Heavy.SetBool("IsAnimating", true);
            _isAnimating = true;
        }
    }
    public void pointersUp()
    {
        firing = false;
        if(_isAnimating)
        {
           
            Heavy.SetBool("IsAnimating", false);
            _isAnimating = false;
        }
        
    }


    public void Shoot()
    {
        if (_currentAmmo > 0)
        {
            MuzzuleFlash.Play();
            ShootingSound.Play(); //Pistol Sound

            _currentAmmo--;

            UpdateAmmo();

            _shootingRay();

            
        }
        else if(_currentAmmo <= 0)
        {
            _reload();
        }

    }
    void _shootingRay()
    {
        //Shooting the enemy using RayCast.
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Range))
        {
            // Debug.Log(hit.transform.name);

            TakeDamage _enemy = hit.transform.GetComponent<TakeDamage>();
            // if (target != null)
            // {
            _enemy._TakeDamage(DamageEnemy);
            //  }

            ParticleSystem Impact = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Impact, 2f);
            

        }
    }

    public void _reload()
    {
        if (_carryingAmmo <= 0) return;
        _reloadAnime.SetTrigger("Reload");
        StartCoroutine(_reloadCountDown(2f));
       
        
    }

    public void UpdateAmmo()
    {
        currentAmmo.text = _currentAmmo.ToString();
        carryingAmmo.text = _carryingAmmo.ToString();
    }

    //Reloading Time
   IEnumerator _reloadCountDown(float Timer)
    {
        while (Timer > 0f)
        {
            _isReloading = true;
            Timer -= Time.deltaTime;
            yield return null;
        }
        if(Timer <= 0f)
        {
            _isReloading = false;
            int _bulletsNeedToFill = _maxAmmo - _currentAmmo;
            int _bulletToDeduct = (_carryingAmmo >= _bulletsNeedToFill) ? _bulletsNeedToFill : _carryingAmmo;
            _carryingAmmo -= _bulletToDeduct;
            _currentAmmo += _bulletToDeduct;
            UpdateAmmo();
        }

    }

}
