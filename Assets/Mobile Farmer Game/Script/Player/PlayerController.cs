using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(playerAnimator))]
public class PlayerController : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private MobileJoystick joystick;
    private playerAnimator playerAnimator;
    private CharacterController characterController;

    [Header("Seting")]
    [SerializeField] private float moveSpeed;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimator = GetComponent<playerAnimator>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageMoveMent();
    }
    public void ManageMoveMent()
    {
        Vector3 moveVector = joystick.GetMoveVector() * Time.deltaTime / Screen.width * moveSpeed;
        moveVector.z = moveVector.y;
        moveVector.y = 0;
        characterController.Move(moveVector);
        playerAnimator.ManageAnimations(moveVector);

    }

}
