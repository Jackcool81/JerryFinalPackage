using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireProjectile : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletActiveTime = 3;
    public float bulletPower = 10;

    public GameObject firepoint;

    public float maxAmmo = 20;
    public TextMeshProUGUI ammoText;
    public float reloadTime = 3f;

    private float ammoCount;

    void Start()
    {
        ammoCount = maxAmmo;
        ammoText.text = $"Ammo: {ammoCount}";
    }

    void Update()
    {
        //if our mouse button is being fired and our ammoCount is above 0
        if(Input.GetButtonDown("Fire1") && ammoCount > 0)
        {
            // ADD CODE HERE
            GameObject bullet = Instantiate(bulletPrefab);
            Destroy(bullet, bulletActiveTime);
            // bullet.GetComponent<BulletScript>().FireBullet();
            ammoCount = ammoCount - 1;

            // END OF CODE
            ammoText.text = $"Ammo: {ammoCount}";
        }


    }

    private void FireBullet(BulletScript bullet)
    {
        bullet.transform.position = firepoint.transform.position;
        bullet.FireBullet(this.transform.forward, bulletPower);
    }

    public IEnumerator Reloading()
    {
        yield return new WaitForSeconds(0);
    }
}
