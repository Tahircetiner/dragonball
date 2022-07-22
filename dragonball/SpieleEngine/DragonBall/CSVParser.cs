using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DragonBall{
    public class CSVParser{
        private readonly String[] lines;
        public CSVParser(String csvFile){
            lines = File.ReadAllLines(Environment.CurrentDirectory + "../../../" + csvFile);
        }
        public String[] getAllLines(){
            return lines;
        }

        public List<String>  getSpecificColumn(int column){
            //Nutzen von LINQ
            var items = lines.Select(line => line.Split(','));
            List<String> list = new List<String>();
            foreach (String[] item in items) {
                for (int i = column; i <= column; i++) {
                    list.Add(item[i]);
                }
            }
            return list;
        }
    }
}