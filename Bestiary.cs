using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MonsterData",menuName ="MonsterFacts")]
public class Bestiary : ScriptableObject
{
        public GameObject model;
        public Animator animator;
        [Tooltip("Type of monster.")] public string monsterType;

        [Tooltip("GO.name prefix.")]public string nameOf;
        //public bool debugMode;

    //Defaults -1 which will randomize at start if Prefab details are not chosen.
    //stats
        [Tooltip("Used for basic intimidation."+
            " 1:Tiny,5:Huge")]                          [Range(1,5)]            public int size=-1;
        [Tooltip("Sustained walk in straight line")]    [Range(0,100)]          public float speed=-1f;
        [Tooltip("How many degrees per second turning"+
         "speed. Also used for dodge.")]                [Range(0,100)]          public float agility=-1f;
        [Tooltip("Max Health.")]                        [Range(0,100)]          public int health=-1;
        [Tooltip("Attack power without mod/weapons.")]  [Range(0,100)]          public float baseAtt=-1f;
        [Tooltip("Defense power without mod/armour.")]  [Range(0,100)]          public float baseDef=-1f;
        [Tooltip("How far can it see?")]                [Range(1f,20f)]         public float viewDist=-1f;
        [Tooltip("View range from 12 o'clock."+
            "0=Blind, 180=360`")]                       [Range(10f,180f)]       public float viewRange=-1f;
        
        
        
          


    //behaviourals
        [Tooltip("How long it will walk before observing. Low=Paranoid High=Gormless")]
        public float wanderDistance=-1;
        [Tooltip("Wander in a straight line? 0=Straight 180=March hare")]
        public float deviateRange=-1;

        [Tooltip("Will it Return to a nest/territory?")]
        public bool territorial=false;

    //traits
        [Tooltip("Will it attack smaller creatures unprovoked?")]
        public bool carnivore=false;
        [Tooltip("Will it pick up a shiny?")]
        public bool curious=true;
        [Tooltip("Will it activate a shiny?")]
        public bool intelligent=false;



}
