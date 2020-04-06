using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver //Serialization is when you load or unload objects from memory.
{
    public float initialValue;

    [HideInInspector]
    public float RuntimeValue;

    public void OnAfterDeserialize() {
        RuntimeValue = initialValue;
    } //After you unload everything from the game

    public void OnBeforeSerialize() { } //Load not for scene, but for entire game
}
