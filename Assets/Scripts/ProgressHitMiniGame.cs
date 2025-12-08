using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressHitMiniGame : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private TMP_Text resultText;
    
    [SerializeField] private RectTransform marker;

    private RectTransform hitArea;

    public float speed = 1.0f;
    public KeyCode hitKey = KeyCode.Space;

    private float markerValue = 0f;
    private bool movingRight = true;

    void Start()
    {
        progressBar.value = 0f;
        resultText.text = "";
    }

    void Update()
    {
        MoveMarker();

        if (Input.GetKeyDown(hitKey))
        {
            CheckHit();
        }
    }

    void MoveMarker()
    {
        float delta = speed * Time.deltaTime;

        if(movingRight)
        {
            markerValue += delta;

            if(markerValue >= 1f)
            {
                markerValue = 1f;
                movingRight = true;
            }
        }

        progressBar.value = markerValue;

        Vector2 barSize = progressBar.GetComponent<RectTransform>().sizeDelta;
        float xPos = Mathf.Lerp(-barSize.x / 2f, barSize.x / 2f, markerValue);
        marker.anchoredPosition = new Vector2(xPos, marker.anchoredPosition.y);
    }

    void CheckHit()
    { 
        if (IsMarkerInHitArea())
        {
            resultText.text = "Good Job!";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "What a pity!";
            resultText.color = Color.red;
        }
    }

    bool IsMarkerInHitArea()
    {
        float markerX = marker.anchoredPosition.x;
        float hitX = hitArea.anchoredPosition.x;

        float halfSize = hitArea.sizeDelta.x / 2f;

        return markerX >= hitX - halfSize && markerX <= hitX + halfSize;
    }
}
