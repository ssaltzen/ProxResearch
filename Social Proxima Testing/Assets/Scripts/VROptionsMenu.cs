using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// VR Options menu script based on Furniture menu script.
public class VROptionsMenu : MonoBehaviour
{
    public static bool DoSnapTurn = false;
    public static bool DoTeleportation = false;

    [SerializeField] private Toggle snapTurnToggle;
    [SerializeField] private Toggle teleportationToggle;

    private void Awake()
    {
        snapTurnToggle.isOn = DoSnapTurn;
        teleportationToggle.isOn = DoTeleportation;
    }

    private void Update()
    {
        DoSnapTurn = snapTurnToggle.isOn;
        DoTeleportation = teleportationToggle.isOn;
    }
}
