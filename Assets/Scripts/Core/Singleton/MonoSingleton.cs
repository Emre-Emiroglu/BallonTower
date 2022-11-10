using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Core
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        #region Getters
        public static T Instance { get; private set; }
        #endregion

        #region Singleton
        public virtual void Initialize()
        {
            InitProcess();
        }
        protected virtual void OnDestroy()
        {
            if (Instance != null)
                Destroy(FindObjectOfType<T>());
        }
        private void InitProcess()
        {
            if (Instance == null)
            {
                Instance = this as T;
                //DontDestroyOnLoad(this);
            }
        }
        #endregion

    }
}
