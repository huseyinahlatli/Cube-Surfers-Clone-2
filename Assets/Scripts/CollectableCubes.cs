using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectableCubes : MonoBehaviour
{
    private bool _isTriggered;

    private void OnTriggerEnter(Collider other)
    {
        CollectCube collectCube = other.GetComponentInParent<CollectCube>();
        if (collectCube && !_isTriggered)
        {
            _isTriggered = true;
            AudioSource.PlayClipAtPoint(GameManager.gameManager.jumpSound, GameManager.gameManager.player.transform.position);
            GameManager.gameManager.player.CollectCube();
            Destroy(gameObject);
        }
    }
}
