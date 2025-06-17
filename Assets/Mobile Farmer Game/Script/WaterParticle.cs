using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class WaterParticle : MonoBehaviour
{
    public static Action<Vector3[]> onWateredCollided;
    private void OnParticleCollision(GameObject other)
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> particleCollisionEvents = new List<ParticleCollisionEvent>();
        int collisionAmount = ps.GetCollisionEvents(other, particleCollisionEvents);
        Vector3[] collisionPosition = new Vector3[collisionAmount];
        for (int i = 0; i < collisionAmount; i++)
        {
            collisionPosition[i] = particleCollisionEvents[i].intersection;

        }
        onWateredCollided?.Invoke(collisionPosition);
    }
    
}
