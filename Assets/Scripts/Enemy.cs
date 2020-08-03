using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private Ball ball;
    [Range(0, 1000)]
    [SerializeField] private float speed;
    [Range(float.Epsilon, 100)]
    [SerializeField] private float deltaSpeed;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        gm.NewLvl += LvlUp;
    }

    private void Update()
    {
        transform.position = new Vector3(startPosition.x, startPosition.y, Mathf.Lerp(transform.position.z, ball.transform.position.z, speed * Time.deltaTime));
    }

    private void LvlUp()
    {
        transform.position = startPosition;
        speed += deltaSpeed;
    }
}
