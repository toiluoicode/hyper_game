using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimationEnvents : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private ParticleSystem seedPartical;
    [SerializeField] private ParticleSystem waterPartical;

    [Header("Events")]
    [SerializeField] private UnityEvent startHarvestingEnvent;
    [SerializeField] private UnityEvent stoptHarvestingEnvent;

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
    private void StartHarvestingCallback()
    {
        startHarvestingEnvent?.Invoke();
    }
    private void StopHarvestingCallback()
    {
        stoptHarvestingEnvent?.Invoke();
    }

}
