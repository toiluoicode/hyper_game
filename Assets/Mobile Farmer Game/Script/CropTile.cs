using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TileFieldState { Empty, Sown, Watered }
public class CropTile : MonoBehaviour
{

    public TileFieldState state;
    [Header("element ")]
    [SerializeField] private Transform cropParent;
    [SerializeField] private MeshRenderer tileMeshRendered;
    private Crop crop;
    void Start()
    {
        state = TileFieldState.Empty;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool IsEmpty()
    {
        return state == TileFieldState.Empty;

    }
    public void Sow(CropData cropData)
    {
        state = TileFieldState.Sown;
        crop = Instantiate(cropData.cropPreFab, transform.position, Quaternion.identity, cropParent);
    }
    public bool IsSown()
    {
        return state == TileFieldState.Sown;
    }
    public void Water()
    {
        state = TileFieldState.Watered;
        // tileMeshRendered.material.color = Color.white * 0.3f;
        crop.ScaleUp();
        tileMeshRendered.gameObject.LeanColor(Color.white * .3f, 1).setEase(LeanTweenType.easeInOutCirc); ;

    }
    // IEnumerator ColorTileCoroutine()
    // {
    //     float duration = 1f;
    //     float timer = 0;
    //     while (timer < duration)
    //     {
    //         float t = timer / duration;
    //         Color lerperColer = Color.Lerp(Color.white, Color.white * .3f, t);
    //         tileMeshRendered.material.color = lerperColer;
    //         timer += Time.deltaTime;
    //         yield return null;
    //     }
    //     yield return null;
    // }


}
