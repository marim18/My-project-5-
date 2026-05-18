using UnityEngine;

public class swordscript : MonoBehaviour
{
    public int Swordpieceid;

    private bool collected = false;
    private SwordProgressManager swordProgressManager;

    void Start()
    {
        swordProgressManager = FindFirstObjectByType<SwordProgressManager>();

        if (swordProgressManager == null)
        {
            Debug.LogError("No SwordProgressManager found in the scene!");
        }

        if (Swordpieceid == 0)
        {
            Debug.LogWarning("Sword piece ID is not set! Give each piece a unique ID: 1, 2, 3, 4.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            Debug.Log("Player picked up sword piece with ID: " + Swordpieceid);

            swordProgressManager.CollectSwordPiece(Swordpieceid);

            // Hide/remove the collected sword piece from the scene
            gameObject.SetActive(false);
        }
    }
}