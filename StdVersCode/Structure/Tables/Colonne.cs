﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StdVersCode.Tables
{
	class Colonne
	{/// <summary>
	 /// Classe qui permet de récupérer les colonnes d'une table 
	 /// </summary>
		#region Attributs
		public string Type;
		public string Description;
		public string Nom;


		#endregion

		#region Constructeur
		public Colonne(string nom, string type, string description)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;

		}
		#endregion

		#region Méthodes

		public override string ToString()
		{
			return ("///" + this.Description + "\n" + " ALTER TABLE" + " " + "ADD" +" " + this.Nom  + " " +  this.Type); // a regler l'ajout du nom de la table concernée 

		}



		/// <summary>
		/// Renvoie la liste des colonnes des tables 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Colonne> ColonnesTables(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeColonnes = new List<string>();


				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][1]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/preceding-sibling::w:tbl / w:tr /w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeColonnes.Add(isbn2.InnerText);

				}
				

			
			return ListeAColonnes(ListeColonnes);

		}

		/// <summary>
		/// Renvoie la liste des colonnes associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<Colonne> ListeAColonnes(List<string> liste)
		{
			List<Colonne> ListeColonnesTables = new List<Colonne>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeColonnesTables.Add(new Colonne(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeColonnesTables;
		}

		#endregion
	}
}
