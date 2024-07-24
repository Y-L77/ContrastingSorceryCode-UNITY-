using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class reaperEnemyAI : MonoBehaviour
{
    public GameObject reaperSpell;
    public AudioSource reaperSpellSFX;



    private float spellSpawnInterval = 2.7f;
    private float spellLifeDuration = 9f;
    private float nextSpellSpawnTime;

    private Vector3 originalPosition;

    void Start()
    {
        nextSpellSpawnTime = Time.time + spellSpawnInterval;
        originalPosition = transform.position;
    }

    void Update()
    {
        if (Time.time >= nextSpellSpawnTime)
        {
            SpawnReaperSpell();
            nextSpellSpawnTime = Time.time + spellSpawnInterval;

            if (Mathf.Abs(transform.position.x - originalPosition.x) >= 20f)
            {
                // Teleport the enemy back to the original position
                transform.position = originalPosition;
            }
        }
    }

    void SpawnReaperSpell()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 4, 0);
        GameObject spawnedSpell = Instantiate(reaperSpell, spawnPosition, Quaternion.identity);
        reaperSpellSFX.Play();
        Destroy(spawnedSpell, spellLifeDuration);
    }
}