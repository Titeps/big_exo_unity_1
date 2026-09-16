using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour
{

    [SerializeField] float force = 1f;
    public InputActionAsset actions;
    public float speed = 1f;
    private InputAction xAxis;
    private InputAction jump;

    bool isJumpig = false;
    

    void Awake()
    {
        transform.position = new Vector3(0,1,-100);
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        jump = actions.FindActionMap("CubeActionsMap").FindAction("Jump");
        isJumpig = false;
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
    }

    void Update()
    {   
        MoveX();
        // if (gameObject is on the ground) {}
        MoveY();
    }


    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        // bouge automatiquement
        transform.position += transform.forward * (speed / 2) * Time.deltaTime;

        // bouge selon input gauche/droite

            transform.position += speed  * Time.deltaTime * xMove * transform.right;            
    }
    private void MoveY()
    {
            float yMove = jump.ReadValue<float>();
            transform.position += force  * Time.deltaTime * yMove * transform.up;

    }
}
