using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject SkillCheckPuzzle;
    [SerializeField] private GameObject PointAndClick;

    private int gameIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reroll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRandomGame()
    {
        if (gameIndex == 0)
        {
            SkillCheckPuzzle.GetComponent<SkillCheckPuzzle>().ActivateGame();
        }
        else if (gameIndex == 1)
        {
            PointAndClick.GetComponent<PointAndClickGame>().ActivateGame();
        }
    }

    public void Reroll()
    {
        // gameIndex = Random.Range(0, 1);
        if(gameIndex == 0)
        {
            gameIndex = 1;
        }
        else
        {
            gameIndex = 0;
        }
    }
}
