using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonDestroy : MonoBehaviour
{
    public float speed = 5f;  // Movement speed of the object
    public float detectionRange = 200f;  // Maximum detection range
    public GameObject dragon;

    void Update()
    {
        // Find all objects with the "enemy" tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        if (enemies.Length > 0)
        {
            GameObject closestEnemy = null;
            float closestDistance = detectionRange;  // Initialize closest distance to detection range

            // Loop through all enemies to find the closest one within the detection range
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = enemy;
                }
            }

            // If a closest enemy within range is found, move towards it and rotate to face it
            if (closestEnemy != null)
            {
                Vector2 direction = (closestEnemy.transform.position - transform.position).normalized;
                transform.position = Vector2.MoveTowards(transform.position, closestEnemy.transform.position, speed * Time.deltaTime);

                // Calculate the angle to rotate the object to face the enemy
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            Destroy(dragon, 0.3f);
        }
    }
}
