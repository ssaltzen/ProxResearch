using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;    

public class EmoteMenu : MonoBehaviour
{
    [SerializeField] 
    private Animator animator;

    // I (the guy who wrote the EmoteMenu script) didn't write the MouseLock one
    // I saw it and thought it would be useful to use, but it looks like this would suck with other ports.
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
    private Vector2 mousePosition;
    private List<float> iconDistances = new List<float>();

    private string currentEmote;
   

    // How far the icons spawn from the center
    [SerializeField]
    private const float Radius = 150;

    private void Start()
    {
        textObject.SetActive(false);
        mouseLock = FindObjectOfType<MouseLock>();
    }

    private void Update()
    {
        if (selectingEmote)
        {
            // This part might be terrible for the other ports sorry
            Vector2 rawMousePosition = Mouse.current.position.ReadValue();
            // Makes the center of the screen 0,0.
            mousePosition = new Vector2
            (
                rawMousePosition.x - Screen.width / 2f, 
                rawMousePosition.y - Screen.height / 2f
            );
            // For other ports, track the position of a cursor or the player's finger
            // With the center of the screen being 0,0

            iconDistances.Clear();
            foreach (var emote in emoteEntries)
            {
                float baseDistance = Vector2.Distance(mousePosition, emote.GetPosition()) / Radius;
                float targetScale = Mathf.Clamp(1 / (baseDistance), 0.5f, 1.2f);
                emote.SetScale(targetScale);
                iconDistances.Add(baseDistance);
            }
            currentEmote = emoteEntries[iconDistances.IndexOf(iconDistances.Min())].getEmoteName();
            textObject.GetComponent<TextMeshProUGUI>().text = currentEmote;
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Open();
            selectingEmote = true;
            textObject.SetActive(true);
            
            // For other ports, have a way for the player to stop being able to look around
            // and for a cursor to appear on the screen if not using touchscreen
            mouseLock.UpdateMouseState();
        } 
        else if (context.canceled)
        {
            Close();
            selectingEmote = false;
            textObject.SetActive(false);
            mouseLock.UpdateMouseState();
            animator.SetTrigger(currentEmote);
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
