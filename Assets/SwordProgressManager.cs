using UnityEngine;
using UnityEngine.UI;

public class SwordProgressManager : MonoBehaviour
{
    [Header("Sword Objects In Player Hand")]
    public GameObject woodenSword;
    public GameObject bigSword;

    [Header("Progress Bar Sliders")]
    public Slider progress25;
    public Slider progress50;
    public Slider progress75;
    public Slider progress100;

    [Header("Inventory Piece Icons")]
    public GameObject inventoryPiece1;
    public GameObject inventoryPiece2;
    public GameObject inventoryPiece3;
    public GameObject inventoryPiece4;

    private int collectedPieces = 0;
    private int totalPieces = 4;

    void Start()
    {
        woodenSword.SetActive(true);
        bigSword.SetActive(false);

        inventoryPiece1.SetActive(false);
        inventoryPiece2.SetActive(false);
        inventoryPiece3.SetActive(false);
        inventoryPiece4.SetActive(false);

        UpdateProgressBar();
    }

    public void CollectSwordPiece(int pieceID)
    {
        collectedPieces++;

        Debug.Log("Collected sword piece: " + pieceID);
        Debug.Log("Progress: " + collectedPieces + "/" + totalPieces);

        AddPieceToInventory(pieceID);
        UpdateProgressBar();

        if (collectedPieces >= totalPieces)
        {
            UpgradeSword();
        }
    }

    void AddPieceToInventory(int pieceID)
    {
        if (pieceID == 1)
        {
            inventoryPiece1.SetActive(true);
        }
        else if (pieceID == 2)
        {
            inventoryPiece2.SetActive(true);
        }
        else if (pieceID == 3)
        {
            inventoryPiece3.SetActive(true);
        }
        else if (pieceID == 4)
        {
            inventoryPiece4.SetActive(true);
        }
    }

    void UpdateProgressBar()
    {
        progress25.minValue = 0;
        progress25.maxValue = 100;

        progress50.minValue = 0;
        progress50.maxValue = 100;

        progress75.minValue = 0;
        progress75.maxValue = 100;

        progress100.minValue = 0;
        progress100.maxValue = 100;

        progress25.value = collectedPieces >= 1 ? 100 : 0;
        progress50.value = collectedPieces >= 2 ? 100 : 0;
        progress75.value = collectedPieces >= 3 ? 100 : 0;
        progress100.value = collectedPieces >= 4 ? 100 : 0;
    }

    void UpgradeSword()
    {
        woodenSword.SetActive(false);
        bigSword.SetActive(true);

        Debug.Log("All sword pieces collected! Sword upgraded!");
    }
}