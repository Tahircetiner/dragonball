using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace DragonBall{
    public class BattleArena{
        public bool isGameRunning = true;
        private bool isHeroTurn = true;
        
        public int nextEnemy ;
        private int killedEnemies;
        public bool isLevelingUp;
        
        private CSVParser csvParserHero = new CSVParser("CSVFile/Heros.csv");
        private CSVParser csvParserEnemy = new CSVParser("CSVFile/Enemies.csv");
        private readonly CSVProcessingService csvProcessingService = new CSVProcessingService();
        
        private Fighter hero = new Fighter(1000);
        private Fighter enemy = new Fighter(1000);
        public void selectCharacter(){
            Console.WriteLine("Welchen Charakter Typ möchtest du?");
            Console.WriteLine("Es stehen zur Auswahl: ");
            
            foreach (String characterType in csvParserHero.getSpecificColumn(2)) {
                Console.WriteLine(characterType);
            }
            
            String choosenType = Console.ReadLine()?.ToLower();
            while (!choosenType.Equals("saiyajin") || !choosenType.Equals("mensch")) {
                if (choosenType.Equals("saiyajin")) {
                    hero = new Saiyajin(1000);
                    Console.WriteLine("Du hast dich für einen Saiyajin entschieden");
                    Console.WriteLine("Es stehen folgende Attacken zur Auswahl");
                    foreach (String attack in csvProcessingService.getSpecificType(choosenType,csvParserHero)) {
                        Console.WriteLine(attack);
                    }
                    break;
                }
                else if (choosenType.Equals("mensch")) {
                    hero = new Human(1000);
                    Console.WriteLine("Dein Name ist " + hero.Name);
                        Console.WriteLine("Du hast dich für einen Menschen entschieden");
                    Console.WriteLine("Es stehen folgende Attacken zur Auswahl");
                    foreach (String attack in csvProcessingService.getSpecificType(choosenType,csvParserHero)) {
                        Console.WriteLine(attack);
                    }
                    break;
                }
                Console.WriteLine("Falsche Eingabe. Versuche es erneut!");
                choosenType = Console.ReadLine().ToLower();
            }
            
            Console.WriteLine("Tippe die entsprechende ID, um deinen Charakter auszuwählen");
            int choosenCharacter = 0;
            try {
                choosenCharacter = Convert.ToInt32(Console.ReadLine());
                
            }
            catch (FormatException formatException) {
                Console.WriteLine("FALSCHE EINGABE DU HAST VERLOREN!");
                isGameRunning = false;
            }

            hero.Name = csvProcessingService.getName(csvParserHero,choosenCharacter);
            hero.Attacks = csvProcessingService.getAllAttacksFromCSVFileAndStoreInDictionary(choosenCharacter,csvParserHero);
            Console.WriteLine("DU HAST DICH FUER "  + hero.Name + " entschieden");
            
            enemy.Name = csvProcessingService.getName(csvParserEnemy, nextEnemy);
            enemy.Attacks = csvProcessingService.getAllAttacksFromCSVFileAndStoreInDictionary(Convert.ToInt32(0),csvParserEnemy);
            
        }
        public void runGame(){
            while (isGameRunning) {
                Console.WriteLine("Dein Feind ist " + enemy.Name);
                if (isHeroTurn) {
                    Console.WriteLine("Du bist an der Reihe. Welche der folgenden Attacken möchtest du einsetzen? Tippe 0,1, 2 oder 3");
                    foreach (KeyValuePair<String, int> attack in hero.Attacks) {
                        Console.WriteLine(attack);
                    }
                    double attackChoiceNumber;
                    try {
                        attackChoiceNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException formatException) {
                        Console.WriteLine(
                            "DAS IST EINE FALSCHE EINGABE! ZUR STRAFE MACHT DEIN CHARAKTER EINE ATTACKE OHNE AUSWIRKUNG!");
                        attackChoiceNumber = 2;
                    }
                    hero.attackEnemy(enemy,hero,attackChoiceNumber);
                    determineWinner();
                    isHeroTurn = false;
                }
                else {
                    Random random = new Random();
                    int randomNumber = random.Next(0, 4);
                    enemy.attackHero(enemy,hero,randomNumber);
                    determineWinner();
                    isHeroTurn = true;
                }
            }
        }

        /*
         * Determiniert den Gewinner
         */
        public void determineWinner(){
            if (enemy.Kp <= 0 && hero.Kp > 0) {
                Console.WriteLine("Du hast gewonnen!");
                Console.WriteLine("Herzlichen Glückwunsch");
                nextEnemy++;
                enemy.Name = csvProcessingService.getName(csvParserEnemy, nextEnemy);
                killedEnemies++;
                Console.WriteLine("GETÖTETE FEINDE " +killedEnemies);
                        
                if (nextEnemy >= 2) {
                    isGameRunning = false;
                    nextEnemy = 0;
                    Console.WriteLine("Du hast das Spiel gewonnen!");
                }
                        
                enemy.Attacks = csvProcessingService.getAllAttacksFromCSVFileAndStoreInDictionary(Convert.ToInt32(nextEnemy), csvParserEnemy);
                enemy.Kp = 1000;
                isLevelingUp = true;
            }
                    
            if (hero.Kp <= 0 && enemy.Kp > 0) {
                isGameRunning = false;
                Console.WriteLine("Du hast das Spiel verloren!");
            }
        }
    }
}