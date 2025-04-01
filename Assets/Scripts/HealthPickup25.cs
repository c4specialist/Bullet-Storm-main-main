using UnityEngine;
using TMPro;

public class HealthPickup : MonoBehaviour
{
    public float healthAmount = 25f;
    private bool isPlayerNearby = false;
    private PlayerHealth playerHealth;
    public GameObject interactionText;

    void Start()
    {
        if (interactionText != null)
            interactionText.SetActive(false);
    }

    void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (playerHealth != null)
            {
                playerHealth.Heal(healthAmount);
                Debug.Log($"Player healed for {healthAmount} HP");

                if (interactionText != null)
                    interactionText.SetActive(false);

                isPlayerNearby = false;
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("PlayerHealth component not found on Player!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            playerHealth = other.GetComponent<PlayerHealth>();

            if (interactionText != null)
            {
                interactionText.SetActive(true);
                interactionText.GetComponent<TextMeshProUGUI>().text = "Press E to pick up";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            playerHealth = null;

            if (interactionText != null)
                interactionText.SetActive(false);
        }
    }
}
