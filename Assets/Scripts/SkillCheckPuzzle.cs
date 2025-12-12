using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Runtime.CompilerServices;

public class SkillCheckPuzzle : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private RectTransform marker;
    [SerializeField] private float speed;
    [SerializeField] private Image bugImage;

    private int areaMin = 30;
    private int areaMax = 68;
    private float timerUntilDisable = 2f;
    private float timer;
    private bool bLeftToRight;
    private GameObject playerRef;
    private Image currentBug;


    public bool bActivateGame = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = timerUntilDisable;
        slider.value = 0;
        resultText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (bActivateGame == true)
        {
            if(bLeftToRight == true && slider.value < 99)
            {
                slider.value = slider.value + 1 * speed;
            }
            else if(bLeftToRight == false && slider.value >= 1)
            {
                slider.value = slider.value - 1 * speed;
            }
            else if (slider.value <= 1)
            {
                bLeftToRight = true;
            }
            else if (slider.value >= 99)
            {
                bLeftToRight = false;
            }
        }

        
    }

    public void CheckValue()
    {
        bActivateGame = false;

        if (slider.value >= areaMin && slider.value <= areaMax)
        {
            resultText.text = "Good Job!";
            resultText.color = Color.green;
            GameObject.FindWithTag("GameController").GetComponent<GameController>().BugCaught(currentBug);
            DeactivateGame();
        }
        else if (slider.value < areaMin)
        {
            resultText.text = "What a pity!";
            resultText.color = Color.red;
            DeactivateGame();
        }
        else if (slider.value > areaMax)
        {
            resultText.text = "What a pity!";
            resultText.color = Color.red;
            
            DeactivateGame();
        }
    }

    public void ActivateGame(Image bug)
    {
        bugImage.sprite = bug.sprite;
        slider.value = 0;
        resultText.text = "";
        bActivateGame = true;
        gameObject.SetActive(true);
        playerRef = GameObject.FindWithTag("Player");
        playerRef.GetComponent<PlayerController>().canMove = false;
        currentBug = bug;
    }

    private void DeactivateGame()
    {
        bActivateGame = false;
        gameObject.SetActive(false);
        playerRef.GetComponent<PlayerController>().canMove = true;
        GameObject.FindWithTag("GameController").GetComponent<GameController>().Reroll();
    }
}
