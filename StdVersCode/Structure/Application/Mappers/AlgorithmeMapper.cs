﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StdVersCode.Application.Mappers
{
	/// <summary>
	/// Classe qui permet de récupérer la liste des algorithmes d'un mapper 
	/// </summary>
	public class AlgorithmeMapper
	{

		#region Attributs
		public string ProprieteSource { get; private set; }
		public string ProprieteDestination { get; private set; }
		public string Algorithme { get; private set; }

		#endregion

		#region Constructeur 
		public AlgorithmeMapper(string proprieteSource, string proprieteDestination, string algorithme)
		{
			this.ProprieteDestination = proprieteDestination;
			this.ProprieteSource = proprieteSource;
			this.Algorithme = algorithme;

		}
		#endregion


		#region Méthodes

		public override string ToString()
		{
			var res = this.ProprieteSource + " => " + this.ProprieteDestination + "\r\n" + " Algorithme : " + this.Algorithme;
			return res;
		}




		/// <summary>
		/// Retourne la liste des Algorithmes des méthodes des mappers présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<AlgorithmeMapper> AlgorithmesMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeAlgorithmesMethodesMappers = new List<string>();


			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]  / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]  / preceding-sibling::w:tbl / w:tr /w:tc)]";


			if (i == Mapper.NomsMappers(doc, nsmgr).Count && cmp == MethodeMapper.NombreMethodesMappers(doc, nsmgr, i ) - 1)
			{

				 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]  / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]  / preceding-sibling::w:tbl / w:tr /w:tc)]";

			}

			if (i < Mapper.NomsMappers(doc, nsmgr).Count && cmp == MethodeMapper.NombreMethodesMappers(doc, nsmgr,i ) - 1)
			{
				
				 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]  / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] / preceding-sibling::w:tbl / w:tr /w:tc)]";
			}

						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							
								ListeAlgorithmesMethodesMappers.Add(isbn2.InnerText.Trim());
							
						}

			if (ListeAlgorithmesMethodesMappers.Count < 6)
			{
				return null;
			}


			return ( ListeAAlgorithmes(ListeAlgorithmesMethodesMappers));
		}

		/// <summary>
		/// Renvoie la liste des algorithmes des mappers  associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<AlgorithmeMapper> ListeAAlgorithmes(List<string> liste)
		{
			List<AlgorithmeMapper> ListeAlgorithmes = new List<AlgorithmeMapper>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
			ListeAlgorithmes.Add(new  AlgorithmeMapper(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeAlgorithmes;
		}

		#endregion
	}
}
