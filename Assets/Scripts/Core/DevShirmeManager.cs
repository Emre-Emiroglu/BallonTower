using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme
{
    public abstract class DevShirmeManager : MonoBehaviour
    {
        [SerializeField] private ManagerType managerType;
        public ManagerType ManagerType => managerType;
        public abstract void Initialize();
    }
}
