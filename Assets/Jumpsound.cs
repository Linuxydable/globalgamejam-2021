using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpsound : MonoBehaviour
{
    FMOD.Studio.EventInstance PlayJump;
    // Start is called before the first frame update
    void Start()
    {
        PlayJump = FMODUnity.RuntimeManager.CreateInstance("event:/CHAR/CHAR_Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayJump.start();
        }
    }
}
