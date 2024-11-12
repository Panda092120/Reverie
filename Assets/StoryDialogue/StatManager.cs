using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player's Stat Manager

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; }

        //base stats
        public int health = 100;
        public int inteligence = 8;
        public int physical = 5;
        public int social = 5;
        public int luck = 0;
        public int experience;

        private void Awake()
        {
            // Check if an instance already exists
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject); // Prevent this object from being destroyed on scene load
            }
            else
            {
                Destroy(gameObject); // Destroy duplicate instance
            }
        }

        //Methods to add experience and check and apply for levelup
        public void addExperience(int experience)
        {
            this.experience += experience;
            //change if statement to change experience requirement
            if(this.experience == 10)
            {
                this.health += 10;
                this.luck += 2;
                this.experience = 0;
            }
        }

        //methods to add stats
        public void addInteligence(int inteligence)
        {
            this.inteligence += inteligence;
        }
        public void addPhysical(int physical)
        {
            this.physical += physical;
        }
        public void addSocial(int social)
        {
            this.social += social;
        }

        //for story stuff
        public bool Act1 = false;
        public bool Act2 = false;
        public bool Act3 = false;
        public bool finalAct = false;



    /*
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    */
}
