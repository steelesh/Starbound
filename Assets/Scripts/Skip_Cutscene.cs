using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Skip_Cutscene : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public List<double> targetFramesInSeconds;
    private int skipCount;

    void Start()
    {
        skipCount = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            SkipToFrame();
        }
    }

    public void SkipToFrame()
    {
        if (skipCount < targetFramesInSeconds.Count)
        {
            playableDirector.time = targetFramesInSeconds[skipCount];
            playableDirector.Evaluate();
            skipCount++;
        }
    }
}
