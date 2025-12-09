using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class LanyrinthMiniGame : MonoBehaviour
{
    public RectTransform cursor;
    public RectTransform gameArea;

    public bool started = false;
    public bool failed = false;
    public bool completed = false;

    public GameObject winPanel;
    public GameObject losePanel;

    void Update()
    {
        if (Mouse.current == null)
            return;

        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector2 mousePos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            gameArea,
            screenPos,
            null,
            out mousePos
            );

        cursor.anchoredPosition = mousePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (failed || completed) return;

        if (collision.CompareTag("Start"))
        {
            started = true;
            failed = false;
            completed = false;
        }

        if (collision.CompareTag("Goal") && started)
        {
            completed = true;
            winPanel.SetActive(true);
        }

        if (collision.CompareTag("Patch") == false && started)
        {
            failed = true;
            losePanel.SetActive(true);
        }
    }
}
