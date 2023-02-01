using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject ShootPoint;
    public float ShootPower = 10f;
    public int Ammo = 50;
    public bool shooting = false;
    bool canShoot = true;
    public int firerate = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        shooting = Input.GetKey(KeyCode.Mouse0);
        if (shooting == true && Ammo > 0){
            if (canShoot == true){
                canShoot = false;
                StartCoroutine(Shoot());
            }
           
            
        }
        if (Input.GetKeyDown(KeyCode.R)){
            Ammo = 51;
        }
    }

    void ReadyShoot(){

    }


    IEnumerator Shoot(){
        //Ray
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0)); //setting up the ray, ray through the middle of the screen
        RaycastHit hit;
        Ammo = Ammo - 1;
        Vector3 targetPoint;
        //this line of code will SHOOT THE RAY, and return the value of whatever it hit into the variable hit
        if (Physics.Raycast(ray, out hit))
        {
            //hit contains the information we need to get the gameobject or point on where we hit
            targetPoint = hit.point;
        }
        else {
            targetPoint = ray.GetPoint(75);
        }
        //Projectile (bullet)
        Vector3 direction = targetPoint - ShootPoint.transform.position; //gets direction
        Quaternion MyRotation = Quaternion.identity;
        MyRotation.eulerAngles = new Vector3(0,0.7071f,0);
        GameObject currentBullet = Instantiate(Bullet, ShootPoint.transform.position, MyRotation); //creates bullet
        currentBullet.transform.Rotate(90,0,0,Space.Self);
        currentBullet.transform.forward = direction.normalized; //fixes rotation

        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * ShootPower, ForceMode.Impulse);


        yield return new WaitForSeconds(1/firerate);
        canShoot = true;



    }


}
