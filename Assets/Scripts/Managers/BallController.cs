using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private Player player;
    [SerializeField] private GameObject arrowParent;
    [SerializeField] private GameObject arrow;
    [Range(1, 50000)]
    [SerializeField] private float distanseRayCast = 400;
    private Vector3 strenght;
    private const float arrowLenght = 10;

    private void Start()
    {
        ball.Hit += ReturnBallToPlayer;
        arrow.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && !ball.enabled)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, distanseRayCast))
            {
                if (hit.point.x > player.transform.position.x && Mathf.Pow(hit.point.x, 2) >= Mathf.Pow((player.transform.position - hit.point).magnitude, 2))
                {
                    Vector3 target = new Vector3(hit.point.x, arrowParent.transform.position.y, hit.point.z);
                    strenght = hit.point - player.transform.position;
                    arrow.SetActive(true);
                    arrowParent.transform.LookAt(target);
                    arrow.transform.position = new Vector3((hit.point.x + player.transform.position.x) / 2, arrow.transform.position.y, (hit.point.z + player.transform.position.z) / 2);
                    arrow.transform.localScale = new Vector3(strenght.magnitude / arrowLenght, 1, 1);
                }
                else
                {
                    Vector3 target = new Vector3(hit.point.x, arrowParent.transform.position.y, hit.point.z);
                    arrow.SetActive(true);
                    arrowParent.transform.LookAt(target);
                }
            }

            return;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ball.Move(strenght.normalized);
        }

        arrow.SetActive(false);
    }

    private void ReturnBallToPlayer()
    {
        ball.Return();
    }
}
