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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Reroll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        
    }

    private void MoveBug()
    {
        bug.transform.position = buttons[correctButtonIndex].transform.position;
        //bug.sprite = currentBugImage;
    }
    
    public void ActivateGame()
    {
        bActivateGame = true;
        print("GAME ACTIVATED");
        gameObject.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().canMove = false;
    }

    private void DeactivateGame()
    {
        bActivateGame = false;
        print("GAME DEACTIVATED");
        gameObject.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().canMove = true;
        Reroll();
    }

    private void Reroll()
    {
        correctButtonIndex = Random.Range(0, 5);
        AttemptsLeft = Attemps;
        MoveBug();
    }
}
