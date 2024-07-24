using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockedName : MonoBehaviour
{
    private Quaternion lockedRotation;

    void Start()
    {
        // Lock the name tag to face the same direction always
        lockedRotation = Quaternion.identity; // or Quaternion.Euler(0, 0, 0);
    }

    void LateUpdate()
    {
        // Ensure the name tag maintains its locked rotation
        transform.rotation = lockedRotation;
    }
}
