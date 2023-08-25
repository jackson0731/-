using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Sound sound;
    public GameObject bulletPrefab; // �l�u���w�s��
    public Transform firePoint; // �l�u�o�g���_�I
    public float bulletForce = 20f;
    public GameObject GunSpot;
    public Animator ani;
    public float noCombo;

    private bool CanShoot;

    void Start()
    {
        sound = GameObject.Find("Player").GetComponent<Sound>();
        ani = GameObject.Find("Player").GetComponent<Animator>();
    }

    void Update()
    {
        noCombo -= Time.deltaTime;

        Fire();
    }

    //Gun
    void Fire()
    {
        if(ani.GetCurrentAnimatorStateInfo(0).IsName("Falling To Landing") || ani.GetCurrentAnimatorStateInfo(0).IsName("Jumping Up") || ani.GetCurrentAnimatorStateInfo(0).IsName("2ndJump"))
        {
            CanShoot = false;
        }
        else
        {
            CanShoot = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && CanShoot == true)
        {
            Invoke("Shoot", 0.4f);

            noCombo = 0.5f;
            ani.SetBool("IsAtk", true);
            float amount = 5f;
            sound.addSound(amount);
        }
        else if (noCombo<0)
        {
            ani.SetBool("IsAtk", false);
        }
    }
    void Shoot()
    {
        // ���ͤl�u
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // ���o�l�u�����餸��
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // �]�w�l�u���o�g�O�q
        bulletRigidbody.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }
}
