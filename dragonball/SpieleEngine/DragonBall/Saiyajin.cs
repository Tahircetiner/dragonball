using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonBall{
    public class Saiyajin : Fighter{
        private int level;
        public int Level1 {
            get { return level; }
            set { level = value; }
        }

        public Saiyajin(){
            
        }
        public Saiyajin(Dictionary<string, int> attacks) : base(attacks){
            
        }
        public Saiyajin(int KP) : base(KP){
            
        }
        //Transformation realsieren, derzeit noch nicht implementiert Attacken um ein Vielfaches verstärken
        public void increaseLevel(){
            level++;
            Kp += 500;
        }

        public override String Name { get; set; }
        /*
         * Spezial Attacke, welche nur Saiyajins ausführen können
         * Noch nicht fertig implementiert
         */
        public override void makeSpecialAttack(){
            base.makeSpecialAttack();
        }
    }
}