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
    
    public List<int> collectedBugs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reroll();
        nextBug = Bugs[Random.Range(0, Bugs.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartRandomGame()
    {
        if (nextBug)
        {
            if (gameIndex == 0)
            {
                SkillCheckPuzzle.GetComponent<SkillCheckPuzzle>().ActivateGame(nextBug); // nextBug
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
    }

    public void Reroll()
    {
        gameIndex = Random.Range(0, 3);
    }

    public void BugCaught(Image bug)
    {
        print(bug.name);
        collectedBugs.Add(Bugs.IndexOf(bug));
        Bugs.Remove(bug);
        if (Bugs.Count >= 1)
        {
            nextBug = Bugs[Random.Range(0, Bugs.Count)];
        }
        else if(Bugs.Count == 0)
        {
            nextBug = null;
        }
    }
}
