using UnityEngine;

public class BugInteract : MonoBehaviour
{
    public string bugTag;
    public BugSpriteSelector bugSpriteSelector;
    public PointAndClickGame pointAndClickGame;

    public void PrepareBugMiniGame()
    {
        bugSpriteSelector.SetBug(bugTag);
        //pointAndClickGame.SetBugTag(bugTag);
    }
}
