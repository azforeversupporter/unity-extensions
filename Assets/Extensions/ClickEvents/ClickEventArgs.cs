using UnityEngine;

namespace UnityExtensions.ClickEvents
{
    public class ClickEventArgs
    {
        public ClickEventArgs(MouseButton mouseButton, ClickState clickState, Vector2 location, Collider2D collider = null)
        {
            this.mouseButton = mouseButton;
            this.clickState = clickState;
            this.location = location;
            this.collider = collider;
        }

        public MouseButton MouseButton
        {
            get { return mouseButton; }
        }

        public ClickState ClickState
        {
            get { return clickState; }
        }

        public Vector2 Location
        {
            get { return location; }
        }

        public Collider2D Collider
        {
            get { return collider; }
        }

        public bool HasCollider
        {
            get { return collider != null; }
        }

        private Collider2D collider;
        private Vector2 location;
        private MouseButton mouseButton;
        private ClickState clickState;
    }
}
