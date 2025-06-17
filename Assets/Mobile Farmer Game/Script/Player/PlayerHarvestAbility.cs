using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(playerAnimator))]
[RequireComponent(typeof(PlayerToolSelector))]
public class PlayerHarvestAbility : MonoBehaviour
{
    private CropField currentCropField;
    private playerAnimator playerAnimator;
    private PlayerToolSelector playerToolSelector;
    void Start()
    {
        playerAnimator = GetComponent<playerAnimator>();
        playerToolSelector = GetComponent<PlayerToolSelector>();
        CropField.onFullyHarvest += CropFieldFullyHarvestCallback;
        playerToolSelector.onToolSelected += ToolSelectorCallback;
    }

    // Update is called once per frame
    void Update()
    {
        CropField.onFullyHarvest -= CropFieldFullyHarvestCallback;
        playerToolSelector.onToolSelected -= ToolSelectorCallback;
    }
    void OnDestroy()
    {

    }
    private void ToolSelectorCallback(PlayerToolSelector.Tool selectedTool)
    {
        if (!playerToolSelector.CanHarvest())
        {
            playerAnimator.StopHarvestAnimation();
        }
    }
    private void CropFieldFullyHarvestCallback(CropField cropField)
    {
        if (cropField == currentCropField)
        {
            playerAnimator.StopHarvestAnimation();
        }
    }
    private void EnteredCropField(CropField cropField)
    {
        if (playerToolSelector.CanSow())
        {
            playerAnimator.PlayHarvestAnimtion();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsWater())
        {
            EnteredCropField(other.GetComponent<CropField>());
        }
    }
    private void OTriggerStay(Collider other)
    {
        if (other.CompareTag("CropField") && other.GetComponent<CropField>().IsWater())
        {
            EnteredCropField(other.GetComponent<CropField>());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("CropField"))
        {
            playerAnimator.StopHarvestAnimation();
        }
    }
}

