using System;
using UnityEngine;

namespace UnityExtensions.ClickEvents
{
    public class ClickEventBehaviour : MonoBehaviour
    {
        public static event Action<ClickEventArgs> OnClick;

        #region MonoBehaviour
        private void Update()
        {
            CheckForClick();
        }
        #endregion

        private void CheckForClick()
        {
            var isButtonClicked = false;
            var button = MouseButton.Unknown;
            var state = ClickState.Idle;

            if (Input.GetMouseButtonDown(0))
            {
                state = ClickState.Down;
                button = MouseButton.Left;
                isButtonClicked = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                state = ClickState.Up;
                button = MouseButton.Left;
                isButtonClicked = true;
            }

            if (Input.GetMouseButtonDown(1))
            {
                state = ClickState.Down;
                button = MouseButton.Right;
                isButtonClicked = true;
            }

            if (Input.GetMouseButtonUp(1))
            {
                state = ClickState.Up;
                button = MouseButton.Right;
                isButtonClicked = true;
            }

            if (Input.GetMouseButtonDown(2))
            {
                state = ClickState.Down;
                button = MouseButton.Middle;
                isButtonClicked = true;
            }

            if (Input.GetMouseButtonUp(2))
            {
                state = ClickState.Up;
                button = MouseButton.Middle;
                isButtonClicked = true;
            }

            if (isButtonClicked && OnClick != null)
            {
                var clickedCollider = GetClickedCollider();
                var location = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);

                var clickArgs = new ClickEventArgs(button, state, location, clickedCollider);                
                OnClick(clickArgs);
            }
        }

        private Collider2D GetClickedCollider()
        {
            var worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var origin = new Vector2(worldPosition.x, worldPosition.y);
            var hit = Physics2D.Raycast(origin, Vector2.zero, Mathf.Infinity);

#if UNITY_EDITOR
            Debug.DrawRay(Vector2.zero, origin, Color.blue);
#endif

            return hit.collider;
        }
    }
}
