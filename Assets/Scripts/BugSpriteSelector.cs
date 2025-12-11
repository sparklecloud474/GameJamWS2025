using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BugSpriteSelector : MonoBehaviour
{
    public Image targetImage;

    //Bug sprites
    public Sprite YellowBugSprite;
    public Sprite GreenBugSprite;
    public Sprite BrownMothSprite;
    public Sprite BlueButterflySprite;
    public Sprite StickBugSprite;
    public Sprite RoachSprite;
    public Sprite OrangeButterflySprite;
    public Sprite BlueDragonflySprite;
    public Sprite RedDragonflySprite;

    private string currentBugTag;

    public void SetBug(string bugTag)
    {
        currentBugTag = bugTag;
        Sprite sprite = GetSpriteForBug(bugTag);
        if (sprite != null)
        {
            targetImage.sprite = sprite;
        }
        else
        {
            Debug.Log("No sprite assigned for bugTag: " + bugTag);
        }
    }

    private Sprite GetSpriteForBug(string tag)
    {
        switch(tag)
        {
            case "YellowBug": return YellowBugSprite;
            case "GreenBug": return GreenBugSprite;
            case "BrownMoth": return BrownMothSprite;
            case "BlueButterfly": return BlueButterflySprite;
            case "StickBug": return StickBugSprite;
            case "Roach": return RoachSprite;
            case "OrangeButterfly": return OrangeButterflySprite;
            case "BlueDragonfly": return BlueDragonflySprite;
            case "RedDragonfly": return RedDragonflySprite;

            default: return null;
        }
    }

    public string GetCurrentBugTag()
    {
        return currentBugTag;
    }
}
