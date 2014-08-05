using UnityEngine;

namespace UnityExtensions.NamedBoxCollider
{
    [System.Serializable]
    public class NamedBoxCollider2D
    {
        public bool Enabled = true;
        public PhysicsMaterial2D Material;
        public string Name;
        public bool IsTrigger;
        public Vector2 Size = new Vector2(1, 1);
        public Vector2 Position;

        public BoxCollider2D Collider
        {
            get { return collider; }
        }

        /// <summary>
        /// Initializes the NamedBoxCollider2D.
        /// </summary>
        /// <param name="parent">The parent GameObject to which this NamedBoxCollider2D belongs.</param>
        public void Initialize(GameObject parent)
        {
            if (!initialized)
            {
                var hideFlags = HideFlags.HideInHierarchy | HideFlags.HideInInspector;

                var colliderObj = new GameObject(Name);
                colliderObj.transform.parent = parent.transform;
                colliderObj.transform.position = Position;
                colliderObj.hideFlags = hideFlags;

                collider = colliderObj.AddComponent<BoxCollider2D>();
                collider.sharedMaterial = Material;
                collider.isTrigger = IsTrigger;
                collider.center = Vector2.zero;
                collider.size = Size;
                collider.hideFlags = hideFlags;

                initialized = true;
            }
        }

        /// <summary>
        /// Destroys this NamedBoxCollider2D.
        /// </summary>
        public void Destroy()
        {
            Object.Destroy(collider.gameObject);
        }

        private BoxCollider2D collider;
        private bool initialized = false;
    }
}
