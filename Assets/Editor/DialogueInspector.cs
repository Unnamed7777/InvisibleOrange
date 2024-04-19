using System;
using Codice.Client.BaseCommands;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    //[CustomEditor(typeof(DialogueScriptableObj))]
    public class DialogueInspector : UnityEditor.Editor
    {
        
        SerializedProperty dialogueCollections;
        SerializedProperty instagramCollections;
        SerializedProperty photosCollections;

        private void OnEnable()
        {
            dialogueCollections = serializedObject.FindProperty("dialogueCollections");
            instagramCollections = serializedObject.FindProperty("instagramCollections");
            photosCollections = serializedObject.FindProperty("photosCollections");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var dialogue = (DialogueScriptableObj) target;

            switch (dialogue.type)
            {
                // Check if showArray is true
                case DialogueScriptableObj.CollectionType.Messages:
                    EditorGUILayout.PropertyField(dialogueCollections, true);
                    break;
                case DialogueScriptableObj.CollectionType.Instagram:
                    EditorGUILayout.PropertyField(instagramCollections, true);
                    break;
                case DialogueScriptableObj.CollectionType.Photos:
                    EditorGUILayout.PropertyField(photosCollections, true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            // Apply changes to the serialized object
            serializedObject.ApplyModifiedProperties();
        }
    }
}
