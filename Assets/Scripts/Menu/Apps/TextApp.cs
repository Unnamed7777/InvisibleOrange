using System;
using UnityEngine;

namespace DefaultNamespace.Menu.Apps
{
    public class TextApp : AppBase
    {
        public Transform textScreen;

        public override void Enable()
        {
            textScreen.position = new Vector3(0, 0);
        }

        private void Update()
        {
            textScreen.position += new Vector3(0, Input.GetAxis("Mouse ScrollWheel"));
        }
    }
}
