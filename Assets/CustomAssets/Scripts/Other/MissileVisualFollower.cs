using UnityEngine;

public class MissileVisualFollower : MonoBehaviour
{
    [Header("Target (Root Missile)")]
    public Transform root;

    [Header("Smoothing")]
    public float rotationSmoothSpeed = 8f;

    [Header("Model Correction")]
    [Tooltip("Adjust if your model forward is not Z+")]
    public Vector3 rotationOffsetEuler;

    void LateUpdate()
    {
        if (root == null) return;

        Vector3 dir = root.forward;

        // Prevent invalid rotations
        if (dir.sqrMagnitude < 0.001f) return;

        Quaternion targetRotation = Quaternion.LookRotation(dir, Vector3.up);

        // Apply model correction (IMPORTANT)
        targetRotation *= Quaternion.Euler(rotationOffsetEuler);

        // Smooth visual rotation
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSmoothSpeed * Time.deltaTime
        );
    }
}