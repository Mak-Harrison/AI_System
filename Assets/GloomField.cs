using UnityEngine;

public class SimpleFieldExchange : MonoBehaviour
{
    [SerializeField] private GameObject gloomrootToShow; // Drag the hidden Gloomroot here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Check the static variable from the other script
            if (Collectable.hasSoul)
            {
                gloomrootToShow.SetActive(true); // Make it appear!
                Collectable.hasSoul = false; // "Spend" the soul

                Debug.Log("The Soul bloomed the Gloomroot!");
            }
            else
            {
                Debug.Log("You have no Soul to give the field.");
            }
        }
    }
}