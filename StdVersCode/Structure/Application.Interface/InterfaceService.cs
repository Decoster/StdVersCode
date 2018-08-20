﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StdVersCode.Application.Interface
{/// <summary>
 /// Classe qui permet de récupérer la liste des interfaces de services  
 /// </summary>
	class InterfaceService
	{
		#region Attributs

		public string Nom;
		public string Description;
		public List<Methode> Methodes;

		#endregion


		#region Constructeur
		public InterfaceService(string nom, string description, List<Methode> methodes)
		{
			this.Nom = nom;
			this.Description = description;
			this.Methodes = methodes;
		}
		public InterfaceService(string nom, string description)
		{
			this.Nom = nom;
			this.Description = description;
			
		}


		#endregion

		#region Méthodes 

		public override string ToString()
		{
			var doc = "/// <summary>" + "\r\n" + "/// " /*this.Description.Trim()*/  + "." + "\r\n" + "/// </summary>" + "\r\n";
			StringBuilder methodes = new StringBuilder();
			foreach (Methode m in this.Methodes)
			{
				methodes.Append("\r\n");


				methodes.Append(m.ToString() + "\r\n");

			}
			var res = doc + "\r\n" + "[ServiceContract]" + "\r\n" + "public interface " + this.Nom + "\r\n" + "#region Méthodes " + "{ " + "\r\n" + methodes + "\r\n" + "#endregion" + "\r\n" + "}";

			return res;
		}
		/// <summary>
		/// Retourne une liste de noms des interfaces de services présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][1]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;


		}

		/// <summary>
		/// Fonction qui retourne la liste des descriptions des interfaces de service    
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionsInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";
				StringBuilder res = new StringBuilder();
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res.Append(isbn2.InnerText);
				}

		
			return res.ToString();


		}


		/// <summary>
		/// Retourne la liste des interfaces de service du fichier  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<InterfaceService> InterfacesService(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<InterfaceService> interfacesServices = new List<InterfaceService>();
			List<string> noms = NomsInterfacesServices(doc, nsmgr);
			

			for (int i = 1; i < NomsInterfacesServices(doc, nsmgr).Count + 1; i++)
			{
				List<Methode> methodes = Methode.Methodes(doc, nsmgr,i);
				string descriptions = DescriptionsInterfacesServices(doc, nsmgr,i);

				if (Methode.NombreMethodesInterfacesServices(doc, nsmgr,i - 1) != 0 )
				{

					interfacesServices.Add(new InterfaceService(noms[i - 1], descriptions, methodes));
				}

				if (Methode.NombreMethodesInterfacesServices(doc, nsmgr,i - 1) == 0)
				{

					interfacesServices.Add(new InterfaceService(noms[i - 1], descriptions));
				}



			}
			return interfacesServices;

		}





		#endregion
	}
}
