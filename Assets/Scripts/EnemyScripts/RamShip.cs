using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public Directions direction;
    public SpriteRenderer shipRenderer;
    private float speed = 0.1f;
    private float heal = 50; 
    private float halfWidth;
    private float halfHeight;
    void Start()
    {
        halfWidth = shipRenderer.sprite.bounds.size.x / 2;
        halfHeight = shipRenderer.sprite.bounds.size.y / 2;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        switch(direction) {
            case Directions.left:
                MovingLeft();
                break;
            case Directions.right:
                MovingRight();
                break;
            case Directions.up:
                MovingUp();
                break;
            case Directions.down:
                MovingDown();
                break;
        }



    }

    private void MovingRight() {
        Vector3 newPosition = transform.position;
        newPosition.x += speed;
        Vector3 checkPosition = newPosition;
        checkPosition.x += halfWidth;

        if (Helpers.IsPositionOnScreen(checkPosition) == true) {
            transform.position = newPosition;
        } else {
            if (transform.position.y > 0) {
                direction = Directions.down;
            } else {
                direction = Directions.up;
            }
        }

    }

    private void MovingLeft() {
        Vector3 newPosition = transform.position;
        newPosition.x -= speed;
        Vector3 checkPosition = newPosition;
        checkPosition.x -= halfWidth;

        if (Helpers.IsPositionOnScreen(checkPosition) == true) {
            transform.position = newPosition;
        } else {
            if (transform.position.y > 0) {
                direction = Directions.down;
            } else {
                direction = Directions.up;
            }
        }

    }

    private void MovingUp() {
        Vector3 newPosition = transform.position;
        newPosition.y += speed;
        Vector3 checkPosition = newPosition;
        checkPosition.y += halfHeight;

        if (Helpers.IsPositionOnScreen(checkPosition) == true) {
            transform.position = newPosition;
        } else {
            if (transform.position.x > 0) {
                direction = Directions.left;
            } else {
                direction = Directions.right;
            }
        }

    }
    private void MovingDown() {
        Vector3 newPosition = transform.position;
        newPosition.y -= speed;
        Vector3 checkPosition = newPosition;
        checkPosition.y -= halfHeight;

        if (Helpers.IsPositionOnScreen(checkPosition) == true) {
            transform.position = newPosition;
        } else {
            if (transform.position.x > 0) {
                direction = Directions.left;
            } else {
                direction = Directions.right;
            }
        }

    }

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
                Destroy(gameObject);
            }
        }
    }

}
