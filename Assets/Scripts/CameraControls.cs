using UnityEngine;
using UnityEngine.InputSystem;

public class CameraControls : MonoBehaviour {
    [SerializeField] private InputAction movement;
    [SerializeField] private float speed = 1;

    void OnEnable() => movement.Enable();
    void OnDisable() => movement.Disable();

    void Update() {
        Move();
    }

    private void Move() {
        var vector = movement.ReadValue<Vector2>().normalized;
        if (vector == Vector2.zero) {
            return;
        }

        var cameraTransform = transform;
        var delta = vector.y * cameraTransform.forward + vector.x * cameraTransform.right;
        delta.y = 0;
        cameraTransform.position += delta * (Time.deltaTime * speed);
    }
}
