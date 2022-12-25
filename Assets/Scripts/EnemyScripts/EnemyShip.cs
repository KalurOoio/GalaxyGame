using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public delegate void OnDeath(EnemyShip deadShip);
    public event OnDeath DeathEvent;

    public float heal = 50;
    public GameObject bullet;
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject otherObject = collider.gameObject ;
        PlayerBullet bulletObject = otherObject.GetComponent<PlayerBullet>();
        if(bulletObject != null)
        {
            heal -= bulletObject.damage;
            Destroy(otherObject);
            if(heal <= 0)
            {
                DeathEvent.Invoke(this);
                Destroy(gameObject);
            }
        }
    }

    public void Shoot() {
        GameObject newBullet = Instantiate(bullet);
        newBullet.transform.position = transform.position;
    }
}
