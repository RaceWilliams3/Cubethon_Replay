using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConffetiController : Observer
{
    [SerializeField]
    private GameObject Part_purp;
    [SerializeField]
    private GameObject Part_blue;
    [SerializeField]
    private GameObject Part_red;

    public int trigger_offset;

    private float levelLength;
    private float first_third_end;
    private float second_third_end;

    private GameObject useableConffeti;

    public void Awake()
    {
        Part_purp.SetActive(false);
        Part_blue.SetActive(false);
        Part_red.SetActive(false);
    }

    public void Start()
    {
        levelLength = FindObjectOfType<EndTrigger>().GetComponent<Transform>().position.z;

        first_third_end = levelLength * 0.33f;
        second_third_end = levelLength * 0.66f;

        if(GetComponent<Transform>().position.z < first_third_end)
        {
            useableConffeti = Part_purp;
        }
        else if (GetComponent<Transform>().position.z < second_third_end)
        {
            useableConffeti = Part_blue;
        } else
        {
            useableConffeti = Part_red;
        }
    }


    public override void Notify(Subject subject)
    {
        float playerPos = subject.GetComponent<Transform>().position.z;
        float triggerPos = GetComponent<Transform>().position.z - trigger_offset;

        if (playerPos > triggerPos)
        {
            useableConffeti.SetActive(true);

        } 
    }

}
