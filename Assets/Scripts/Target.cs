using System;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Action BallHit;
    private const string ballTag = "Ball";

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals(ballTag))
        {
            BallHit?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void NewLvl()
    {
        gameObject.SetActive(true);
    }
}
