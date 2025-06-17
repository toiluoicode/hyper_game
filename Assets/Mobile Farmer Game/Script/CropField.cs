using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System;

public class CropField : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private Transform tilesParent;
    private List<CropTile> cropTiles = new List<CropTile>();
    private int tileSows;
    private int tileWater;
    [Header("Setting")]
    [SerializeField] private CropData cropData;
    private TileFieldState state;
    [Header("Action")]
    public static Action<CropField> onFullySow;
    public static Action<CropField> onFullyWaterd;
    public static Action<CropField> onFullyHarvest;
    void Start()
    {
        state = TileFieldState.Empty;
        StoreTiles();
    }


    void Update()
    {

    }
    private void StoreTiles()
    {
        for (int i = 0; i < tilesParent.childCount; i++)
        {
            cropTiles.Add(tilesParent.GetChild(i).GetComponent<CropTile>());
        }

    }
    public void SeedCollidedCallback(Vector3[] seedPositons)
    {
        for (int i = 0; i < seedPositons.Length; i++)
        {
            CropTile ClosetCropTile = GetClosetCropTile(seedPositons[i]);
            if (ClosetCropTile == null)
            {
                continue;
            }
            if (!ClosetCropTile.IsEmpty())
            {
                continue;
            }
            Sow(ClosetCropTile);

        }
    }
    public void WaterCollidedCallback(Vector3[] waterPosition)
    {
        for (int i = 0; i < waterPosition.Length; i++)
        {
            CropTile ClosetCropTile = GetClosetCropTile(waterPosition[i]);
            if (ClosetCropTile == null)
            {
                continue;
            }
            if (!ClosetCropTile.IsSown())
            {
                continue;
            }
            Water(ClosetCropTile);
        }
    }
    private void Water(CropTile closetCropField)
    {
        closetCropField.Water();
        tileWater++;
        if (tileWater == cropTiles.Count)
        {
            FieldFullyWater();
        }

    }
    public void Sow(CropTile cropTile)
    {

        cropTile.Sow(cropData);
        tileSows++;
        if (tileSows == cropTiles.Count)
        {
            FieldFullySow();
        }
    }
    public void FieldFullySow()
    {
        state = TileFieldState.Sown;
        onFullySow?.Invoke(this);
    }
    [NaughtyAttributes.Button]
    public void QuicklySow()
    {
        for (int i = 0; i < cropTiles.Count; i++)
        {
            Sow(cropTiles[i]);
        }
    }
    [NaughtyAttributes.Button]
    public void QuicklyWater()
    {
        for (int i = 0; i < cropTiles.Count; i++)
        {
            Water(cropTiles[i]);
        }
    }
    public void FieldFullyWater()
    {
        Debug.Log("Full water ");
        state = TileFieldState.Watered;
        onFullyWaterd?.Invoke(this);
    }
    private CropTile GetClosetCropTile(Vector3 seedPosition)
    {
        float min = Mathf.Infinity;
        int ClosetCropTileIndex = -1;

        for (int i = 0; i < cropTiles.Count; i++)
        {
            CropTile cropTile = cropTiles[i];
            float distainTileCrop = Vector3.Distance(cropTile.transform.position, seedPosition);
            if (min > distainTileCrop)
            {
                min = distainTileCrop;
                ClosetCropTileIndex = i;
            }
        }
        if (ClosetCropTileIndex == -1)
        {
            return null;
        }
        return cropTiles[ClosetCropTileIndex];
    }
    public bool IsEmpty()
    {
        return state == TileFieldState.Empty;

    }
    public bool IsSown()
    {
        return state == TileFieldState.Sown;
    }
    public bool IsWater()
    {
        return state == TileFieldState.Watered;
    }



}
