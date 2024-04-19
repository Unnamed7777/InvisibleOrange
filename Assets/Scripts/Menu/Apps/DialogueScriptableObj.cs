using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Menu.Apps;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Obj", menuName = "Invisible Orange/Dialogue Obj")]
public class DialogueScriptableObj : ScriptableObject
{
    public CollectionType type;
    public DialogueCollection[] dialogueCollections;
    public InstagramCollection[] instagramCollections;
    public PhotosCollection[] photosCollections;

    public enum CollectionType
    {
        Messages,
        Instagram,
        Photos
    }
}
