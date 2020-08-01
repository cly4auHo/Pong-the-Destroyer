using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Action Hit;
    [Range(0, 500)]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigibody;
    private Vector3 velocity;
    private Vector3 startPosition;
    private const string targetTag = "Target";

    private void Awake()
    {
        startPosition = transform.position;
        enabled = false;
    }

    private void FixedUpdate()
    {
        rigibody.AddForce(velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(targetTag))
        {
            enabled = false;
            Hit?.Invoke();
        }
    }

    public void Move(Vector3 multipleSpeed)
    {
        if (multipleSpeed.magnitude > 1)
        {
            velocity = speed * multipleSpeed;
            enabled = true;
        }
    }

    public void Return()
    {
        if (!enabled)
        {
            rigibody.velocity = Vector3.zero;
            transform.position = startPosition;
        }
    }
}