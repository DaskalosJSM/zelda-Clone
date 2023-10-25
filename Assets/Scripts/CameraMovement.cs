using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float mouseSensitivity;
    private float rotationY;
    private float rotationX;

    [SerializeField]
    private float distanceFromTarget;
    private Vector3 currentRotation;
    private Vector3 smoothVelocity = Vector3.zero;

    [SerializeField]
    private float smoothTime;

    [SerializeField]
    private Vector2 rotationXMinMax;

    [SerializeField]
    private Vector2 rotationYMinMax;

    [SerializeField]
    private LayerMask collisionMask; // Layer mask to determine which objects the camera can collide with

    public Vector3 CameraOffset;
    public GameObject player;
    private Vector3 MovementPosition;
    private Vector3 velocity = Vector3.zero;
    public float maxDistance; // Maximum distance the camera can be from the player
    public float minDistance; // Minimum distance the camera can be from the player
    private Vector2 cameraMovementInput;
    private PlayerInput PlayerInputMap;

    void Start()
    {
        PlayerInputMap = GetComponent<PlayerInput>();
    }
    void FixedUpdate()
    {
        InputRotation();

        RaycastHit hit;
        float currentDistance = distanceFromTarget;
        if (Physics.Raycast(player.transform.position + CameraOffset, -transform.forward, out hit, maxDistance, collisionMask))
        {
            // If the camera is colliding with an object, move it closer to the player
            currentDistance = hit.distance - minDistance;
            Vector3 targetPosition = player.transform.position + CameraOffset - transform.forward * currentDistance;
            transform.position = transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0.1f);
        }
        // Clamp the distance to be between minDistance and maxDistance
        currentDistance = Mathf.Clamp(currentDistance, minDistance, maxDistance);
        MovementPosition = player.transform.position + CameraOffset - transform.forward * currentDistance;
        transform.position = MovementPosition;
    }

    void InputRotation()
    {
        cameraMovementInput = PlayerInputMap.actions["Camera"].ReadValue<Vector2>();
        rotationY += cameraMovementInput.x * mouseSensitivity;
        rotationX += -cameraMovementInput.y * mouseSensitivity;
        rotationX = Mathf.Clamp(rotationX, rotationXMinMax.x, rotationXMinMax.y);
        Vector3 nextRotation = new Vector3(rotationX, rotationY);
        currentRotation = Vector3.SmoothDamp(currentRotation, nextRotation, ref smoothVelocity, smoothTime);
        transform.localEulerAngles = currentRotation;
    }
}