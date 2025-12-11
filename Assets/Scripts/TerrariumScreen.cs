using UnityEngine;
using UnityEngine.UI;

public class TerrariumScreen : MonoBehaviour
{

    [SerializeField] private Button LeaveTerrariumButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LeaveTerrariumButton.onClick.AddListener(OnLeaveTerrariumClicked);
    }

    private void OnLeaveTerrariumClicked()
    {
        gameObject.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().canMove = true;
    }

    public void EnterTerrarium()
    {
        gameObject.SetActive(true);
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().canMove = false;
    }
}
