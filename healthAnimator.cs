using UnityEngine;
using UnityEngine.UI;

public class HealthBarAdjuster : MonoBehaviour
{
    public PlayerHealthScript playerHealthScript; // Assign this in the Inspector
    public Image healthBarImage; // Assign the green health bar Image in the Inspector

    private RectTransform rectTransform;
    private float minRight = 79f;
    private float maxRight = 311f;

    private void Start()
    {
        rectTransform = healthBarImage.GetComponent<RectTransform>();

        // Ensure the initial right value is correctly set based on full health
        SetInitialRightValue();
    }

    private void Update()
    {
        // Calculate the current health percentage
        float healthPercentage = (float)playerHealthScript.playerHealth / playerHealthScript.maxPlayerHealth;

        // Adjust the right value of the health bar
        AdjustHealthBar(healthPercentage);
    }

    private void SetInitialRightValue()
    {
        // Set the right value to minRight when health is full
        float fullHealthPercentage = 1f;
        AdjustHealthBar(fullHealthPercentage);
    }

    private void AdjustHealthBar(float healthPercentage)
    {
        // Clamp healthPercentage between 0 and 1
        healthPercentage = Mathf.Clamp01(healthPercentage);

        // Calculate the new right value based on health percentage
        float fullWidth = maxRight - minRight;
        float newRight = minRight + (fullWidth * healthPercentage);

        // Ensure the new right value stays within the specified range
        newRight = Mathf.Clamp(newRight, minRight, maxRight);

        // Adjust the RectTransform to set the new right value
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);
        float currentRight = corners[2].x; // Right edge in world space

        // Calculate the offset needed to set the new right value
        float offset = newRight - (rectTransform.position.x + rectTransform.rect.width / 2);
        rectTransform.offsetMax += new Vector2(offset, 0);
    }
}
