using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TerrariumScreen : MonoBehaviour
{

    [SerializeField] private Button LeaveTerrariumButton;

    private List<string> collectedBugs;

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

        for (int i = 0; i < collectedBugs.Count; i++)
        {
            print("gesammelter Käfer:" + collectedBugs[i]);
            GameObject.FindWithTag(collectedBugs[i]).SetActive(true);
        }
    }
}
