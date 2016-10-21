using UnityEngine;
using System.Collections;

public class PortalGun : MonoBehaviour
{
    public GameObject LeftPortal;
    public GameObject RightPortal;

	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
            ShootPortal(LeftPortal);

        if (Input.GetMouseButtonDown(1))
            ShootPortal(RightPortal);
	}

    void ShootPortal(GameObject portal)
    {
        int midX = Screen.width / 2;
        int midY = Screen.height / 2;

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(midX, midY, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            portal.transform.position = hit.point;
            portal.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }
}
