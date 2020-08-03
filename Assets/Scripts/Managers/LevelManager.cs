using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameManager gm;
    private int currentLvl;

    private void Start()
    {
        gm.NewLvl += NextLvl;
        NextLvl();
    }

    private void NextLvl()
    {
        text.text = "Level " + ++currentLvl;
    }
}
