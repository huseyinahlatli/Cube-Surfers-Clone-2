using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header ("My Variables")]
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float horizontalLimit;
    [SerializeField] public float playerSpeed;
    private float _movement;
    private int _gateNumber;
    private int _targetCount;
    
    [Header ("Public Variables")]
    public Transform upwards;
    public Transform cubeSpawner;
    public Transform cubeRoot;
    public Transform playerModelRoot;
    public GameObject spawnedCube;
    [HideInInspector] public bool finishCam;

    private void FixedUpdate()
    {
        ForwardMove();
    }

    private void Update()
    {
        RightLeftMove();
    }
    
    #region Player Movement

    private void RightLeftMove()
    {
        if(Input.GetMouseButton(0))
            _movement = Input.GetAxisRaw("Mouse X");
        else
            _movement = 0;

        var position = transform.position;
        var newMovement = position.x + _movement * horizontalSpeed * Time.fixedDeltaTime;
        newMovement = Mathf.Clamp(newMovement, -horizontalLimit, horizontalLimit);
        
        position = new Vector3(newMovement, position.y, position.z);
        transform.position = position;
    }
    
    private void ForwardMove()
    {
        transform.Translate(Vector3.forward * (playerSpeed * Time.deltaTime));
    }
    
    #endregion
    
    public void CollectCube()
    {
        Vector3 upwardsPosition = upwards.localPosition;
        upwardsPosition += new Vector3(0, 1.5f, 0);
        upwards.localPosition = upwardsPosition;
        Instantiate(spawnedCube, cubeSpawner.position, transform.rotation, cubeRoot);
    }
}
