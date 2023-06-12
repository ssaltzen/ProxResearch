using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmoteEntry : MonoBehaviour
{
    [SerializeField] 
    private RawImage icon;
    private string emoteName;
    
    [SerializeField]
    private const float initialScale = 0.85f;

    public void Initialize(Texture pIcon, string emoteName)
    {
        icon.texture = pIcon;
        this.emoteName = emoteName;
        setScale(initialScale);
    }

    public string getEmoteName()
    {
        return emoteName;
    }

    public void setScale(float value)
    {
        gameObject.transform.localScale = new Vector3(value, value, value);
    }

    public Vector2 GetPosition()
    {
        return GetComponent<RectTransform>().anchoredPosition;
    }
    
}
