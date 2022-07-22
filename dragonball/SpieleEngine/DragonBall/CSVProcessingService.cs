using System;
using System.Collections.Generic;
using System.Linq;

namespace DragonBall{
    
    /*
     * Eine Klasse, welche erlaubt spezifische Informationen aus einer bestimmten CSV Datei zu extrahieren und wiederzugeben
     */
    public class CSVProcessingService{
        
        /*
         * Holt alle Attacken aus der CSV Datei und speichert sie einer Dictionary,
         * da zu einer Attacke immer ein zufügender Schaden zugewiesen werden muss.
         */
        public Dictionary<String, int> getAllAttacksFromCSVFileAndStoreInDictionary(int row, CSVParser csvParser){
            String line = csvParser.getAllLines()[row];
            Dictionary<string, int> attackMapping = new Dictionary<string, int>();
            String[] attacks = line.Split(',');
            String[] attackarr = null;
            for (int i = 3; i < attacks.Length; i++) {
                attackarr = attacks[i].Split(':');
                for(int k = 0; k < 1; k++){
                    attackMapping.Add(attackarr[k],Convert.ToInt32(attackarr[k + 1]));
                }
            }

            return attackMapping;
        }
        
        public List<string> getSpecificType(String specificType, CSVParser csvParser){
            List<string> specificTypeList = new List<string>();
            for (int i = 0; i < csvParser.getAllLines().Length; i++) {
                if (csvParser.getAllLines()[i].Contains(specificType)) {
                    specificTypeList.Add(csvParser.getAllLines()[i]);
                }
            }
            return specificTypeList;
        }

        public List<string> getFromSpecificTypeIDs(String specificType, CSVParser csvParser){
            List<string> specificTypeList = getSpecificType(specificType, csvParser);
            List<string> IDs = new List<string>();
            foreach (String type in specificTypeList) {
                IDs.Add(Convert.ToString(type[0]));
            }
            return IDs;
        }

        public String getName(CSVParser csvParser, int row){
            String characterLine = csvParser.getAllLines()[row];
            String[] character = characterLine.Split(',');
            return character[1];
        }

    }
}