using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Scroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-0.5f * Time.deltaTime, 0);

        if(transform.position.x < -23.12f)
        {
            transform.position = new Vector3(23.12f, transform.position.y);
        }
    }
}
