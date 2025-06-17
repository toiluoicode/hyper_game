using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(playerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerWaterAbility : MonoBehaviour
{
    [Header("Setting")]
    private CropField currentCropField;
    private playerAnimator playerAnimator;
    private PlayerToolSelector playerToolSelector;
    void Start()
    {
        playerAnimator = GetComponent<playerAnimator>();
        playerToolSelector = GetComponent<PlayerToolSelector>();
        WaterParticle.onWateredCollided += WaterCollidedCallback;
        CropField.onFullyWaterd += CropFieldFullyWaterCallback;
        playerToolSelector.onToolSelected += ToolSelectedCallback;
    }
    private void OnDestroy()
    {
        CropField.onFullySow -= CropFieldFullyWaterCallback;
        WaterParticle.onWateredCollided -= WaterCollidedCallback;
        playerToolSelector.onToolSelected -= ToolSelectedCallback;
        CropField.onFullyWaterd -= CropFieldFullyWaterCallback;
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void ToolSelectedCallback(PlayerToolSelector.Tool selectedTool)
    {
        if (!playerToolSelector.CanWatered())
        {
            playerAnimator.StopWaterAnimation();
        }
    }
    public void CropFieldFullyWaterCallback(CropField cropField)
    {

        if (cropField == currentCropField)
        {
            playerAnimator.StopWaterAnimation();
        }
    }
    public void WaterCollidedCallback(Vector3[] waterPosition)
    {
        if (currentCropField == null)
        {
            return;
        }
        currentCropField.WaterCollidedCallback(waterPosition);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsSown())
        {
            currentCropField = other.GetComponent<CropField>();
            EnteredCropField(currentCropField);
        }
    }
    private void EnteredCropField(CropField cropField)
    {
        if (playerToolSelector.CanWatered())
        {
            if (currentCropField == null)
            {
                currentCropField = cropField;
            }
            playerAnimator.PlayerWaterAnimation();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsSown())
        {
            EnteredCropField(other.GetComponent<CropField>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            playerAnimator.StopWaterAnimation();
            currentCropField = null;

        }
    }



}
