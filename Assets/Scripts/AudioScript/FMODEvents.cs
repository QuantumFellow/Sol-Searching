using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference PlayerFootsteps { get; private set; }

    [field: Header("Collection SFX")]
    [field: SerializeField] public EventReference CollectionSound { get; private set; }

    [field: Header("Character Talk SFX")]
    [field: SerializeField] public EventReference WellInteract { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than One FMOD Event in scene");
        }
        instance = this;
    }
}
