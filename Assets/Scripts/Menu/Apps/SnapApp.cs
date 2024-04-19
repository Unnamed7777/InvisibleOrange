using System;
using UnityEngine;

namespace DefaultNamespace.Menu.Apps
{
    public class SnapApp : AppBase
    {
        public Transform snapScreen;
        
        public override void Enable()
        {
            snapScreen.position = new Vector3(0, 0);
        }

        private void Update()
        {
            snapScreen.position += new Vector3(0, Input.GetAxis("Mouse ScrollWheel"));
        }
    }
}