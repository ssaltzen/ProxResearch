using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proxemics
{
    public class VirtualModel : MonoBehaviour
    {
        private Player player;
        private Animator animator;

        private Emote lastPlayerEmote;
        private float secondsSincePlayerEmote = 0;
        private float responseDelay = 1;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void Init(Player player)
        {
            this.player = player;
            player.PlayerEmoted += OnPlayerEmoted;
        }

        private void Update()
        {
            if (!lastPlayerEmote)
            {
                return;
            }

            secondsSincePlayerEmote += Time.deltaTime;
            if (secondsSincePlayerEmote >= responseDelay)
            {
                animator.SetTrigger(lastPlayerEmote.name);
                lastPlayerEmote = null;
            }
        }

        private void OnDisable()
        {
            if (player != null)
            {
                player.PlayerEmoted -= OnPlayerEmoted;
            }
        }

        private void OnPlayerEmoted(Emote playerEmote)
        {
            lastPlayerEmote = playerEmote;
            secondsSincePlayerEmote = 0;
            responseDelay = Random.Range(0.25f, 1f);
        }
    }

}
