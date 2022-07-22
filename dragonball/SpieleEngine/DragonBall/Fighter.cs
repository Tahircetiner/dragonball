using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonBall{
    public class Fighter{
        private int KP;
        private Dictionary<String, Int32> attacks = new Dictionary<String, int>();
        private String name;
        private int AP;
        
        public Fighter(){
            
        }
        public Fighter(Dictionary<String, Int32> attacks){
            this.attacks = attacks;
        }
        public Fighter(int KP){
            this.KP = KP;
        }

        public Dictionary<String, int> Attacks {
            get { return attacks; }
            set { attacks = value; }
        }
        public virtual int Kp {
            get { return KP; }
            set { KP = value; }
        }

        public virtual String Name {
            get { return name; }
            set { name = value; }
        }

        public int Ap {
            get { return AP; }
            set { AP = value; }
        }

        public void attackEnemy(Fighter enemy, Fighter hero, double attack){
            int damage  = hero.Attacks.ElementAt((int) attack).Value;
            Console.WriteLine("Du hast " + hero.Attacks.ElementAt((int) attack) +  " eingesetzt!");
            enemy.KP -= damage;
            Console.WriteLine("Dein Gegner hat nur noch " + enemy.KP + " KP!");
        }

        public void attackHero(Fighter enemy, Fighter hero, int attack){
            int damage  = enemy.Attacks.ElementAt(attack).Value;
            Console.WriteLine("Dein Gegner hat " + enemy.Attacks.ElementAt(attack) +  " eingesetzt!");
            hero.KP -= damage;
            Console.WriteLine("Du hast nur noch " + hero.KP +  "KP");
        }

        public virtual void makeSpecialAttack(){
            
        }
    }
}