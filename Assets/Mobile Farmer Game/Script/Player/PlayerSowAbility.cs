using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(playerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerSowAbility : MonoBehaviour
{
    [Header("Setting")]
    private CropField currentCropField;
    private playerAnimator playerAnimator;
    private PlayerToolSelector playerToolSelector;
    void Start()
    {
        playerAnimator = GetComponent<playerAnimator>();
        playerToolSelector = GetComponent<PlayerToolSelector>();
        CropField.onFullySow += CropFieldFullySowCallback;
        SeedPartical.onSeedsCollided += SeedCollidedCallback;
        playerToolSelector.onToolSelected += ToolSelectedCallback;
    }
    private void OnDestroy()
    {
        CropField.onFullySow -= CropFieldFullySowCallback;
        SeedPartical.onSeedsCollided -= SeedCollidedCallback;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void ToolSelectedCallback(PlayerToolSelector.Tool selectedTool)
    {
        if (!playerToolSelector.CanSow())
        {
            playerAnimator.StopThrowAnimation();
        }
    }
    public void CropFieldFullySowCallback(CropField cropField)
    {
        if (cropField == currentCropField)
        {
            playerAnimator.StopThrowAnimation();
        }
    }
    public void SeedCollidedCallback(Vector3[] seedPositions)
    {
        if (currentCropField == null)
        {
            return;
        }
        currentCropField.SeedCollidedCallback(seedPositions);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty())
        {
            currentCropField = other.GetComponent<CropField>();
            EnteredCropField(currentCropField);
        }
    }
    private void EnteredCropField(CropField cropField)
    {
        if (playerToolSelector.CanSow())
        {
            playerAnimator.PlayThrowAniamtion();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsEmpty())
        {
            EnteredCropField(other.GetComponent<CropField>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            playerAnimator.StopThrowAnimation();
            currentCropField = null;

        }
    }


}
