using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using System;
using System.Linq.Expressions;
using Unity.VisualScripting;
[RequireComponent(typeof(Rigidbody))]

public class PlayerControl : MonoBehaviour
{
    const string ACTION_MAP = "CubeActionsMap";
    const string X_AXIS_ACTION = "XAxis";
    const string JUMP_ACTION = "Jump";
    private const float CHECK_GROUND_LENGTH = 0.55f;

    [Tooltip ("Force de saut en newton")]
    [SerializeField] float force = 350f;
    public float speed = 1f;
    [SerializeField]private InputActionAsset actions;
    private InputAction xAxis;
    private InputAction jump;   
    Vector3 startpos; 

    void Awake()
    {
        startpos = new Vector3(0,1,-100);
        Respawn();
        xAxis = actions.FindActionMap(ACTION_MAP).FindAction(X_AXIS_ACTION);
        jump = actions.FindActionMap(ACTION_MAP).FindAction(JUMP_ACTION);
        jump.performed += ctx => { OnJump(ctx); };
    }


    void OnEnable()
    {
        actions.FindActionMap(ACTION_MAP).Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap(ACTION_MAP).Disable();
    }

    void Update()
    {   
        MoveX(); 
        Autoforward();
        // if (gameObject is on the ground) {}
    }


    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        // bouge selon input gauche/droite
        transform.position += speed * Time.deltaTime * xMove * transform.right;
    }

    private void Autoforward()
    {
        // avance automatiquement
        transform.position += speed  * Time.deltaTime * transform.forward;
    }


    private void OnJump(InputAction.CallbackContext ctx)
    {
        if (isGrounded())
        {
            GetComponent<Rigidbody>().AddForce( force * Vector3.up);    
        }
    }

    private bool isGrounded()
    {
        Ray ray = new(transform.position,Vector3.down);
            return Physics.Raycast(ray,CHECK_GROUND_LENGTH * transform.localScale.y);
    }

    public void Respawn()
    {
        transform.position = startpos;
    }

    public void Stop()
    {
        speed = 0;
    }
}
