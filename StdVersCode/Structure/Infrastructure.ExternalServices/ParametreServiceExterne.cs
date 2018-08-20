﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StdVersCode.Infrastructure.ExternalServices
{
	class ParametreServiceExterne
	{
		#region Attributs

		public string Nom;
		public string Type;
		public string Description;
		public string AValider;

		#endregion

		#region Constructeur 

		public ParametreServiceExterne(string nom, string type, string description, string aValider)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;
			this.AValider = aValider;
		}

		#endregion

		#region Méthodes 

		/// <summary>
		/// retourne la liste des parametres des methodes des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ParametreServiceExterne> ParametresMethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeParametresMethodesServiceExterne = new List<string>();


				if (MethodeServiceExterne.NombreMethodesServiceExterne(doc, nsmgr,i - 1) != 0)
				{


						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/ following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]  / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]  / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							if (isbn2.InnerText != "")
							{
								ListeParametresMethodesServiceExterne.Add(isbn2.InnerText.Trim());
							}
						}
		
					}

				
			
			return(ListeAParametresServiceExterne(ListeParametresMethodesServiceExterne));

		}


		/// <summary>
		/// Renvoie la liste des colonnes de paramètres associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreServiceExterne> ListeAParametresServiceExterne(List<string> liste)
		{
			List<ParametreServiceExterne> ListeParametresServiceExterne = new List<ParametreServiceExterne>();
			for (int i = 4; i < liste.Count; i = i + 4)
			{
				ListeParametresServiceExterne.Add(new ParametreServiceExterne(liste[i], liste[i + 1], liste[i + 2], liste[i + 3]));
			}
			return ListeParametresServiceExterne;
		}





		#endregion
	}
}
