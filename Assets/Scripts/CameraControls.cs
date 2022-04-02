using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour {
    [SerializeField] private InputAction movement;
    [SerializeField] private float speed = 1;
    [SerializeField] private new Transform camera;
    [SerializeField] private float sensitivity = 1;

    void OnEnable() => movement.Enable();
    void OnDisable() => movement.Disable();

    void Update() {
        Move();
        Rotate();
    }

    private void Move() {
        var vector = movement.ReadValue<Vector2>().normalized;
        if (vector == Vector2.zero) {
            return;
        }

        var pivot = transform;
        var delta = vector.y * pivot.forward + vector.x * pivot.right;
        pivot.position += delta * (Time.deltaTime * speed);
    }

    private void Rotate() {
        if (!Mouse.current.rightButton.isPressed) {
            return;
        }

        var mouse = Mouse.current.delta.ReadValue();
        transform.localRotation *= Quaternion.Euler(0, mouse.x * sensitivity, 0);
        camera.localRotation *= Quaternion.Euler(-mouse.y * sensitivity, 0, 0);
    }
}
