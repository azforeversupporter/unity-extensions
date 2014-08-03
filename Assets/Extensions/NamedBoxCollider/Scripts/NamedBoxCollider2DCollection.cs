using UnityEngine;
using System.Collections;
using UnityEditor;

namespace UnityExtensions.NamedBoxCollider
{
    public class NamedBoxCollider2DCollection : MonoBehaviour
    {
        public NamedBoxCollider2D[] NamedBoxColliders;

        #region MonoBehaviour
 
        private void Start()
        {
            InitializeNamedColliders();
        }

        private void OnDestroy()
        {
            DestroyNamedColliders();
        }

        private void OnApplicationQuit()
        {
            DestroyNamedColliders();
        }

#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            if (!enabled || Selection.activeGameObject != gameObject)
            {
                return;
            }

            var pos = transform.position;
            Gizmos.color = Color.blue;
            Handles.color = Color.blue;

            if (NamedBoxColliders != null)
            {
                foreach (var collider in NamedBoxColliders)
                {
                    if (collider.Enabled)
                    {
                        var center = new Vector2(pos.x + collider.Position.x, pos.y + collider.Position.y);
                        var topLeft = new Vector2(pos.x + collider.Position.x - collider.Size.x / 2f, pos.y + collider.Position.y + collider.Size.y / 2f);

                        // Draw wire cube for the collider
                        Gizmos.DrawWireCube(center, collider.Size);
                        Handles.Label(topLeft, collider.Name, style);
                    }
                }
            }
        }
#endif

        #endregion
        
        private void InitializeNamedColliders()
        {
            foreach (var collider in NamedBoxColliders)
            {
                collider.Initialize(gameObject);
            }
        }

        private void DestroyNamedColliders()
        {
            foreach (var collider in NamedBoxColliders)
            {
                collider.Destroy();
            }
        }

#if UNITY_EDITOR
        private GUIStyle style = new GUIStyle
        {
            normal = new GUIStyleState { textColor = Color.blue },
            clipping = TextClipping.Clip,
            fontSize = 10
        };
#endif
    }
}