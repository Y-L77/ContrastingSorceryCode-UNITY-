using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class necromancyDestroy : MonoBehaviour
{
    //I can't use spelldestroy for this because I want it to not be destroyed when hit ground.
    //I'm also going to put all the necromancy logic in this script because I don't want to mess around with global calls in scripts on an instiantiated object

    public GameObject necromancy;
    public GameObject necromancyGroundBox;
    public PlayerMovement playerMovement;
    public bool necromancyGrounded = false;
    private Rigidbody2D necromancyRB;
    public float jumpPower = 6f;
    public float necromancerMoveSpeed = 6f;
    public bool facingRight = true;

    void Start()
    {
        necromancyRB = GetComponent<Rigidbody2D>();

        playerMovement = FindObjectOfType<PlayerMovement>();

        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found in the scene.");
        }
    }
    public void Update()
    {

        if (playerMovement.facingRight)
        {
            necromancyRB.velocity = new Vector2(necromancerMoveSpeed, necromancyRB.velocity.y);
            necromancy.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            necromancyRB.velocity = new Vector2(-necromancerMoveSpeed, necromancyRB.velocity.y);
            necromancy.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            Destroy(necromancy);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            necromancyRB.velocity = new Vector2(necromancyRB.velocity.x, jumpPower);
        }
    }
}
