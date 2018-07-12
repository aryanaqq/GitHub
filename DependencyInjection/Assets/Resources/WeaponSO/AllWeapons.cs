using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllWeapons : ScriptableObject {
    [Serializable]
    public class WeaponsItem {
        /// <summary>
        /// 
        /// </summary>
        public string ID;
        /// <summary>
        /// 
        /// </summary>
        public string Name;
        /// <summary>
        /// 
        /// </summary>
        public string elementType;
        /// <summary>
        /// 
        /// </summary>
        public string damage;
        /// <summary>
        /// 
        /// </summary>
        public string range;
        }
        /// <summary>
        /// 
        /// </summary>
        public List<WeaponsItem> Weapons;
        

    }
