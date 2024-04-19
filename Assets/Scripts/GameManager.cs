using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DefaultNamespace;
using DefaultNamespace.Menu.Apps;
using DefaultNamespace.Menu.Apps.UI;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera camera;
    public List<PhoneScreen> screens = new();
    public int swipeDeadZone;

    public DialogueScriptableObj textMessages;
    public GameObject textBubblePrefab;
    
    private States state;
    private Vector2 startSwipe;

    private float textBubblePosition = -1f;

    public enum States
    {
        HomeScreen,
        Snapchat,
        Instagram,
        Text
    }

    private void OnEnable()
    {
        foreach (var screen in this.screens)
        {
            if (screen.state == States.Text)
            {
                for (var i = this.textMessages.dialogueCollections.Length - 1; i >= 0; i--)
                {
                    var textBubble = Instantiate(this.textBubblePrefab, new Vector3(0.1f, 0.0f), quaternion.identity).GetComponent<TextBubble>();
                    this.textBubblePosition += textBubble.MakeTextBubble(this.textMessages.dialogueCollections[i].messages[0], this.textMessages.dialogueCollections[i].sender == Sender.Casey, this.textBubblePosition) * 2.0f;
                    this.textBubblePosition += 0.05f;

                    textBubble.transform.parent = screen.screen.transform.GetChild(2).GetChild(0);

                }
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = this.camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                if (this.state == States.HomeScreen)
                {
                    if (hit.collider.CompareTag("Snap"))
                    {
                        this.SetState(States.Snapchat);
                    }
                    else if (hit.collider.CompareTag("Insta"))
                    {
                        this.SetState(States.Instagram);
                    }
                    else if (hit.collider.CompareTag("Text"))
                    {
                        this.SetState(States.Text);
                    }
                }
            }

            if (this.state != States.HomeScreen)
            {
                this.startSwipe = Input.mousePosition;
                
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            var endSwipe = (Vector2) Input.mousePosition;
            var difference = endSwipe - this.startSwipe;
            if (difference.y > this.swipeDeadZone)
            {
                this.SetState(States.HomeScreen);
            }
        }
    }

    private void SetState(States newState)
    {
        this.state = newState;

        foreach (var screen in this.screens)
        {
            if (screen.state == newState)
            {
                screen.screen.SetActive(true);
                screen.app?.Enable();
            }
            else
            {
                screen.screen.SetActive(false);
                screen.app?.Disable();
            }
        }
    }
}
