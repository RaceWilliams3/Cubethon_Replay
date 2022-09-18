using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelController : MonoBehaviour
{
    public GameObject player;

    void start()
    {
        //_invoker = FindObjectOfType<Invoker>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<InputHandler>().getReplaying() == true)
        {
            this.GetComponent<TMPro.TextMeshProUGUI>().enabled = true;
        } else
        {
            this.GetComponent<TMPro.TextMeshProUGUI>().enabled = false;
        }
    }
}
