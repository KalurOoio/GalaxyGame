using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstGroup : BaseGroup
{
    public EnemyShip ship1;
    public EnemyShip ship2;
    public EnemyShip ship3;

    private float speed = 0.1f;
    private int direction = -1;
    private List<EnemyShip> ships = new List<EnemyShip>();

    private System.Random generator = new System.Random();
    void Start()
    {
        ships.Add(ship1);                     
        ships.Add(ship2); 
        ships.Add(ship3); 
        ship1.DeathEvent += OnShipDeath;
        ship2.DeathEvent += OnShipDeath;
        ship3.DeathEvent += OnShipDeath;
        InvokeRepeating("GroupShoot", 0.0f, 2.0f);
    }

    void Update()
    {
        ships.RemoveAll(item => item == null);
        if(ships.Count == 0)
        {
            isAlive = false;
            CancelInvoke("GroupShoot");
            return;
        }

        if (direction == -1) {
            Vector3 leftPosition = ships[0].transform.position;
            leftPosition.x -= speed;

            bool onScreen = Helpers.IsPositionOnScreen(leftPosition);
            if (onScreen) {
                transform.position = new Vector3(
                    transform.position.x - speed,
                    transform.position.y,
                    0
                );
            } else {
                direction *= -1;                
            }
        } else {
            Vector3 rightPosition = ships[ships.Count - 1].transform.position;
            rightPosition.x += speed;

            bool onScreen = Helpers.IsPositionOnScreen(rightPosition);
            if (onScreen) {
                transform.position = new Vector3(
                    transform.position.x + speed,
                    transform.position.y,
                    0
                );
            } else {
                direction *= -1;                
            }

        }
    }

    void OnShipDeath(EnemyShip deadShip) {
        //ships.Remove(deadShip);
    }

    void GroupShoot() {
        int randomIndex = generator.Next(0, ships.Count);
        ships[randomIndex].Shoot();
    }
}
