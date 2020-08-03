using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Action BallHit;
    private const string ballTag = "Ball";
    private const string gmTag = "GameManager";

    private void Start()
    {
        GameObject.FindGameObjectWithTag(gmTag).GetComponent<GameManager>().NewLvl += NewLvl;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(ballTag))
        {
            gameObject.SetActive(false);
            BallHit?.Invoke();
        }
    }

    private void NewLvl()
    {
        gameObject.SetActive(true);
    }
}
