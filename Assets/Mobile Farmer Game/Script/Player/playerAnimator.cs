using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem waterParticle;

    [Header("Setting")]
    [SerializeField] private float moveSpeedMultiplier;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ManageAnimations(Vector3 moveVector)
    {
        if (moveVector.magnitude > 0)
        {
            animator.SetFloat("moveSpeed", moveVector.magnitude * moveSpeedMultiplier);
            PlayRunAnimation();
            animator.transform.forward = moveVector.normalized;

        }
        else
        {
            PlayIdleAnimation();
        }
    }
    public void PlayRunAnimation()
    {
        animator.Play("Run");
    }
    public void PlayIdleAnimation()
    {
        animator.Play("Idle");
    }
    public void PlayThrowAniamtion()
    {
        animator.SetLayerWeight(1, 1);
    }
    public void StopThrowAnimation()
    {
        animator.SetLayerWeight(1, 0);
    }
    public void StopWaterAnimation()
    {
        animator.SetLayerWeight(2, 0);
        waterParticle.Stop();

    }
    public void PlayerWaterAnimation()
    {
        animator.SetLayerWeight(2, 1);

    }

}
