﻿using StdVersCode.Domain.Entites;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace StdVersCode.Domain.CommonType.Services_Externes
{

	public class Methode
	{
		#region Attributs 

		public string Nom { get; private set; }
		public DescriptionMethode Descriptions { get; private set; }
		public List<ParametreMethode> ParametresMethode { get; private set; }
		public TypeRetour TypesRetour { get; private set; }
		public string Algorithme { get; private set; }
		#endregion

		#region Constructeur 

		public Methode(string nom, DescriptionMethode descriptions, List<ParametreMethode> parametresMethode, TypeRetour typeRetour,string algorithme)
		{
			this.Nom = nom;
			this.Descriptions = descriptions;
			this.ParametresMethode = parametresMethode;
			this.TypesRetour = typeRetour;
			this.Algorithme = algorithme;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{
			StringBuilder param = new StringBuilder();
			StringBuilder paramMethode = new StringBuilder();
			paramMethode.Append("(");


			foreach (ParametreMethode p in this.ParametresMethode)
			{
				param.Append(p.ToString() + "\r\n");
				if (p == this.ParametresMethode.Last())
				{
					paramMethode = paramMethode.Append(p.Type + p.Nom + " )" + "\r\n");
				}
				else
				{
					paramMethode = paramMethode.Append(p.Type + p.Nom + ",");
				}
			}

			var res = param + "\r\n" + this.TypesRetour.ToString() + "/// <summary>" + "\r\n" + "///" + this.Descriptions.Description + "\r\n" + "/// </summary>" + "\r\n" + "#region Méthodes" + "\r\n" + this.Descriptions.Visibilite + this.TypesRetour.Type + this.Nom + paramMethode + "\r\n" + "{" + "\r\n" + this.Algorithme + "\r\n"  + "}" + "\r\n" + "endregion"  ;
			return res;
		}

		/// <summary>
		/// Retourne la liste des noms des méthodes des entités présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesEntites = new List<string>();

				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][8]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][8]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					MethodesEntites.Add(isbn2.InnerText);
				}
			
			

			return MethodesEntites;


		}


		/// <summary>
		/// Retourne le nombre de methodes de chaque entité
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			
			return NomsMethodesEntites(doc,nsmgr,i).Count;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des entités
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Methode> Methodes(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
				List<Methode> methodes = new List<Methode>();
				List<string> nomsMethodes = NomsMethodesEntites(doc, nsmgr,i);
			
				if (NombreMethodesEntites(doc, nsmgr,i - 1) != 0)
				{
				
					for (int cmp = 0; cmp < NombreMethodesEntites(doc, nsmgr,i - 1); cmp++)
					{

					string algorithmes = AlgorithmesMethodesEntites(doc, nsmgr, i,cmp);
					DescriptionMethode descriptionsMethodes = DescriptionMethode.DescriptionsMethodesEntites(doc, nsmgr,i,cmp);
					List<ParametreMethode> parametresMethodes = ParametreMethode.ParametresMethodesEntites(doc, nsmgr,i,cmp);
					TypeRetour typesRetour = TypeRetour.TypeRetourMethodesEntites(doc, nsmgr,i,cmp);


					methodes.Add(new Methode(nomsMethodes[cmp], descriptionsMethodes, parametresMethodes, typesRetour, algorithmes));


					}
				
				}

			return methodes;
		}

		/// <summary>
		/// Retourne la liste des Algorithmes des méthodes des entités présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string AlgorithmesMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			


					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p)]";


					if (i == Entite.NomsEntites(doc, nsmgr).Count && cmp == NombreMethodesEntites(doc, nsmgr, i - 1) - 1)
					{
						
						 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:p)]";
					}
						

					if (i < Entite.NomsEntites(doc, nsmgr).Count && cmp == NombreMethodesEntites(doc, nsmgr,i - 1) - 1)
					{

						xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i +1)+ "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i +1)+ "]/preceding-sibling:: w:p)]";

					}

					nodeList2 = root.SelectNodes(xpath, nsmgr);
				StringBuilder res = new StringBuilder();
				foreach (XmlNode isbn2 in nodeList2)
					{
						res.Append(" " + (isbn2.InnerText));
					}
				

			return res.ToString();
		}

		



		#endregion
	}

}
