using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GachaMiniGame : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private int Attemps;
    [SerializeField] private Image bug;

    public Sprite currentBugImage;

    private bool bActivateGame;
    private int correctButtonIndex;
    private int AttemptsLeft;
    private Image currentBug;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reroll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked(Button button)
    {
        if (System.Array.IndexOf(buttons, button) == correctButtonIndex)
        {
            print("CORRECT BUTTON");
            GameObject.FindWithTag("GameController").GetComponent<GameController>().BugCaught(currentBug);
            DeactivateGame();
        }
        else if (System.Array.IndexOf(buttons, button) != correctButtonIndex)
        {
            print("WRONG BUTTON");
            if (AttemptsLeft > 1)
            {
                AttemptsLeft--;
            }
            else if(AttemptsLeft == 1)
            {
                DeactivateGame();
            }
        }
    }

    private void MoveBug()
    {
        bug.transform.position = buttons[correctButtonIndex].transform.position;
        bug.sprite = currentBugImage;
    }
    
    public void ActivateGame(Image bug)
    {
        bActivateGame = true;
        print("GAME ACTIVATED");
        gameObject.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().canMove = false;
        currentBug = bug;
    }

    private void DeactivateGame()
    {
        bActivateGame = false;
        print("GAME DEACTIVATED");
        gameObject.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().canMove = true;
        Reroll();
        GameObject.FindWithTag("GameController").GetComponent<GameController>().Reroll();
    }

    private void Reroll()
    {
        correctButtonIndex = Random.Range(0, 5);
        AttemptsLeft = Attemps;
        MoveBug();
    }
}
