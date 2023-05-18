using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpecs
{
    private float length;
    private float width;
    private float height;

    public float GetLength()
    {
        return length;
    }

    public void SetLength(float length)
    {
        this.length = length;
    }

    public float GetWidth()
    {
        return width;
    }

    public void SetWidth(float width)
    {
        this.width = width;
    }

    public float GetHeight()
    {
        return height;
    }

    public void SetHeight(float height)
    {
        this.height = height;
    }
}

