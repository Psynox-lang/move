using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundEnemy : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletspeed=10f;
    public Transform player;
    public Transform gun;
     public float spreadAngle = 45f;
    void Start(){
    }

    // Update is called once per frame
    void Update()
    { 
         Vector3 directionToPlayer = (player.position - bulletSpawnPoint.transform.position).normalized;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            Quaternion newRotation = Quaternion.Euler(0f, 0f, angle);
            gun.transform.rotation = newRotation;

        if(Input.GetKeyDown(KeyCode.Y))
        {
            Vector2 centerdirection =(player.position - transform.position).normalized;
            var bullet= Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity=centerdirection*bulletspeed;
            for(int i=0; i<5; i++){
                float a = Mathf.Atan2(centerdirection.y, centerdirection.x) * Mathf.Rad2Deg + (i - 2) * spreadAngle;
                Vector2 direction = Quaternion.Euler(0, 0, a) * Vector2.right;
                bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
            }
        }
    }
}
