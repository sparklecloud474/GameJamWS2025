using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject SkillCheckPuzzle;
    [SerializeField] private GameObject PointAndClick;
    [SerializeField] private GameObject GachaGame;
    [SerializeField] private List<Image> Bugs; // = new List<Image>();

    [Header("NEXT BUG")]
    [SerializeField] private Image nextBugTest;

    private int gameIndex;
    private Image nextBug;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reroll();
        nextBug = Bugs[Random.Range(0, Bugs.Count + 1)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRandomGame()
    {
        if (gameIndex == 0)
        {
            SkillCheckPuzzle.GetComponent<SkillCheckPuzzle>().ActivateGame(); // nextBug
        }
        else if (gameIndex == 1)
        {
            PointAndClick.GetComponent<PointAndClickGame>().ActivateGame(nextBug);
        }
        else if (gameIndex == 2)
        {
            GachaGame.GetComponent<GachaMiniGame>().ActivateGame(nextBug);
        }
    }

    public void Reroll()
    {
        gameIndex = Random.Range(0, 3);
    }

    public void BugCaught(Image bug)
    {
        GameObject.FindWithTag(bug.tag).SetActive(true);
        Bugs.Remove(bug);
        nextBug = Bugs[Random.Range(0, Bugs.Count + 1)];
    }
}
