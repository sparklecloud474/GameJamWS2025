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

    private int areaMin = 30;
    private int areaMax = 68;
    private bool bLeftToRight;
    private GameObject playerRef;

    public bool bActivateGame = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
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
            print("YOU WON");
            DeactivateGame();
        }
        else if (slider.value < areaMin)
        {
            print("YOU LOST");
            DeactivateGame();
        }
        else if (slider.value > areaMax)
        {
            print("YOU LOST");
            DeactivateGame();
        }
    }

    public void ActivateGame()
    {
        slider.value = 0;
        resultText.text = "";
        bActivateGame = true;
        gameObject.SetActive(true);
        playerRef = GameObject.FindWithTag("Player");
        playerRef.GetComponent<PlayerController>().canMove = false;
    }

    private void DeactivateGame()
    {
        bActivateGame = false;
        gameObject.SetActive(false);
        playerRef.GetComponent<PlayerController>().canMove = true;
        GameObject.FindWithTag("GameController").GetComponent<GameController>().Reroll();
    }
}
