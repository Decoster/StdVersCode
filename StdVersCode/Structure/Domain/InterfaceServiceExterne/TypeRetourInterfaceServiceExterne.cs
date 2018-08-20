﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StdVersCode.Domain.InterfaceServiceExterne
{
	public class TypeRetourInterfaceServiceExterne
	{
		
	
			#region Attributs
			public string Type { get; private set; }
		public string Description { get; private set; }

		#endregion

			#region Constructeur 
		public TypeRetourInterfaceServiceExterne(string type, string description)
			{
				this.Type = type;
				this.Description = description;

			}

		#endregion

		#region Méthodes

		public override string ToString()

		{
			var doc = "";
			if (this.Type != "void")
			{
				doc = "/// <returns>" + this.Description + "." + "</returns>";
			}

			return doc;

		}

		/// <summary>
		/// Methode qui renvoie la liste des colonnes des types de retour des methodes des services externes
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static TypeRetourInterfaceServiceExterne TypeRetourMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i , int cmp)
			{

				XmlNodeList nodeList2;
				XmlElement root = doc.DocumentElement;
				List<string> ListeTypeRetourInterfaceServiceExterne = new List<string>();

				if (MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr,i - 1 )!= 0)
					{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc)]";



				if (i == InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count && cmp == MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr, i - 1))
				{
					
					 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + 1 + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + 1 + "]  /preceding-sibling:: w:tbl / w:tr /w:tc)]";

				}


				if (i < InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count && cmp == MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr, i - 1) - 1)
				{
					 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5]  /preceding-sibling:: w:tbl / w:tr /w:tc)]";

				}
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{

						ListeTypeRetourInterfaceServiceExterne.Add(isbn2.InnerText);

					}

					
				}
				return new TypeRetourInterfaceServiceExterne(ListeTypeRetourInterfaceServiceExterne[2], ListeTypeRetourInterfaceServiceExterne[3]);

		}


			#endregion
		}
	}

