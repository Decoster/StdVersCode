﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace StdVersCode.Application.Mappers
{
	public partial class MethodeMapper  
	{
		#region Attributs 

		public string NomMethode { get; private set; }
		public string Descriptions { get; private set; }
		public ParametreEntrantMapper ParametresMethode { get; private set; }
		public TypeRetourMapper TypesRetour { get; private set; }
		public List<AlgorithmeMapper> Algorithme { get; private set; }

		#endregion

		#region Constructeur 

		public MethodeMapper(string nom, string descriptions, ParametreEntrantMapper parametresMethode, TypeRetourMapper typeRetour, List<AlgorithmeMapper> algorithme)
		{
			this.NomMethode = nom;
			this.Descriptions = descriptions;
			this.ParametresMethode = parametresMethode;
			this.TypesRetour = typeRetour;
			this.Algorithme = algorithme;

		}

		#endregion

		#region Méthodes 
	

		public override string ToString()
		{
			var res = "";
			var doc = "/// <summary>" + "\r\n" + "/// " + this.Descriptions + "." + "\r\n" + "/// </summary>" + "\r\n";
			var param = "";
			var paramMethode = "";
			if (this.ParametresMethode != null)
			{
				
				paramMethode = "(" + this.ParametresMethode.Type + " " + this.ParametresMethode.Nom + " " + ")";

				param = this.ParametresMethode.ToString() + "\r\n";

			}
			var retour = "";
			if (this.TypesRetour != null)
			{
				retour = this.TypesRetour.ToString() + "\r\n";
			}
			StringBuilder algo = new StringBuilder();
			if (this.Algorithme != null)
			{
				foreach (AlgorithmeMapper a in this.Algorithme)
				{
					algo.Append(a.ToString() + "\r\n");
				}
			}
			res = doc + param + retour + "\r\n" + "public static" + " " + TypesRetour.Type + " " + this.NomMethode + " " + paramMethode + "\r\n" + "{" +"\r\n" +algo.ToString() + "\r\n" + "}";




			return res;

		}

	 
		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des mappers
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<MethodeMapper> MethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr, int i)
		{
			List<MethodeMapper> methodes = new List<MethodeMapper>();

			if (NombreMethodesMappers(doc, nsmgr, i) != 0)
			{
				List<string> nomsMethodes = NomsMethodesMappers(doc, nsmgr, i);

				for (int cmp = 0; cmp < NombreMethodesMappers(doc, nsmgr, i); cmp++)
				{
					string descriptions = DescriptionsMethodesMappers(doc, nsmgr, i, cmp);
					List<AlgorithmeMapper> algorithmes = AlgorithmeMapper.AlgorithmesMethodesMappers(doc, nsmgr, i, cmp);
					ParametreEntrantMapper parametresMethodes = ParametreEntrantMapper.ParametresMethodesMappers(doc, nsmgr, i, cmp);
					TypeRetourMapper typesRetour = TypeRetourMapper.TypeRetourMethodesMappers(doc, nsmgr, i, cmp);


					methodes.Add(new MethodeMapper(nomsMethodes[cmp], descriptions, parametresMethodes, typesRetour, algorithmes));


				}

			}

			return methodes;
		}
		/// <summary>
		/// Retourne le nombre de methodes de chaque mapper
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr, int i)
		{

			return NomsMethodesMappers(doc, nsmgr, i).Count;
		}

		/// <summary>
		/// Retourne la liste des noms des méthodes des mappers présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesMapper = new List<string>();

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::  w:p [ w:pPr / w:pStyle [@w:val='Heading5']] [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

			if (i == Mapper.NomsMappers(doc, nsmgr).Count)
			{
				
				xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";
			}
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						MethodesMapper.Add(isbn2.InnerText);
					}
			

			return MethodesMapper;


		}







		

		/// <summary>
		/// Retourne la liste des descriptions des méthodes des mappers présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public  static string DescriptionsMethodesMappers(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
	
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p)]";
					StringBuilder res = new StringBuilder();
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						res.Append(isbn2.InnerText + "\r\n");
					}


			return res.ToString();


		}



		#endregion
	}
}
