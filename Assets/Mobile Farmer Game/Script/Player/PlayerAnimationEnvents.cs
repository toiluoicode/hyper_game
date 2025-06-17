using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationEnvents : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ParticleSystem seedPartical;
    [SerializeField] private ParticleSystem waterPartical;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void PlayeSeedPartical()
    {
        seedPartical.Play();
    }
    private void PlayWaterPartical()
    {
        waterPartical.Play();
    }

}
