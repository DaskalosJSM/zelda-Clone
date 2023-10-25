using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 0f;
    [SerializeField] private float forceAcumulation = 0f;
    [SerializeField] private float delay;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 localForward = transform.forward;
        rb.AddForce(localForward * currentSpeed * forceAcumulation, ForceMode.Acceleration);
    }

    private IEnumerator KinematicDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Make the arrow kinematic
        rb.isKinematic = true;
    }

    private void OnTriggerExit(Collider collision)
    {

        // Stop the arrow from moving
        currentSpeed = 0f;
        forceAcumulation = 0f;

        // Start the coroutine to launch isKinematic after a timer (e.g., 2 seconds)
        StartCoroutine(KinematicDelay(delay));
    }
}








