using UnityEngine;

public class PathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LanyrinthMiniGame game = collision.GetComponentInParent<LanyrinthMiniGame>();

        if (game == null) return;

        if (CompareTag("Path"))
        {

        }
        else if (CompareTag("Start"))
        {
            game.started = true;
        }
        else if (CompareTag("Goal"))
        {
            if (game.started)
                game.completed = true;
        }
        else
        {
            game.failed = true;
        }
    }
}
