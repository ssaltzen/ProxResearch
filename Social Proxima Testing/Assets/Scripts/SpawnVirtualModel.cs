using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Proxemics
{
    public class SpawnVirtualModel : MonoBehaviour
    {
        [SerializeField] private List<VirtualModel> virtualModels = new List<VirtualModel>();
        [SerializeField] private PlayerController player;
        [SerializeField] private GameObject playerHead;


        void Start()
        {
            int modelIndex = VirtualModelLoader.modelType;

            VirtualModel model = Instantiate(virtualModels[modelIndex]);
            model.transform.position = transform.position;

            model.Init(player);
            model.GetComponent<FaceTracking>().SetObjectTracking(playerHead.transform);

        }

    }
}

