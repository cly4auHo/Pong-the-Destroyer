using UnityEngine;

public class Ball : MonoBehaviour
{
    [Range(0, 500)]
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rigibody;
    private Vector3 velocity;
    private Vector3 startPosition;
    private bool isFlying;
    private const string targetTag = "Target";
    private const string enemyTag = "Enemy";

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        velocity = Vector3.Reflect(velocity, collision.transform.position.normalized);
        Stop();
        rigibody.AddForce(velocity, ForceMode.VelocityChange);
        string tag = collision.gameObject.tag;

        if (tag.Equals(enemyTag) || tag.Equals(targetTag))
        {
            isFlying = false;
            ReturnToPlayer();
        }
    }

    public void Move(Vector3 multipleSpeed)
    {
        velocity = speed * multipleSpeed;
        isFlying = true;
        rigibody.AddForce(velocity, ForceMode.VelocityChange);
    }

    public void ReturnToPlayer()
    {
        Stop();
        rigibody.isKinematic = true;
        transform.position = startPosition;
        rigibody.isKinematic = false;
    }

    public bool IsFlying()
    {
        return isFlying;
    }

    private void Stop()
    {
        rigibody.velocity = Vector3.zero;
        rigibody.angularVelocity = Vector3.zero;
    }
}