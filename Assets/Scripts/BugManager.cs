using System.Collections.Generic;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public static BugManager instance; //singelton getter

    public GameObject[] bugIcons;



    private HashSet<string> caughtBugs = new HashSet<string>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

            LoadCaughtBugs();
        UpdateTerrarium();
    }
    
    public void OnBugCaught(string bugTag)
    {
        if (caughtBugs.Contains(bugTag))
        {
            Debug.Log("Bug already collected: " + bugTag);
            return;
        }

        caughtBugs.Add(bugTag);
        Debug.Log("New bug collected: " + bugTag);

        SaveCaughtBugs();
        ShowBugsInTerrarium(bugTag);
    }

    private void ShowBugsInTerrarium(string bugTag)
    {
        foreach(GameObject icon in bugIcons)
        {
            if(icon.CompareTag(bugTag))
            {
                icon.SetActive(true);
                return;
            }
        }
    }

    private void UpdateTerrarium()
    {
        foreach(GameObject icon in bugIcons)
        {
            if (caughtBugs.Contains(icon.tag))
                icon.SetActive(true);
            else
                icon.SetActive(false);
        }
    }

    private void SaveCaughtBugs()
    {
        foreach(string bug in caughtBugs)
            PlayerPrefs.SetInt("Bug_" + bug, 1);

        PlayerPrefs.Save();
    }

    private void LoadCaughtBugs()
    {
        caughtBugs.Clear();
        foreach(GameObject icon in bugIcons)
        {
            string tag = icon.tag;
            if(PlayerPrefs.GetInt("Bug_" + tag, 0) == 1)
                caughtBugs.Add(tag);
        }
    }

}
