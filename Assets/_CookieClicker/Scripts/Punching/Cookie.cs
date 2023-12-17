using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : Punchable
{
    private ParticleSystem coockieParticles;

    public override void Start()
    {
        base.Start();
        coockieParticles = GetComponentInChildren<ParticleSystem>();
    }
    public override void punched() 
    {
        base.punched();
        coockieParticles.Play();
        GameManager.Instance.playerStats.cookieCount += GameManager.Instance.playerStats.punchStrenght;
    }
}
