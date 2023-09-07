using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proxemics
{
    public class Player : MonoBehaviour
    {
        public event Action<Emote> PlayerEmoted;
        public virtual void PerformEmote(Emote emote)
        {
            PlayerEmoted?.Invoke(emote);
        }
    }
}

