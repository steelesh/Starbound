using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class Change_Scene : MonoBehaviour
{
    public string sceneName;
    public PlayableDirector playableDirector;

    private void Update()
    {
        if (playableDirector.state != PlayState.Playing)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
