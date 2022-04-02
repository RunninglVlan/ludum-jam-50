using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour {
    [SerializeField] private InputAction movement;
    [SerializeField] private float movementSpeed = 1;
    [SerializeField] private new Transform camera;
    [SerializeField] private float rotationSensitivity = 1;
    [SerializeField] private float zoomSensitivity = 1;

    private float zoomCurrent;
    private float zoomTarget;

    void OnEnable() => movement.Enable();
    void OnDisable() => movement.Disable();

    void Update() {
        Move();
        Rotate();
        Zoom();
    }

    private void Move() {
        var vector = movement.ReadValue<Vector2>().normalized;
        if (vector == Vector2.zero) {
            return;
        }

        var pivot = transform;
        var delta = vector.y * pivot.forward + vector.x * pivot.right;
        pivot.position += delta * (Time.deltaTime * movementSpeed);
    }

    private void Rotate() {
        if (!Mouse.current.rightButton.isPressed) {
            return;
        }

        var mouse = Mouse.current.delta.ReadValue();
        transform.localRotation *= Quaternion.Euler(0, mouse.x * rotationSensitivity, 0);
        camera.localRotation *= Quaternion.Euler(-mouse.y * rotationSensitivity, 0, 0);
    }

    private void Zoom() {
        var scroll = Mouse.current.scroll.ReadValue();
        if (scroll.sqrMagnitude == 0) {
            return;
        }

        var pivot = transform;
        pivot.localPosition += camera.forward * scroll.y * zoomSensitivity;
    }
}
