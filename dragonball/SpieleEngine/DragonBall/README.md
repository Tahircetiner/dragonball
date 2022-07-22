# Dragon Ball Z

## Wie funktioniert das Spiel?
Dieses Spiel stellt ein rundenbasiertes Spiel dar. Ein rundenbasiertes Spiel
ist ein Spiel, indem der Angreifer und Verteidiger in jeder Runde
die Möglichkeit haben nur eine Attacke zu starten. 
Das Spiel beginnt damit das der User sich für einen Charakter entscheidet.
Hier muss er zunächst sich auf einen Typ von Kämpfer entscheiden.
Es stehen derzeit folgende Typen zur Auswahl:
- Saiyajin
- Mensch

Da dieses Spiel lediglich einen Prototypen repräsentiert und nicht genügend Zeit
vorhanden war, wurden alle anderen Typen, die in Dragon Ball Z existieren, ausgelassen.
Während der Spieler in jeder Runde die Attacke, welche er ausüben möchte einsetzen kann,
ermittelt der Computer per Zufall eine Attacke, welche der Computer einsetzen möchte.

## Funktionsweise des Programms
Das Spiel basiert darauf, dass aus zwei CSV Dateien die Daten für den jeweiligen Spieler
ausgelesen wird. Innerhalb der CSV Datei sind die Attacken, der Name, der Typ und
eine spezielle ID festgelegt.
Der CSVProcessingService ist dazu da, um gewisse Informationen aus der jeweiligen 
CSV Datei auszulesen. Diese Informationen werden der jeweiligen Kämpfer Klasse zugewiesen.
Innerhalb der BattleArena Klasse ist es nun möglich einen jeweiligen Charakter auszuwählen und das Spiel zu starten.


## Implementierte Features
- Auswahl der jeweiligen Attacke
- Einsetzen der Attacke
- Auswahl eines Charakters
- Einlesen und Verarbeiten einer CSV Datei

## Nicht Implementierte Features
- Einsetzen einer Spezialattacke
- Aufleveln, während des Spielvorgangs
- Maximale Anwendbarkeit einer Attacke festlegen