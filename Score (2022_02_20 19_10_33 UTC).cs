using System;
using System.Collections.Generic;
using System.Xml;
using Snake_Clon;

namespace Pong_Teil_1
{
    class Score
    {
        //Felder
        int punkte;
        //Die Anzahl der Einträger der Liste
        int anzahl = 10;
        //für die Liste
        Liste[] bestenliste;
        string xmlDateiname;

        //die Methoden und der Konstructor
        public Score()
        {            
            punkte = 0;
            //eine neue Instanz der Liste
            bestenliste = new Liste[anzahl];
            //die Elemente initialisieren
            for (int i = 0; i < anzahl; i++)
                bestenliste[i] = new Liste();

            
            xmlDateiname = System.AppDomain.CurrentDomain.BaseDirectory + "\\score.xml";
            if (System.IO.File.Exists(xmlDateiname))
                LesePunkte();
        }

        //zum verändern der Punkte
        public int VeraenderePunkte(int anzahl)
        {
            punkte = punkte + anzahl;
            return punkte;
        }

        //zum Zurücksetzen der Punkte
        public void LoeschePunkte()
        {
            punkte = 0;
        }

        public bool NeuerEintrag(System.Windows.Window fenster)
        {
            string tempName = string.Empty;
            //wenn die aktuelle Punktzahl großer ist als der letzte Eintrag in der Liste, wird der letzte Eintrag überschrieben und die Liste neu Sortiert
            if (punkte > bestenliste[anzahl - 1].GetPunkte())
            {
                //den Namen beschaffen
                NameDialog neuerName = new NameDialog();

                neuerName.Owner = fenster;
                //den Dialog Modal Anzeigen lassen
                neuerName.ShowDialog();

                if (neuerName.DialogResult == true)
                    tempName = neuerName.GetNamen();
                neuerName.Close();

                bestenliste[anzahl - 1].setzeEintrag(punkte, tempName);                
                Array.Sort(bestenliste);
                SchreibePunkte();
                return true;
            }
            else
                return false;
        }

        public void ListeAusgeben(System.Windows.Window Fenster)
        {
            List<string> eintraege = new List<string>();
            for (int i = 0; i < anzahl; i++)
            {
                eintraege.Add(Convert.ToString(bestenliste[i].GetPunkte()));
                eintraege.Add(bestenliste[i].GetName());
            }
            //die Liste Anzeigen
            Bestenliste listeAnzeigen = new Bestenliste(eintraege);
            listeAnzeigen.Owner = Fenster;
            listeAnzeigen.ShowDialog();
        }

        //Methode zum Lesen der Datei
        void LesePunkte()
        {
            //zum Zwischenspeichern der gelesenen Daten
            int tempPunkte;
            string tempName;

            //eine Instanz von XML-Reader erzeugen
            XmlReader xmlLesen = XmlReader.Create(xmlDateiname);

            //die Dtaen in einer int- Schleife lesen und zuweisen
            for (int i = 0; i < anzahl; i++)
            {
                xmlLesen.ReadToFollowing("name");
                tempName = xmlLesen.ReadElementContentAsString();
                xmlLesen.ReadToFollowing("punkte");
                tempPunkte = Convert.ToInt32(xmlLesen.ReadElementContentAsString());

                bestenliste[i].setzeEintrag(tempPunkte, tempName);
            }

            //die Datei wieder schließen
            xmlLesen.Close();
        }

        //zum schreiben der Datei
        void SchreibePunkte()
        {
            //die Einstellung setzen
            XmlWriterSettings einstellungen = new XmlWriterSettings();
            einstellungen.Indent = true;

            //eine Instanz von XML-Reader erzeuegen
            XmlWriter xmlSchreiben = XmlWriter.Create(xmlDateiname, einstellungen);

            //die Deklaration schreiben
            xmlSchreiben.WriteStartDocument();

            // einen Wurzelknoten Bestenliste erzeugen
            xmlSchreiben.WriteStartElement("bestenliste");

            //die Daten in einer Schleife wegschreiben
            for(int i =0; i<anzahl;i++)
            {
                //den Knoten eintrag erzeugen
                xmlSchreiben.WriteStartElement("eintrag");
                //die Einträge schreiben
                xmlSchreiben.WriteElementString("name", Convert.ToString(bestenliste[i].GetName()));
                xmlSchreiben.WriteElementString("punkte", Convert.ToString(bestenliste[i].GetPunkte()));
                xmlSchreiben.WriteEndElement();
            }
            //alle abschließen
            xmlSchreiben.WriteEndDocument();
            //Datei schließen
            xmlSchreiben.Close();
        }
    }

    //die Klasse für die Liste, Sie must die Schnittstelle iComparable implementieren
    class Liste : IComparable
    {
        //die Felder
        int listPunkte;
        string listName;

        //die Methoden und der Konstructor
        public Liste()
        {
            //er setzt die Punkte und den Namen auf Standardwerte
            listPunkte = 0;
            listName = "Nobody";
        }

        //die Vergleichsmethode
        public int CompareTo(object objekt)
        {
            Liste tempListe = (Liste)(objekt);
            if (this.listPunkte < tempListe.listPunkte)
                return 1;
            if (this.listPunkte > tempListe.listPunkte)
                return -1;
            else
                return 0;
        }

        //Die Methode zum setzen der Einträge
        public void setzeEintrag(int punkte,string Name)
        {
            listPunkte = punkte;
            listName = Name;
        }

        //die Methode zum liefern der Punkte
        public int GetPunkte()
        {
            return listPunkte;
        }
        
        //die Methode zum Liefern des Namens
        public string GetName()
        {
            return listName;
        }
    }
}
