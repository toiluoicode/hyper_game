using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerToolSelector : MonoBehaviour
{
    [Header("Setting")]

    [SerializeField] private Image[] listImageSelection;
    [SerializeField] private Color selectedColor;
    public enum Tool { None, Sow, Watered, Harvest }
    private Tool activeTool;
    [Header("Action")]
    public Action<Tool> onToolSelected;
    void Start()
    {
        SelecTool(0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SelecTool(int Toolindex)
    {
        activeTool = (Tool)Toolindex;
        for (int i = 0; i < listImageSelection.Length; i++)
        {
            listImageSelection[i].color = i == Toolindex ? selectedColor : Color.white;
        }
        onToolSelected?.Invoke(activeTool);
    }
    public bool CanSow()
    {

        return activeTool == Tool.Sow;
    }
    public bool CanWatered()
    {
        return activeTool == Tool.Watered;
    }
    public bool CanHarvest()
    {
        return activeTool == Tool.Harvest;
    }
}
