using UnityEngine;
using System.Collections;

public class NewPortalCamera : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject portal;
    public GameObject otherPortal;

    // Each frame reposition the camera to mimic the players offset from the other portals position
    void Update()
    {
        // Offset the camera from the portal equal to the player's offset from the other portal
        Vector3 playerOffsetFromPortal = playerCamera.transform.position - otherPortal.transform.position;
        transform.position = portal.transform.position + playerOffsetFromPortal;

        // adjust rotation of camera
        /*Quaternion portalRotationalDifference = Quaternion.AngleAxis(Quaternion.Angle(portal.transform.rotation, otherPortal.transform.rotation), Vector3.up);
        Vector3 newFacing = portalRotationalDifference * playerCamera.transform.forward;
        transform.rotation = Quaternion.LookRotation(newFacing, Vector3.up);*/
        transform.rotation = playerCamera.transform.rotation;
    }
}
