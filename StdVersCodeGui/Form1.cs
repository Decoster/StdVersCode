using StdVersCode.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO.Compression;
using System.IO;
using System.Text.RegularExpressions;

namespace StdVersCodeGui
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fdb = new FolderBrowserDialog();
			fdb.RootFolder = Environment.SpecialFolder.Desktop;
			fdb.Description = " Select Folder ";
			fdb.ShowNewFolderButton = false;

			if (fdb.ShowDialog() == DialogResult.OK)
			{
				textBox1.Text = fdb.SelectedPath;
			}
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			// Method intentionally left empty.
		}

		private void button2_Click(object sender, EventArgs e)
		{
			bool exists = System.IO.Directory.Exists(textBox1.Text + "\\" + textBox2.Text);
			if (!exists)
			{
				System.IO.Directory.CreateDirectory(textBox1.Text + "\\" + textBox2.Text);
			}
			else
			{
				MessageBox.Show("The file already exists !");
			}

			XmlDocument doc = new XmlDocument();

			doc.Load(textBox3.Text);
			XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
			var http = "http:";
			nsmgr.AddNamespace("wpc", http + "//schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
			nsmgr.AddNamespace("cx", http + "//schemas.microsoft.com/office/drawing/2014/chartex");
			nsmgr.AddNamespace("cx1", http + "//schemas.microsoft.com/office/drawing/2015/9/8/chartex");
			nsmgr.AddNamespace("cx2", http + "//schemas.microsoft.com/office/drawing/2015/10/21/chartex");
			nsmgr.AddNamespace("cx3", http + "//schemas.microsoft.com/office/drawing/2016/5/9/chartex");
			nsmgr.AddNamespace("cx4", http + "//schemas.microsoft.com/office/drawing/2016/5/10/chartex");
			nsmgr.AddNamespace("cx5", http + "//schemas.microsoft.com/office/drawing/2016/5/11/chartex");
			nsmgr.AddNamespace("cx6", http + "//schemas.microsoft.com/office/drawing/2016/5/12/chartex");
			nsmgr.AddNamespace("cx7", http + "//schemas.microsoft.com/office/drawing/2016/5/13/chartex");
			nsmgr.AddNamespace("cx8", http + "//schemas.microsoft.com/office/drawing/2016/5/14/chartex");
			nsmgr.AddNamespace("mc", http + "//schemas.openxmlformats.org/markup-compatibility/2006");
			nsmgr.AddNamespace("aink", http + "//schemas.microsoft.com/office/drawing/2016/ink");
			nsmgr.AddNamespace("am3d", http + "//schemas.microsoft.com/office/drawing/2017/model3d");
			nsmgr.AddNamespace("o", "urn:schemas-microsoft-com:office:office");
			nsmgr.AddNamespace("r", http + "//schemas.openxmlformats.org/officeDocument/2006/relationships");
			nsmgr.AddNamespace("m", http + "//schemas.openxmlformats.org/officeDocument/2006/math");
			nsmgr.AddNamespace("v", "urn:schemas-microsoft-com:vml");
			nsmgr.AddNamespace("wp14", http + "//schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
			nsmgr.AddNamespace("wp", http + "//schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
			nsmgr.AddNamespace("w10", "urn:schemas-microsoft-com:office:word");
			nsmgr.AddNamespace("w", http + "//schemas.openxmlformats.org/wordprocessingml/2006/main");
			nsmgr.AddNamespace("w14", http + "//schemas.microsoft.com/office/word/2010/wordml");
			nsmgr.AddNamespace("w15", http + "//schemas.microsoft.com/office/word/2012/wordml");
			nsmgr.AddNamespace("w16se", http + "//schemas.microsoft.com/office/word/2015/wordml/symex");
			nsmgr.AddNamespace("wpg", http + "//schemas.microsoft.com/office/word/2010/wordprocessingGroup");
			nsmgr.AddNamespace("wpi", http + "//schemas.microsoft.com/office/word/2010/wordprocessingInk");
			nsmgr.AddNamespace("wne", http + "//schemas.microsoft.com/office/word/2006/wordml");
			nsmgr.AddNamespace("wps", http + "//schemas.microsoft.com/office/word/2010/wordprocessingShape");
			nsmgr.AddNamespace("mc: Ignorable", "w14 w15 w16se wp14");

			StringToCode.CreerApplication(doc, nsmgr, textBox1.Text + "\\" + textBox2.Text, textBox2.Text);
		}

		private void label2_Click(object sender, EventArgs e)
		{
			// Method intentionally left empty.
		}

		private void button3_Click(object sender, EventArgs e)
		{
			OpenFileDialog fdlg = new OpenFileDialog();
			fdlg.Title = "Choisis une STD  à convertir ";
			fdlg.InitialDirectory = @"c:\";
			fdlg.Filter = "Word File (.docx ,.doc|*.docx;*.doc)";
			fdlg.FilterIndex = 2;
			fdlg.RestoreDirectory = true;
			if (fdlg.ShowDialog() == DialogResult.OK)
			{
				
				var text = Path.ChangeExtension(fdlg.FileName, ".zip");
				FileInfo f = new FileInfo(fdlg.FileName);
				f.MoveTo(Path.ChangeExtension(fdlg.FileName, ".zip"));
				string extractPath = Regex.Replace(text, ".zip", "");

				System.IO.Compression.ZipFile.ExtractToDirectory(text, extractPath);
				textBox3.Text = extractPath + "\\" + "word" + "\\" + "document.xml";
		
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Method intentionally left empty.
		}

		private void label3_Click(object sender, EventArgs e)
		{

		}
	}
}
