using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Action NewLvl;
    [SerializeField] private Target[] targets;
    private int targetsDestroyed;

    private void Start()
    {
        foreach (Target target in targets)
            target.BallHit += TargetDestroy;
    }

    private void TargetDestroy()
    {
        targetsDestroyed++;

        if (targetsDestroyed == targets.Length)
        {
            targetsDestroyed = 0;
            NewLvl?.Invoke();
        }
    }
}
