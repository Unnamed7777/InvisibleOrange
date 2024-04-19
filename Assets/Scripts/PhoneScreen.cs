using System;
using DefaultNamespace.Menu.Apps;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class PhoneScreen
    {
        public GameObject screen;
        public GameManager.States state;
        public AppBase app;
    }
}