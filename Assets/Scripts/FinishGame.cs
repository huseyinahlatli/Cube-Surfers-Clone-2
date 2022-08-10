using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponentInParent<PlayerController>();
        if (player)
        {
            player.finishCam = true;
            player.playerSpeed = 0f;
            AudioSource.PlayClipAtPoint(GameManager.gameManager.winSound, GameManager.gameManager.player.transform.position,0.5f);
            GameManager.gameManager.winGoldText.text = GameManager.gameManager.goldText.text;
            GameManager.gameManager.CurrentGameState = GameManager.GameState.FinishGame;
        }
    }
}
