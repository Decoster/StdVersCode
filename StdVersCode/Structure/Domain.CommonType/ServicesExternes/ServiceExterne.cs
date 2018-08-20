﻿using StdVersCode.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace StdVersCode.Structure.Domain.CommonType.ServicesExternes
{
	class ServiceExterne
	{
		#region Constructeur 
		public List<MethodeServiceExterne> Methodes;


		#endregion

		#region Constructeur

		public ServiceExterne(List<MethodeServiceExterne> methodes)
		{
			this.Methodes = methodes;
		}

		#endregion

		#region Methodes

		public override string ToString()
		{
			StringBuilder methodes = new StringBuilder();
			foreach (MethodeServiceExterne methode in this.Methodes)
			{
				if (methode == this.Methodes.First())
				{
					methodes.Append( methode.ToString("[DataContract]") + "\r\n");

				}
				else
				{
					methodes.Append(methode.ToString("[DataMember]") + "\r\n");
				}
			}
			var res = "{" + methodes.ToString() + "}";
			return res;
		}

		/// <summary>
		/// Fonction qui retourne la listes des objets de presentation   
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static ServiceExterne ServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<MethodeServiceExterne> methodes = MethodeServiceExterne.MethodesServicesExternes(doc, nsmgr);

			return (new ServiceExterne(methodes));

		}
		#endregion
	}
}
