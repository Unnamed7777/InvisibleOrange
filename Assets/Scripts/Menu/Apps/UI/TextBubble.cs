using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace.Menu.Apps.UI
{
    public class TextBubble : MonoBehaviour
    {
        public TMP_Text text;
        public Transform bottomLeftCorner;
        public Transform topRightCorner;
        public Transform topLeftCorner;
        public Transform textBubble;
        public SpriteRenderer bubbleRenderer;
        
        public float MakeTextBubble(string input, bool isSender, float position)
        {
            this.text.text = input;
            this.text.ForceMeshUpdate();
            var size = this.text.GetRenderedValues(true);

            var textPos = this.transform.position;
            textPos.y = position;
            textPos.z = -1.0f;
            this.transform.position = textPos;
            
            this.textBubble.localScale = new Vector3(size.x + 0.1f, size.y + 0.1f, 1);
            this.textBubble.localPosition = this.text.textBounds.center;

            var pos = this.textBubble.localPosition;
            var scale = this.textBubble.localScale;
            
            this.topLeftCorner.localPosition =
                new Vector3(pos.x - scale.x / 2.0f,
                    pos.y + scale.y / 2.0f);
            this.topRightCorner.localPosition =
                new Vector3(pos.x + scale.x / 2.0f,
                    pos.y + scale.y / 2.0f);
            this.bottomLeftCorner.localPosition =
                new Vector3(pos.x - scale.x / 2.0f,
                    pos.y - scale.y / 2.0f);

            if (!isSender)
            {
                this.bubbleRenderer.color = Color.gray;
            }

            return scale.y;
        }
    }
}