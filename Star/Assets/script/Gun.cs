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

    private Vector3 mousePos;

    void Start()
    {
        sound = GameObject.Find("Player").GetComponent<Sound>();
    }

    void Update()
    {
        transform.position = GunSpot.transform.position;
        transform.rotation = GunSpot.transform.rotation;
        if (Input.GetKeyDown("f"))
        {
            Shoot();

            float amount = 5f;
            sound.addSound(amount);
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
