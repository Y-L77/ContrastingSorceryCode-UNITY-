using UnityEngine;
using System.Collections;

public class StopParticlesAfterDelay : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public GameObject deathParticles;

    void Start()
    {
        particleSystem = GetComponentInParent<ParticleSystem>(); // Get the ParticleSystem from the parent

        // Start a coroutine to stop emission after 0.5 seconds
        StartCoroutine(StopEmissionAfterDelay(0.5f));
        Destroy(deathParticles, 1.2f);
    }

    private IEnumerator StopEmissionAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay

        if (particleSystem != null)
        {
            var emission = particleSystem.emission;
            emission.rateOverTime = 0; // Stop emitting new particles
        }
    }
}
