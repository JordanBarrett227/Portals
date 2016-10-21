using UnityEngine;
using System.Collections;

public class PortalCamera : MonoBehaviour
{
    public GameObject playerCamera;
    public GameObject portal;
    public GameObject otherPortal;

    public GameObject Debug1;

    void Start()
    {
        //transform.parent = portal.transform;
    }

	// Each frame reposition the camera to mimic the players offset from the other portals position
	void Update ()
    {
        // Offset the camera from the portal equal to the player's offset from the other portal
        //Vector3 playerOffsetFromPortal = playerCamera.transform.position - otherPortal.transform.position;
        //transform.position = portal.transform.position + playerOffsetFromPortal;

        Vector3 playerOffsetFromPortal = otherPortal.transform.InverseTransformPoint(playerCamera.transform.position);
        transform.position = portal.transform.TransformPoint(playerOffsetFromPortal);


        // adjust rotation of camera
        //transform.rotation = playerCamera.transform.rotation;

        Vector3 relativeRotation = otherPortal.transform.InverseTransformDirection(playerCamera.transform.forward);
        transform.rotation = Quaternion.LookRotation(portal.transform.TransformDirection(relativeRotation));
    }
}
