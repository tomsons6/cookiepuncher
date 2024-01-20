using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookie : Punchable
{
    private ParticleSystem coockieParticles;
    CookieAnimation animation;
    public override void Start()
    {
        base.Start();
        coockieParticles = GetComponentInChildren<ParticleSystem>();
        animation = GetComponent<CookieAnimation>();
    }
    public override void punched() 
    {
        base.punched();
        coockieParticles.Play();
        StartCoroutine(animation.PunchAnimation());
        StartCoroutine(animation.PlusOneText());
        GameManager.Instance.playerStats.cookieCount += GameManager.Instance.playerStats.punchStrenght;
    }
}
