using UnityEngine;
using Oculus.Interaction.HandGrab;

public class RegisterInteractableOnEnable : MonoBehaviour
{
    //void Start()
    //{
    //    // Small delay to ensure everything is initialized
    //    Invoke(nameof(ReregisterInteractables), 0.1f);
    //}

    //void ReregisterInteractables()
    //{
    //    // Get all DistanceHandGrabInteractable components
    //    var interactables = GetComponentsInChildren<DistanceHandGrabInteractable>();

    //    foreach (var interactable in interactables)
    //    {
    //        // Force re-enable to trigger registration
    //        interactable.enabled = false;
    //        interactable.enabled = true;

    //        Debug.Log($"Re-registered interactable: {interactable.gameObject.name}");
    //    }

    //    Debug.Log($"Total interactables re-registered: {interactables.Length}");
    //}
}