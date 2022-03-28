using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailToggle : MonoBehaviour
{
    private TrailRenderer trail;
    private void Start()
    {
        trail = GetComponent<TrailRenderer>();
    }
    public void TrailOn()
    {
        trail.enabled = true;
    }
    public void TrailOff()
    {
        trail.enabled = false;
    }
    public void ChangeColor(int r,int g,int b)
    {
        trail.startColor = new Color32((byte) r, (byte) g, (byte) b,255);
        trail.endColor = new Color32((byte)r, (byte)g, (byte)b,255);
    }
}
