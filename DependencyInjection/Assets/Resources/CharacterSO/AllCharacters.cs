using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class AllCharacters : ScriptableObject {
    [Serializable]
    public class CharactersItem {
        /// <summary>
        /// 
        /// </summary>
        public string CharacterName;
        /// <summary>
        /// 
        /// </summary>
        public string Hp;
        /// <summary>
        /// 
        /// </summary>
        public string AtkPower;
        /// <summary>
        /// 
        /// </summary>
        public string Occupation;
        }
        /// <summary>
        /// 
        /// </summary>
        public List<CharactersItem> Characters;
    }
