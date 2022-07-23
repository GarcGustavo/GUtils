using UnityEngine;

//<summary>
// PortalCamera full description
//</summary>

namespace _Project.Systems.PortalSystem.Prototype
{
    public class PortalCamera : MonoBehaviour
    {
        public Transform playerCamera;
        public Transform portal;
        public Transform otherPortal;
        private void Update()
        {
            MoveCamera();
        }

        private void MoveCamera()
        {
            // Offset the camera to the portal
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            transform.position = portal.position + playerOffsetFromPortal;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
        
    }
}