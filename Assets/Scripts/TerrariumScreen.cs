using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TerrariumScreen : MonoBehaviour
{

    [SerializeField] private Button LeaveTerrariumButton;
    [SerializeField] private List<GameObject> allBugs;
    [SerializeField] private GameObject quitButton;

    private List<int> collectedBugs;

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
        UpdateBugs();

    }

    private void UpdateBugs()
    {
        collectedBugs = GameObject.FindWithTag("GameController").GetComponent<GameController>().collectedBugs;

        if (collectedBugs.Count == 9)
        {
            quitButton.SetActive(true);
        }

        for (int i = 0; i < collectedBugs.Count; i++)
        {
            print("gesammelter Käfer:" + collectedBugs[i]);
            allBugs[collectedBugs[i]].SetActive(true);
        }
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
