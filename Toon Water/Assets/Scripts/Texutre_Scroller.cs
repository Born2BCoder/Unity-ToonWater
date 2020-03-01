using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texutre_Scroller : MonoBehaviour
{

    private Material mr;

    public float ScrollingSpeed = 0;
    private Vector2 ScrollVector = new Vector2(0, 0);

    public bool Scroll_X;
    public bool Scroll_Y;
    
    void Start()
    {
        mr = GetComponent<Renderer>().material;
    }

    
    void Update()
    {
        float offset = Time.time * ScrollingSpeed;

        if (Scroll_X) { ScrollVector.x = offset; }
        if (Scroll_Y) { ScrollVector.y = offset; }

        if(Scroll_X || Scroll_Y)
        {
            mr.mainTextureOffset = ScrollVector;
        }
    }
}
