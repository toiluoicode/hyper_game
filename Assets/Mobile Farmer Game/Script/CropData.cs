using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CropData", menuName = "Scriptable Objects/Crop Data", order = 0)]
public class CropData : ScriptableObject
{
    [Header("Setting")]
    public Crop cropPreFab;
}
