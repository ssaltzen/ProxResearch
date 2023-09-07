using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRMovementToggle : MonoBehaviour
{
    [SerializeField] private ActionBasedSnapTurnProvider SnapTurnProvider;
    [SerializeField] private TeleportationProvider TeleportationProvider;

    void Awake()
    {
        // Enable or Disable movement options based on menu selection.
        if (VROptionsMenu.DoSnapTurn)
            EnableSnapTurn();
        else
            DisableSnapTurn();

        if (VROptionsMenu.DoTeleportation)
            EnableTeleportation();
        else
            DisableTeleportation();
    }

    public void EnableSnapTurn()
    {
        SnapTurnProvider.enabled = true;
        Debug.Log("Enabled VR snap turning.");
    }

    public void DisableSnapTurn()
    {
        SnapTurnProvider.enabled = false;
        Debug.Log("Disabled VR snap turning.");
    }

    public void EnableTeleportation()
    {
        // May need additional toggles for controller rays here.
        TeleportationProvider.enabled = true;
        Debug.Log("Enabled VR teleportation.");
    }

    public void DisableTeleportation()
    {
        TeleportationProvider.enabled = false;
        Debug.Log("Disabled VR teleportation.");
    }
}
