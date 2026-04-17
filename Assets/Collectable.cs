using UnityEngine;

// 1. Keep only ONE enum list. This is what shows up in your Inspector dropdown.
public enum ItemType { Soul, Egg, Gloomroot, Biscuit, Feed, LiquidFire, Obol }

public class Collectable : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";

    // Static variables to track your inventory globally
    public static bool hasSoul = false;
    public static bool hasGloomroot = false;
    public static bool hasEgg = false;
    public static bool hasBiscuit = false;
    public static bool hasFeed = true; // Starts true as requested!
    public static bool hasLiquidFire = false;
    public static bool hasObol = false;
    public static bool itemsAreStamped = false; // New checkbox for the Appraisal

    // This creates the dropdown menu in Unity's Inspector
    public ItemType itemType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            HandleCollection();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            HandleCollection();
        }
    }

    private void HandleCollection()
    { 
        // 1. Find the player's inventory component
        PlayerInventory inv = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

        if (inv != null)
        {
            // 2. Tell the inventory to add 1 of whatever this item is
            inv.UpdateCount(itemType, 1);
        }
    
        // 2. This "Switch" checks which item type you selected in the Inspector
        // and sets the correct boolean to true.
        switch (itemType)
        {
            case ItemType.Soul:
                hasSoul = true;
                break;
            case ItemType.Egg:
                hasEgg = true;
                break;
            case ItemType.Gloomroot:
                hasGloomroot = true;
                break;
            case ItemType.Biscuit:
                hasBiscuit = true;
                break;
            case ItemType.LiquidFire:
                hasLiquidFire = true;
                break;
            case ItemType.Feed:
                hasFeed = true;
                break;
            case ItemType.Obol:
                hasObol = true;
                break;

        }       

        Debug.Log(itemType + " collected! Logic updated.");

        // 3. Play sound or VFX here if you have them!

        // Destroy the object so it disappears from the world
        Destroy(gameObject);
    }
}
