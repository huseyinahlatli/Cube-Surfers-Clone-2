using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public PlayerController player;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            player.finishCam = true;
            player.playerSpeed = 0f;
            AudioSource.PlayClipAtPoint(GameManager.gameManager.gameOverSound, player.transform.position);
            GameManager.gameManager.CurrentGameState = GameManager.GameState.GameOver;
        }
    }
}
