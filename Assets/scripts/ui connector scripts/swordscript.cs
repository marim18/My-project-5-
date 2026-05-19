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

            // Create sparkle effect at the position of the collected sword piece
            CreatePickupEffect();

            // Update progress bar, inventory, and sword upgrade logic
            swordProgressManager.CollectSwordPiece(Swordpieceid);

            // Hide/remove the collected sword piece from the scene
            gameObject.SetActive(false);
        }
    }

    void CreatePickupEffect()
    {
        GameObject effectObject = new GameObject("SwordPiecePickupEffect");
        effectObject.transform.position = transform.position;

        ParticleSystem particleSystem = effectObject.AddComponent<ParticleSystem>();

        var main = particleSystem.main;
        main.duration = 0.6f;
        main.startLifetime = 0.5f;
        main.startSpeed = 2.5f;
        main.startSize = 0.15f;
        main.maxParticles = 30;
        main.loop = false;

        var emission = particleSystem.emission;
        emission.rateOverTime = 0;
        emission.SetBursts(new ParticleSystem.Burst[]
        {
            new ParticleSystem.Burst(0f, 25)
        });

        var shape = particleSystem.shape;
        shape.shapeType = ParticleSystemShapeType.Sphere;
        shape.radius = 0.4f;

        var renderer = particleSystem.GetComponent<ParticleSystemRenderer>();
        renderer.renderMode = ParticleSystemRenderMode.Billboard;

        particleSystem.Play();

        Destroy(effectObject, 1.2f);
    }
}