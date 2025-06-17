using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCropInteractor : MonoBehaviour
{
    [SerializeField] private Material[] materials;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].SetVector("_Player_Position", transform.position);
        }
    }
}
