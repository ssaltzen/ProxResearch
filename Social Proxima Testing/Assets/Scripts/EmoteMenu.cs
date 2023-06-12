using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EmoteMenu : MonoBehaviour
{
    [SerializeField] 
    private Animator animator;
    private MouseLock mouseLock;

    [SerializeField]
    private GameObject entryPrefab;

    [SerializeField]
    private GameObject textObject;

    [SerializeField] 
    private List<Texture> emoteIcons;
    private List<string> emoteNames = new List<string>
    {
        "Handshake", "Wave"
    };

    private List<EmoteEntry> emoteEntries = new List<EmoteEntry>();

    private bool selectingEmote = false;

    private string currentEmote;

    [SerializeField]
    private const float Radius = 100;

    private void Start()
    {
        textObject.SetActive(false);
        mouseLock = FindObjectOfType<MouseLock>();
    }

    private void Update()
    {
        if (selectingEmote)
        {
            Debug.Log("ok");
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Open();
            selectingEmote = true;
            textObject.SetActive(true);
            mouseLock.UpdateMouseState();
        } 
        else if (context.canceled)
        {
            Close();
            selectingEmote = false;
            Vector2 mp = Mouse.current.position.ReadValue();
            Debug.Log(new Vector2(mp.x - Screen.width / 2f, mp.y - Screen.height / 2f));
            textObject.SetActive(false);
            mouseLock.UpdateMouseState();
        }
    }

    private void CreateEntry(Texture icon, string emoteName)
    {
        GameObject entry = Instantiate(entryPrefab, transform);
        entry.transform.SetParent(transform, false);

        EmoteEntry entryScript = entry.GetComponent<EmoteEntry>();
        entryScript.Initialize(icon, emoteName);

        emoteEntries.Add(entryScript);
    }

    private void Open()
    {
        for (int i = 0; i < emoteNames.Count; i++)
        {
            CreateEntry(emoteIcons[i], emoteNames[i]);
        }
        Rearrange();
    }

    private void Rearrange()
    {
        float spacingAngle = Mathf.PI * 2 / emoteEntries.Count;
        for (int i = 0; i < emoteEntries.Count; i++)
        {
            float x = Mathf.Sin(spacingAngle * i) * Radius;
            float y = Mathf.Cos(spacingAngle * i) * Radius;

            emoteEntries[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
        }
    }

    private void Close()
    {
        foreach (var entry in emoteEntries)
        {
            Destroy(entry.gameObject);
        }
        emoteEntries.Clear();
    }

}
