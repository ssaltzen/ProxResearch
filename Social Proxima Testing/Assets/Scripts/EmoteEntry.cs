using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmoteEntry : MonoBehaviour
{
    [SerializeField] 
    private RawImage icon;
    private Emote emote;
    
    [SerializeField]
    private const float initialScale = 0.85f;

    public void Initialize(Emote emote)
    {
        this.emote = emote;
        icon.texture = emote.Icon;
        SetScale(initialScale);
    }

    public Emote GetEmote() => emote;

    public void SetScale(float value)
    {
        gameObject.transform.localScale = new Vector3(value, value, value);
    }

    public Vector2 GetPosition()
    {
        return GetComponent<RectTransform>().anchoredPosition;
    }
    
}
