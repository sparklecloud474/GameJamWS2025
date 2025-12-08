using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointAndClickGame : MonoBehaviour
{
    public RectTransform gameArea;
    public Button targetButton;
    public float timeToClick = 1.5f;

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timerText;

    private float timer;
    private int score = 0;

    void Start()
    {
        timer = timeToClick;
        MoveButton();
        UpdateUI();

        targetButton.onClick.AddListener(OnButtonClicked);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("F2");

        if(timer <= 0)
        {
            MissedButton();
        }
    }

    private void OnButtonClicked()
    {
        score++;
        UpdateUI();
        MoveButton();
        ResetTimer();
    }

    private void MissedButton()
    {
        MoveButton();
        ResetTimer();
    }

    private void ResetTimer()
    {
        timer = timeToClick;
    }

    private void MoveButton()
    {
        float x = Random.Range(-gameArea.rect.width / 2f, gameArea.rect.width / 2f);
        float y = Random.Range(-gameArea.rect.height / 2f, gameArea.rect.height / 2f);

        targetButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
    }

    private void UpdateUI()
    {
        scoreText.text = "Score: " + score;
    }
}
