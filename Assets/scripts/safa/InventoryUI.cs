using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }
}