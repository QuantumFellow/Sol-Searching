using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference PlayerFootsteps { get; private set; }
    [field: SerializeField] public EventReference JumpSFX { get; private set; }
    [field: SerializeField] public EventReference BowUp { get; private set; }
    [field: SerializeField] public EventReference BowDown { get; private set; }
    [field: SerializeField] public EventReference Violin { get; private set; }

    [field: Header("NPC SFX")]
    [field: SerializeField] public EventReference SilenceHurt { get; private set; }

    [field: Header("Collection SFX")]
    [field: SerializeField] public EventReference CollectionSound { get; private set; }
    [field: SerializeField] public EventReference KeyPickUp { get; private set; }

    [field: Header("Character Talk SFX")]
    [field: SerializeField] public EventReference WellInteract { get; private set; }
    [field: SerializeField] public EventReference SilenceInteract { get; private set; }
    [field: SerializeField] public EventReference SignInteract { get; private set; }

    [field: Header("Ambience")]
    [field: SerializeField] public EventReference Weather { get; private set; }

    [field: Header("Interactables")]

    [field: SerializeField] public EventReference Ink_UP { get; private set; }
    [field: SerializeField] public EventReference TuningForkUp { get; private set; }
    [field: SerializeField] public EventReference Dial { get; private set; }
    [field: SerializeField] public EventReference Lever { get; private set; }
    [field: SerializeField] public EventReference BridgeRaise { get; private set; }
    [field: SerializeField] public EventReference ShaftOpen { get; private set; }
    [field: SerializeField] public EventReference PipeHit { get; private set; }
    [field: SerializeField] public EventReference Paper { get; private set; }
    [field: SerializeField] public EventReference Door { get; private set; }

    [field: Header("Puzzles")]
    [field: SerializeField] public EventReference c3 { get; private set; }
    [field: SerializeField] public EventReference d3 { get; private set; }
    [field: SerializeField] public EventReference e3 { get; private set; }
    [field: SerializeField] public EventReference f3 { get; private set; }
    [field: SerializeField] public EventReference g3 { get; private set; }
    [field: SerializeField] public EventReference a3 { get; private set; }
    [field: SerializeField] public EventReference b3 { get; private set; }
    [field: SerializeField] public EventReference c4 { get; private set; }



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
