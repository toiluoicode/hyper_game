using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Crop : MonoBehaviour
{
    [Header("element")]
    [SerializeField] private Transform cropRenderer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ScaleUp()
    {
        // StartCoroutine("ScaleUpCoroutine");
        cropRenderer.gameObject.LeanScale(Vector3.one, 20);
    }
    // IEnumerator ScaleUpCoroutine()
    // {
    //     float duration = 2f;
    //     float timer = 0;
    //     Vector3 start = cropRenderer.transform.localScale;
    //     while (timer < duration)
    //     {
    //         float t = timer / duration;
    //         cropRenderer.transform.localScale = Vector3.Lerp(start, Vector3.one, t);
    //         timer += Time.deltaTime;
    //         yield return null;
    //     }

    //     yield return null;
    // }
}
