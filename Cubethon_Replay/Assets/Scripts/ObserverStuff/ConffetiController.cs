using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConffetiController : Observer
{
    [SerializeField]
    private GameObject Particles;

    public void Awake()
    {
        Particles.SetActive(false);
    }


    public override void Notify(Subject subject)
    {
        Particles.SetActive(true);
        Debug.Log("NOTIFIED");
    }

}
