using UnityEngine;
using System.Collections;

public class Teleporter : MonoBehaviour
{
    public GameObject player;
    public GameObject otherTeleporter;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController firstPersonController;

    private bool playerOverlapping = false;

    void Update()
    {
        if (playerOverlapping)
        {
            if (Vector3.Dot(transform.right, player.transform.position - transform.position) < 0) // only transport the player once he's moved across plane
            {
                float rotDiff = -Quaternion.Angle(transform.rotation, otherTeleporter.transform.rotation);
                rotDiff += 180;
                //player.transform.Rotate(Vector3.up, rotDiff);

                Vector3 positionOffset = player.transform.position - transform.position;
                positionOffset = Quaternion.Euler(0, rotDiff, 0) * positionOffset;
                var newPosition = otherTeleporter.transform.position + positionOffset;
                player.transform.position = newPosition;

                /*Vector3 offset = transform.InverseTransformPoint(player.transform.position);
                player.transform.position = otherTeleporter.transform.TransformPoint(offset);
                player.transform.rotation = Quaternion.LookRotation(otherTeleporter.transform.InverseTransformDirection(player.transform.forward));*/
                //Debug.Break();
                
                playerOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            playerOverlapping = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            playerOverlapping = false;
    }
}
