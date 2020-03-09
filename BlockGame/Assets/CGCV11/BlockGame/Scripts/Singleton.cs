using UnityEngine;

namespace CGCV11.BlockGame.Scripts
{
    public abstract class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _instance;
        public static T Instance => _instance == null ? FindOrCreateComponentOfType() : _instance;

        private static T FindOrCreateComponentOfType()
        {
            return FindObjectOfType<T>() ?? new GameObject(typeof(T).Name).AddComponent<T>();
        }

        //Virtual function:  if it is good enough use this method,
        // if not, override it and provide your own functionality.
        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                // DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}