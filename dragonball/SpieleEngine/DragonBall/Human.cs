using System;

namespace DragonBall{
    public class Human : Fighter{
        private String name;
        public Human(){
            
        }
        public Human(int KP) : base(KP){
            
        }
        
        /*
         * Spezial Attacken, welche nur der Mensch ausführen kann
         * Noch nicht fertig implementiert
         */
        public override void makeSpecialAttack(){
            base.makeSpecialAttack();
        }
    }
}