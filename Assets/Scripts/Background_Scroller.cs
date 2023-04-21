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
        transform.position += new Vector3(-1 * Time.deltaTime, 0);

        if(transform.position.x < -17.31)
        {
            transform.position = new Vector3(17.31f, transform.position.y);
        }
    }
}
