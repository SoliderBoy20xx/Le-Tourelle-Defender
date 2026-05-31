using UnityEngine;

public class TurretCamera : MonoBehaviour
{
    [SerializeField] private Transform turretBase;
    [SerializeField] private Transform turretHead;

    [Header("Position")]
    [SerializeField] private Vector3 offset = new Vector3(0f, 3f, -6f);

    [Header("Rotation")]
    [SerializeField] private float rotationFollowSpeed = 5f;

    private void LateUpdate()
    {
        // Position camera behind turret
        transform.position = turretBase.TransformPoint(offset);

        // Look where the head is aiming
        Quaternion targetRotation =
            Quaternion.LookRotation(turretHead.forward, Vector3.up);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationFollowSpeed * Time.deltaTime
        );
    }
}