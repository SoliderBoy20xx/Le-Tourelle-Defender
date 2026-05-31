using UnityEngine;
using UnityEngine.InputSystem;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 60f;

    [SerializeField]
    private float pitchLimit = 20f;

    private float currentPitch;

    private void Update()
    {
        RotateWithKeyboard();
    }


    private void RotateWithKeyboard()
    {
        if (Keyboard.current == null)
            return;

        float yawInput = 0f;
        float pitchInput = 0f;

        if (Keyboard.current.dKey.isPressed)
            yawInput += 1f;

        if (Keyboard.current.aKey.isPressed)
            yawInput -= 1f;

        if (Keyboard.current.wKey.isPressed)
            pitchInput += 1f;

        if (Keyboard.current.sKey.isPressed)
            pitchInput -= 1f;

        if (yawInput != 0f)
            transform.Rotate(Vector3.up, yawInput * rotateSpeed * Time.deltaTime, Space.World);

        if (pitchInput != 0f)
        {
            currentPitch = Mathf.Clamp(currentPitch + pitchInput * rotateSpeed * Time.deltaTime, -pitchLimit, pitchLimit);
            Vector3 euler = transform.localEulerAngles;
            transform.localRotation = Quaternion.Euler(currentPitch, euler.y, euler.z);
        }
    }
}