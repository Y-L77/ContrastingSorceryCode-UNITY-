using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballDestroy : MonoBehaviour
{
    public GameObject fireball;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("ground"))
        {
            Destroy(fireball);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            Destroy(fireball);
        }
    }
}
