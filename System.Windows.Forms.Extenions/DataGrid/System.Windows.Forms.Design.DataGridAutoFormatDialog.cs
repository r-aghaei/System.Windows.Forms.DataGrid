// System.Windows.Forms.Design.DataGridAutoFormatDialog
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml;
namespace System.Windows.Forms.Design
{
	internal class DataGridAutoFormatDialog : Form
	{
		private class AutoFormatDataGrid : DataGrid
		{
			protected override void OnKeyDown(KeyEventArgs e)
			{
			}

			protected override bool ProcessDialogKey(Keys keyData)
			{
				return false;
			}

			protected override bool ProcessKeyPreview(ref Message m)
			{
				return false;
			}

			protected override void OnMouseDown(MouseEventArgs e)
			{
			}

			protected override void OnMouseUp(MouseEventArgs e)
			{
			}

			protected override void OnMouseMove(MouseEventArgs e)
			{
			}
		}

		private DataGrid dgrid;

		private DataTable schemeTable;

		private DataSet dataSet = new DataSet();

		private AutoFormatDataGrid dataGrid;

		private DataGridTableStyle tableStyle;

		private Button button2;

		private Button button1;

		private ListBox schemeName;

		private Label formats;

		private Label preview;

		private bool IMBusy;

		private TableLayoutPanel okCancelTableLayoutPanel;

		private TableLayoutPanel overarchingTableLayoutPanel;

		private int selectedIndex = -1;

		internal const string scheme = "<xsd:schema id=\"pulica\" xmlns=\"\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\"><xsd:element name=\"Scheme\"><xsd:complexType><xsd:all><xsd:element name=\"SchemeName\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"SchemePicture\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"BorderStyle\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"FlatMode\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"Font\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"CaptionFont\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"HeaderFont\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"AlternatingBackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"BackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"BackgroundColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"CaptionForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"CaptionBackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"ForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"GridLineColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"GridLineStyle\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"HeaderBackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"HeaderForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"LinkColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"LinkHoverColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"ParentRowsBackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"ParentRowsForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"SelectionForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"SelectionBackColor\" minOccurs=\"0\" type=\"xsd:string\"/></xsd:all></xsd:complexType></xsd:element></xsd:schema>";

		internal const string data = "<pulica><Scheme><SchemeName>Default</SchemeName><SchemePicture>default.bmp</SchemePicture><BorderStyle></BorderStyle><FlatMode></FlatMode><CaptionFont></CaptionFont><Font></Font><HeaderFont></HeaderFont><AlternatingBackColor></AlternatingBackColor><BackColor></BackColor><CaptionForeColor></CaptionForeColor><CaptionBackColor></CaptionBackColor><ForeColor></ForeColor><GridLineColor></GridLineColor><GridLineStyle></GridLineStyle><HeaderBackColor></HeaderBackColor><HeaderForeColor></HeaderForeColor><LinkColor></LinkColor><LinkHoverColor></LinkHoverColor><ParentRowsBackColor></ParentRowsBackColor><ParentRowsForeColor></ParentRowsForeColor><SelectionForeColor></SelectionForeColor><SelectionBackColor></SelectionBackColor></Scheme><Scheme><SchemeName>Professional 1</SchemeName><SchemePicture>professional1.bmp</SchemePicture><CaptionFont>Verdana, 10pt</CaptionFont><AlternatingBackColor>LightGray</AlternatingBackColor><CaptionForeColor>Navy</CaptionForeColor><CaptionBackColor>White</CaptionBackColor><ForeColor>Black</ForeColor><BackColor>DarkGray</BackColor><GridLineColor>Black</GridLineColor><GridLineStyle>None</GridLineStyle><HeaderBackColor>Silver</HeaderBackColor><HeaderForeColor>Black</HeaderForeColor><LinkColor>Navy</LinkColor><LinkHoverColor>Blue</LinkHoverColor><ParentRowsBackColor>White</ParentRowsBackColor><ParentRowsForeColor>Black</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>Navy</SelectionBackColor></Scheme><Scheme><SchemeName>Professional 2</SchemeName><SchemePicture>professional2.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><CaptionFont>Tahoma, 8pt</CaptionFont><AlternatingBackColor>Gainsboro</AlternatingBackColor><BackColor>Silver</BackColor><CaptionForeColor>White</CaptionForeColor><CaptionBackColor>DarkSlateBlue</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>White</GridLineColor><HeaderBackColor>DarkGray</HeaderBackColor><HeaderForeColor>Black</HeaderForeColor><LinkColor>DarkSlateBlue</LinkColor><LinkHoverColor>RoyalBlue</LinkHoverColor><ParentRowsBackColor>Black</ParentRowsBackColor><ParentRowsForeColor>White</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>DarkSlateBlue</SelectionBackColor></Scheme><Scheme><SchemeName>Professional 3</SchemeName><SchemePicture>professional3.bmp</SchemePicture><BorderStyle>None</BorderStyle><FlatMode>True</FlatMode><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><Font>Tahoma, 8pt</Font><AlternatingBackColor>LightGray</AlternatingBackColor><BackColor>Gainsboro</BackColor><BackgroundColor>Silver</BackgroundColor><CaptionForeColor>MidnightBlue</CaptionForeColor><CaptionBackColor>LightSteelBlue</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>DimGray</GridLineColor><GridLineStyle>None</GridLineStyle><HeaderBackColor>MidnightBlue</HeaderBackColor><HeaderForeColor>White</HeaderForeColor><LinkColor>MidnightBlue</LinkColor><LinkHoverColor>RoyalBlue</LinkHoverColor><ParentRowsBackColor>DarkGray</ParentRowsBackColor><ParentRowsForeColor>Black</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>CadetBlue</SelectionBackColor></Scheme><Scheme><SchemeName>Professional 4</SchemeName><SchemePicture>professional4.bmp</SchemePicture><BorderStyle>None</BorderStyle><FlatMode>True</FlatMode><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><Font>Tahoma, 8pt</Font><AlternatingBackColor>Lavender</AlternatingBackColor><BackColor>WhiteSmoke</BackColor><BackgroundColor>LightGray</BackgroundColor><CaptionForeColor>MidnightBlue</CaptionForeColor><CaptionBackColor>LightSteelBlue</CaptionBackColor><ForeColor>MidnightBlue</ForeColor><GridLineColor>Gainsboro</GridLineColor><GridLineStyle>None</GridLineStyle><HeaderBackColor>MidnightBlue</HeaderBackColor><HeaderForeColor>WhiteSmoke</HeaderForeColor><LinkColor>Teal</LinkColor><LinkHoverColor>DarkMagenta</LinkHoverColor><ParentRowsBackColor>Gainsboro</ParentRowsBackColor><ParentRowsForeColor>MidnightBlue</ParentRowsForeColor><SelectionForeColor>WhiteSmoke</SelectionForeColor><SelectionBackColor>CadetBlue</SelectionBackColor></Scheme><Scheme><SchemeName>Classic</SchemeName><SchemePicture>classic.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><Font>Times New Roman, 9pt</Font><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><AlternatingBackColor>WhiteSmoke</AlternatingBackColor><BackColor>Gainsboro</BackColor><BackgroundColor>DarkGray</BackgroundColor><CaptionForeColor>Black</CaptionForeColor><CaptionBackColor>DarkKhaki</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>Silver</GridLineColor><HeaderBackColor>Black</HeaderBackColor><HeaderForeColor>White</HeaderForeColor><LinkColor>DarkSlateBlue</LinkColor><LinkHoverColor>Firebrick</LinkHoverColor><ParentRowsForeColor>Black</ParentRowsForeColor><ParentRowsBackColor>LightGray</ParentRowsBackColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>Firebrick</SelectionBackColor></Scheme><Scheme><SchemeName>Simple</SchemeName><SchemePicture>Simple.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><Font>Courier New, 9pt</Font><HeaderFont>Courier New, 10pt, style=1</HeaderFont><CaptionFont>Courier New, 10pt, style=1</CaptionFont><AlternatingBackColor>White</AlternatingBackColor><BackColor>White</BackColor><BackgroundColor>Gainsboro</BackgroundColor><CaptionForeColor>Black</CaptionForeColor><CaptionBackColor>Silver</CaptionBackColor><ForeColor>DarkSlateGray</ForeColor><GridLineColor>DarkGray</GridLineColor><HeaderBackColor>DarkGreen</HeaderBackColor><HeaderForeColor>White</HeaderForeColor><LinkColor>DarkGreen</LinkColor><LinkHoverColor>Blue</LinkHoverColor><ParentRowsForeColor>Black</ParentRowsForeColor><ParentRowsBackColor>Gainsboro</ParentRowsBackColor><SelectionForeColor>Black</SelectionForeColor><SelectionBackColor>DarkSeaGreen</SelectionBackColor></Scheme><Scheme><SchemeName>Colorful 1</SchemeName><SchemePicture>colorful1.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 9pt, style=1</CaptionFont><HeaderFont>Tahoma, 9pt, style=1</HeaderFont><AlternatingBackColor>LightGoldenrodYellow</AlternatingBackColor><BackColor>White</BackColor><BackgroundColor>LightGoldenrodYellow</BackgroundColor><CaptionForeColor>DarkSlateBlue</CaptionForeColor><CaptionBackColor>LightGoldenrodYellow</CaptionBackColor><ForeColor>DarkSlateBlue</ForeColor><GridLineColor>Peru</GridLineColor><GridLineStyle>None</GridLineStyle><HeaderBackColor>Maroon</HeaderBackColor><HeaderForeColor>LightGoldenrodYellow</HeaderForeColor><LinkColor>Maroon</LinkColor><LinkHoverColor>SlateBlue</LinkHoverColor><ParentRowsBackColor>BurlyWood</ParentRowsBackColor><ParentRowsForeColor>DarkSlateBlue</ParentRowsForeColor><SelectionForeColor>GhostWhite</SelectionForeColor><SelectionBackColor>DarkSlateBlue</SelectionBackColor></Scheme><Scheme><SchemeName>Colorful 2</SchemeName><SchemePicture>colorful2.bmp</SchemePicture><BorderStyle>None</BorderStyle><FlatMode>True</FlatMode><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><AlternatingBackColor>GhostWhite</AlternatingBackColor><BackColor>GhostWhite</BackColor><BackgroundColor>Lavender</BackgroundColor><CaptionForeColor>White</CaptionForeColor><CaptionBackColor>RoyalBlue</CaptionBackColor><ForeColor>MidnightBlue</ForeColor><GridLineColor>RoyalBlue</GridLineColor><HeaderBackColor>MidnightBlue</HeaderBackColor><HeaderForeColor>Lavender</HeaderForeColor><LinkColor>Teal</LinkColor><LinkHoverColor>DodgerBlue</LinkHoverColor><ParentRowsBackColor>Lavender</ParentRowsBackColor><ParentRowsForeColor>MidnightBlue</ParentRowsForeColor><SelectionForeColor>PaleGreen</SelectionForeColor><SelectionBackColor>Teal</SelectionBackColor></Scheme><Scheme><SchemeName>Colorful 3</SchemeName><SchemePicture>colorful3.bmp</SchemePicture><BorderStyle>None</BorderStyle><FlatMode>True</FlatMode><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><AlternatingBackColor>OldLace</AlternatingBackColor><BackColor>OldLace</BackColor><BackgroundColor>Tan</BackgroundColor><CaptionForeColor>OldLace</CaptionForeColor><CaptionBackColor>SaddleBrown</CaptionBackColor><ForeColor>DarkSlateGray</ForeColor><GridLineColor>Tan</GridLineColor><GridLineStyle>Solid</GridLineStyle><HeaderBackColor>Wheat</HeaderBackColor><HeaderForeColor>SaddleBrown</HeaderForeColor><LinkColor>DarkSlateBlue</LinkColor><LinkHoverColor>Teal</LinkHoverColor><ParentRowsBackColor>OldLace</ParentRowsBackColor><ParentRowsForeColor>DarkSlateGray</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>SlateGray</SelectionBackColor></Scheme><Scheme><SchemeName>Colorful 4</SchemeName><SchemePicture>colorful4.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><AlternatingBackColor>White</AlternatingBackColor><BackColor>White</BackColor><BackgroundColor>Ivory</BackgroundColor><CaptionForeColor>Lavender</CaptionForeColor><CaptionBackColor>DarkSlateBlue</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>Wheat</GridLineColor><HeaderBackColor>CadetBlue</HeaderBackColor><HeaderForeColor>Black</HeaderForeColor><LinkColor>DarkSlateBlue</LinkColor><LinkHoverColor>LightSeaGreen</LinkHoverColor><ParentRowsBackColor>Ivory</ParentRowsBackColor><ParentRowsForeColor>Black</ParentRowsForeColor><SelectionForeColor>DarkSlateBlue</SelectionForeColor><SelectionBackColor>Wheat</SelectionBackColor></Scheme><Scheme><SchemeName>256 Color 1</SchemeName><SchemePicture>256_1.bmp</SchemePicture><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 8 pt</CaptionFont><HeaderFont>Tahoma, 8pt</HeaderFont><AlternatingBackColor>Silver</AlternatingBackColor><BackColor>White</BackColor><CaptionForeColor>White</CaptionForeColor><CaptionBackColor>Maroon</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>Silver</GridLineColor><HeaderBackColor>Silver</HeaderBackColor><HeaderForeColor>Black</HeaderForeColor><LinkColor>Maroon</LinkColor><LinkHoverColor>Red</LinkHoverColor><ParentRowsBackColor>Silver</ParentRowsBackColor><ParentRowsForeColor>Black</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>Maroon</SelectionBackColor></Scheme><Scheme><SchemeName>256 Color 2</SchemeName><SchemePicture>256_2.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><CaptionFont>Microsoft Sans Serif, 10 pt, style=1</CaptionFont><Font>Tahoma, 8pt</Font><HeaderFont>Tahoma, 8pt</HeaderFont><AlternatingBackColor>White</AlternatingBackColor><BackColor>White</BackColor><CaptionForeColor>White</CaptionForeColor><CaptionBackColor>Teal</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>Silver</GridLineColor><HeaderBackColor>Black</HeaderBackColor><HeaderForeColor>White</HeaderForeColor><LinkColor>Purple</LinkColor><LinkHoverColor>Fuchsia</LinkHoverColor><ParentRowsBackColor>Gray</ParentRowsBackColor><ParentRowsForeColor>White</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>Maroon</SelectionBackColor></Scheme></pulica>";

		public DataRow SelectedData
		{
			get
			{
				if (schemeName != null)
				{
					return ((DataRowView)schemeName.Items[selectedIndex]).Row;
				}
				return null;
			}
		}

		internal DataGridAutoFormatDialog(DataGrid dgrid)
		{
			this.dgrid = dgrid;
			base.ShowInTaskbar = false;
			dataSet.Locale = CultureInfo.InvariantCulture;
			dataSet.ReadXmlSchema(new XmlTextReader(new StringReader("<xsd:schema id=\"pulica\" xmlns=\"\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:msdata=\"urn:schemas-microsoft-com:xml-msdata\"><xsd:element name=\"Scheme\"><xsd:complexType><xsd:all><xsd:element name=\"SchemeName\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"SchemePicture\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"BorderStyle\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"FlatMode\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"Font\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"CaptionFont\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"HeaderFont\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"AlternatingBackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"BackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"BackgroundColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"CaptionForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"CaptionBackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"ForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"GridLineColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"GridLineStyle\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"HeaderBackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"HeaderForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"LinkColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"LinkHoverColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"ParentRowsBackColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"ParentRowsForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"SelectionForeColor\" minOccurs=\"0\" type=\"xsd:string\"/><xsd:element name=\"SelectionBackColor\" minOccurs=\"0\" type=\"xsd:string\"/></xsd:all></xsd:complexType></xsd:element></xsd:schema>")));
			dataSet.ReadXml(new StringReader("<pulica><Scheme><SchemeName>Default</SchemeName><SchemePicture>default.bmp</SchemePicture><BorderStyle></BorderStyle><FlatMode></FlatMode><CaptionFont></CaptionFont><Font></Font><HeaderFont></HeaderFont><AlternatingBackColor></AlternatingBackColor><BackColor></BackColor><CaptionForeColor></CaptionForeColor><CaptionBackColor></CaptionBackColor><ForeColor></ForeColor><GridLineColor></GridLineColor><GridLineStyle></GridLineStyle><HeaderBackColor></HeaderBackColor><HeaderForeColor></HeaderForeColor><LinkColor></LinkColor><LinkHoverColor></LinkHoverColor><ParentRowsBackColor></ParentRowsBackColor><ParentRowsForeColor></ParentRowsForeColor><SelectionForeColor></SelectionForeColor><SelectionBackColor></SelectionBackColor></Scheme><Scheme><SchemeName>Professional 1</SchemeName><SchemePicture>professional1.bmp</SchemePicture><CaptionFont>Verdana, 10pt</CaptionFont><AlternatingBackColor>LightGray</AlternatingBackColor><CaptionForeColor>Navy</CaptionForeColor><CaptionBackColor>White</CaptionBackColor><ForeColor>Black</ForeColor><BackColor>DarkGray</BackColor><GridLineColor>Black</GridLineColor><GridLineStyle>None</GridLineStyle><HeaderBackColor>Silver</HeaderBackColor><HeaderForeColor>Black</HeaderForeColor><LinkColor>Navy</LinkColor><LinkHoverColor>Blue</LinkHoverColor><ParentRowsBackColor>White</ParentRowsBackColor><ParentRowsForeColor>Black</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>Navy</SelectionBackColor></Scheme><Scheme><SchemeName>Professional 2</SchemeName><SchemePicture>professional2.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><CaptionFont>Tahoma, 8pt</CaptionFont><AlternatingBackColor>Gainsboro</AlternatingBackColor><BackColor>Silver</BackColor><CaptionForeColor>White</CaptionForeColor><CaptionBackColor>DarkSlateBlue</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>White</GridLineColor><HeaderBackColor>DarkGray</HeaderBackColor><HeaderForeColor>Black</HeaderForeColor><LinkColor>DarkSlateBlue</LinkColor><LinkHoverColor>RoyalBlue</LinkHoverColor><ParentRowsBackColor>Black</ParentRowsBackColor><ParentRowsForeColor>White</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>DarkSlateBlue</SelectionBackColor></Scheme><Scheme><SchemeName>Professional 3</SchemeName><SchemePicture>professional3.bmp</SchemePicture><BorderStyle>None</BorderStyle><FlatMode>True</FlatMode><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><Font>Tahoma, 8pt</Font><AlternatingBackColor>LightGray</AlternatingBackColor><BackColor>Gainsboro</BackColor><BackgroundColor>Silver</BackgroundColor><CaptionForeColor>MidnightBlue</CaptionForeColor><CaptionBackColor>LightSteelBlue</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>DimGray</GridLineColor><GridLineStyle>None</GridLineStyle><HeaderBackColor>MidnightBlue</HeaderBackColor><HeaderForeColor>White</HeaderForeColor><LinkColor>MidnightBlue</LinkColor><LinkHoverColor>RoyalBlue</LinkHoverColor><ParentRowsBackColor>DarkGray</ParentRowsBackColor><ParentRowsForeColor>Black</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>CadetBlue</SelectionBackColor></Scheme><Scheme><SchemeName>Professional 4</SchemeName><SchemePicture>professional4.bmp</SchemePicture><BorderStyle>None</BorderStyle><FlatMode>True</FlatMode><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><Font>Tahoma, 8pt</Font><AlternatingBackColor>Lavender</AlternatingBackColor><BackColor>WhiteSmoke</BackColor><BackgroundColor>LightGray</BackgroundColor><CaptionForeColor>MidnightBlue</CaptionForeColor><CaptionBackColor>LightSteelBlue</CaptionBackColor><ForeColor>MidnightBlue</ForeColor><GridLineColor>Gainsboro</GridLineColor><GridLineStyle>None</GridLineStyle><HeaderBackColor>MidnightBlue</HeaderBackColor><HeaderForeColor>WhiteSmoke</HeaderForeColor><LinkColor>Teal</LinkColor><LinkHoverColor>DarkMagenta</LinkHoverColor><ParentRowsBackColor>Gainsboro</ParentRowsBackColor><ParentRowsForeColor>MidnightBlue</ParentRowsForeColor><SelectionForeColor>WhiteSmoke</SelectionForeColor><SelectionBackColor>CadetBlue</SelectionBackColor></Scheme><Scheme><SchemeName>Classic</SchemeName><SchemePicture>classic.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><Font>Times New Roman, 9pt</Font><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><AlternatingBackColor>WhiteSmoke</AlternatingBackColor><BackColor>Gainsboro</BackColor><BackgroundColor>DarkGray</BackgroundColor><CaptionForeColor>Black</CaptionForeColor><CaptionBackColor>DarkKhaki</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>Silver</GridLineColor><HeaderBackColor>Black</HeaderBackColor><HeaderForeColor>White</HeaderForeColor><LinkColor>DarkSlateBlue</LinkColor><LinkHoverColor>Firebrick</LinkHoverColor><ParentRowsForeColor>Black</ParentRowsForeColor><ParentRowsBackColor>LightGray</ParentRowsBackColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>Firebrick</SelectionBackColor></Scheme><Scheme><SchemeName>Simple</SchemeName><SchemePicture>Simple.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><Font>Courier New, 9pt</Font><HeaderFont>Courier New, 10pt, style=1</HeaderFont><CaptionFont>Courier New, 10pt, style=1</CaptionFont><AlternatingBackColor>White</AlternatingBackColor><BackColor>White</BackColor><BackgroundColor>Gainsboro</BackgroundColor><CaptionForeColor>Black</CaptionForeColor><CaptionBackColor>Silver</CaptionBackColor><ForeColor>DarkSlateGray</ForeColor><GridLineColor>DarkGray</GridLineColor><HeaderBackColor>DarkGreen</HeaderBackColor><HeaderForeColor>White</HeaderForeColor><LinkColor>DarkGreen</LinkColor><LinkHoverColor>Blue</LinkHoverColor><ParentRowsForeColor>Black</ParentRowsForeColor><ParentRowsBackColor>Gainsboro</ParentRowsBackColor><SelectionForeColor>Black</SelectionForeColor><SelectionBackColor>DarkSeaGreen</SelectionBackColor></Scheme><Scheme><SchemeName>Colorful 1</SchemeName><SchemePicture>colorful1.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 9pt, style=1</CaptionFont><HeaderFont>Tahoma, 9pt, style=1</HeaderFont><AlternatingBackColor>LightGoldenrodYellow</AlternatingBackColor><BackColor>White</BackColor><BackgroundColor>LightGoldenrodYellow</BackgroundColor><CaptionForeColor>DarkSlateBlue</CaptionForeColor><CaptionBackColor>LightGoldenrodYellow</CaptionBackColor><ForeColor>DarkSlateBlue</ForeColor><GridLineColor>Peru</GridLineColor><GridLineStyle>None</GridLineStyle><HeaderBackColor>Maroon</HeaderBackColor><HeaderForeColor>LightGoldenrodYellow</HeaderForeColor><LinkColor>Maroon</LinkColor><LinkHoverColor>SlateBlue</LinkHoverColor><ParentRowsBackColor>BurlyWood</ParentRowsBackColor><ParentRowsForeColor>DarkSlateBlue</ParentRowsForeColor><SelectionForeColor>GhostWhite</SelectionForeColor><SelectionBackColor>DarkSlateBlue</SelectionBackColor></Scheme><Scheme><SchemeName>Colorful 2</SchemeName><SchemePicture>colorful2.bmp</SchemePicture><BorderStyle>None</BorderStyle><FlatMode>True</FlatMode><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><AlternatingBackColor>GhostWhite</AlternatingBackColor><BackColor>GhostWhite</BackColor><BackgroundColor>Lavender</BackgroundColor><CaptionForeColor>White</CaptionForeColor><CaptionBackColor>RoyalBlue</CaptionBackColor><ForeColor>MidnightBlue</ForeColor><GridLineColor>RoyalBlue</GridLineColor><HeaderBackColor>MidnightBlue</HeaderBackColor><HeaderForeColor>Lavender</HeaderForeColor><LinkColor>Teal</LinkColor><LinkHoverColor>DodgerBlue</LinkHoverColor><ParentRowsBackColor>Lavender</ParentRowsBackColor><ParentRowsForeColor>MidnightBlue</ParentRowsForeColor><SelectionForeColor>PaleGreen</SelectionForeColor><SelectionBackColor>Teal</SelectionBackColor></Scheme><Scheme><SchemeName>Colorful 3</SchemeName><SchemePicture>colorful3.bmp</SchemePicture><BorderStyle>None</BorderStyle><FlatMode>True</FlatMode><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><AlternatingBackColor>OldLace</AlternatingBackColor><BackColor>OldLace</BackColor><BackgroundColor>Tan</BackgroundColor><CaptionForeColor>OldLace</CaptionForeColor><CaptionBackColor>SaddleBrown</CaptionBackColor><ForeColor>DarkSlateGray</ForeColor><GridLineColor>Tan</GridLineColor><GridLineStyle>Solid</GridLineStyle><HeaderBackColor>Wheat</HeaderBackColor><HeaderForeColor>SaddleBrown</HeaderForeColor><LinkColor>DarkSlateBlue</LinkColor><LinkHoverColor>Teal</LinkHoverColor><ParentRowsBackColor>OldLace</ParentRowsBackColor><ParentRowsForeColor>DarkSlateGray</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>SlateGray</SelectionBackColor></Scheme><Scheme><SchemeName>Colorful 4</SchemeName><SchemePicture>colorful4.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 8pt, style=1</CaptionFont><HeaderFont>Tahoma, 8pt, style=1</HeaderFont><AlternatingBackColor>White</AlternatingBackColor><BackColor>White</BackColor><BackgroundColor>Ivory</BackgroundColor><CaptionForeColor>Lavender</CaptionForeColor><CaptionBackColor>DarkSlateBlue</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>Wheat</GridLineColor><HeaderBackColor>CadetBlue</HeaderBackColor><HeaderForeColor>Black</HeaderForeColor><LinkColor>DarkSlateBlue</LinkColor><LinkHoverColor>LightSeaGreen</LinkHoverColor><ParentRowsBackColor>Ivory</ParentRowsBackColor><ParentRowsForeColor>Black</ParentRowsForeColor><SelectionForeColor>DarkSlateBlue</SelectionForeColor><SelectionBackColor>Wheat</SelectionBackColor></Scheme><Scheme><SchemeName>256 Color 1</SchemeName><SchemePicture>256_1.bmp</SchemePicture><Font>Tahoma, 8pt</Font><CaptionFont>Tahoma, 8 pt</CaptionFont><HeaderFont>Tahoma, 8pt</HeaderFont><AlternatingBackColor>Silver</AlternatingBackColor><BackColor>White</BackColor><CaptionForeColor>White</CaptionForeColor><CaptionBackColor>Maroon</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>Silver</GridLineColor><HeaderBackColor>Silver</HeaderBackColor><HeaderForeColor>Black</HeaderForeColor><LinkColor>Maroon</LinkColor><LinkHoverColor>Red</LinkHoverColor><ParentRowsBackColor>Silver</ParentRowsBackColor><ParentRowsForeColor>Black</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>Maroon</SelectionBackColor></Scheme><Scheme><SchemeName>256 Color 2</SchemeName><SchemePicture>256_2.bmp</SchemePicture><BorderStyle>FixedSingle</BorderStyle><FlatMode>True</FlatMode><CaptionFont>Microsoft Sans Serif, 10 pt, style=1</CaptionFont><Font>Tahoma, 8pt</Font><HeaderFont>Tahoma, 8pt</HeaderFont><AlternatingBackColor>White</AlternatingBackColor><BackColor>White</BackColor><CaptionForeColor>White</CaptionForeColor><CaptionBackColor>Teal</CaptionBackColor><ForeColor>Black</ForeColor><GridLineColor>Silver</GridLineColor><HeaderBackColor>Black</HeaderBackColor><HeaderForeColor>White</HeaderForeColor><LinkColor>Purple</LinkColor><LinkHoverColor>Fuchsia</LinkHoverColor><ParentRowsBackColor>Gray</ParentRowsBackColor><ParentRowsForeColor>White</ParentRowsForeColor><SelectionForeColor>White</SelectionForeColor><SelectionBackColor>Maroon</SelectionBackColor></Scheme></pulica>"), XmlReadMode.IgnoreSchema);
			schemeTable = dataSet.Tables["Scheme"];
			IMBusy = true;
			InitializeComponent();
			schemeName.DataSource = schemeTable;
			AddDataToDataGrid();
			AddStyleSheetInformationToDataGrid();
			if (dgrid.Site != null)
			{
				IUIService iUIService = (IUIService)dgrid.Site.GetService(typeof(IUIService));
				if (iUIService != null)
				{
					Font font = (Font)iUIService.Styles["DialogFont"];
					if (font != null)
					{
						Font = font;
					}
				}
			}
			IMBusy = false;
		}

		private void AddStyleSheetInformationToDataGrid()
		{
			DataGridTableStyle dataGridTableStyle = new DataGridTableStyle();
			dataGridTableStyle.MappingName = "Table1";
			DataGridColumnStyle dataGridColumnStyle = new DataGridTextBoxColumn();
			dataGridColumnStyle.MappingName = "First Name";
			dataGridColumnStyle.HeaderText = SR.GetString("DataGridAutoFormatTableFirstColumn");
			DataGridColumnStyle dataGridColumnStyle2 = new DataGridTextBoxColumn();
			dataGridColumnStyle2.MappingName = "Last Name";
			dataGridColumnStyle2.HeaderText = SR.GetString("DataGridAutoFormatTableSecondColumn");
			dataGridTableStyle.GridColumnStyles.Add(dataGridColumnStyle);
			dataGridTableStyle.GridColumnStyles.Add(dataGridColumnStyle2);
			DataRowCollection rows = dataSet.Tables["Scheme"].Rows;
			DataRow dataRow = rows[0];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameDefault");
			dataRow = rows[1];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameProfessional1");
			dataRow = rows[2];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameProfessional2");
			dataRow = rows[3];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameProfessional3");
			dataRow = rows[4];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameProfessional4");
			dataRow = rows[5];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameClassic");
			dataRow = rows[6];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameSimple");
			dataRow = rows[7];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameColorful1");
			dataRow = rows[8];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameColorful2");
			dataRow = rows[9];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameColorful3");
			dataRow = rows[10];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeNameColorful4");
			dataRow = rows[11];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeName256Color1");
			dataRow = rows[12];
			dataRow["SchemeName"] = SR.GetString("DataGridAutoFormatSchemeName256Color2");
			dataGrid.TableStyles.Add(dataGridTableStyle);
			tableStyle = dataGridTableStyle;
		}

		private void AddDataToDataGrid()
		{
			DataTable dataTable = new DataTable("Table1");
			dataTable.Locale = CultureInfo.InvariantCulture;
			dataTable.Columns.Add(new DataColumn("First Name"));
			dataTable.Columns.Add(new DataColumn("Last Name"));
			DataRow dataRow = dataTable.NewRow();
			dataRow["First Name"] = "Robert";
			dataRow["Last Name"] = "Brown";
			dataTable.Rows.Add(dataRow);
			dataRow = dataTable.NewRow();
			dataRow["First Name"] = "Nate";
			dataRow["Last Name"] = "Sun";
			dataTable.Rows.Add(dataRow);
			dataRow = dataTable.NewRow();
			dataRow["First Name"] = "Carole";
			dataRow["Last Name"] = "Poland";
			dataTable.Rows.Add(dataRow);
			dataGrid.SetDataBinding(dataTable, "");
		}

		private void AutoFormat_HelpRequested(object sender, HelpEventArgs e)
		{
			if (dgrid != null && dgrid.Site != null)
			{
				IDesignerHost designerHost = dgrid.Site.GetService(typeof(IDesignerHost)) as IDesignerHost;
				if (designerHost != null)
				{
					(designerHost.GetService(typeof(IHelpService)) as IHelpService)?.ShowHelpFromKeyword("vs.DataGridAutoFormatDialog");
				}
			}
		}

		private void Button1_Clicked(object sender, EventArgs e)
		{
			selectedIndex = schemeName.SelectedIndex;
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(System.Windows.Forms.Design.DataGridAutoFormatDialog));
			formats = new System.Windows.Forms.Label();
			schemeName = new System.Windows.Forms.ListBox();
			dataGrid = new System.Windows.Forms.Design.DataGridAutoFormatDialog.AutoFormatDataGrid();
			preview = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			button2 = new System.Windows.Forms.Button();
			okCancelTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			overarchingTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)dataGrid).BeginInit();
			okCancelTableLayoutPanel.SuspendLayout();
			overarchingTableLayoutPanel.SuspendLayout();
			SuspendLayout();
			resources.ApplyResources(formats, "formats");
			formats.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			formats.Name = "formats";
			resources.ApplyResources(schemeName, "schemeName");
			schemeName.DisplayMember = "SchemeName";
			schemeName.FormattingEnabled = true;
			schemeName.Margin = new System.Windows.Forms.Padding(0, 2, 3, 3);
			schemeName.Name = "schemeName";
			schemeName.SelectedIndexChanged += new System.EventHandler(SchemeName_SelectionChanged);
			resources.ApplyResources(dataGrid, "dataGrid");
			dataGrid.DataMember = "";
			dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			dataGrid.Margin = new System.Windows.Forms.Padding(3, 2, 0, 3);
			dataGrid.Name = "dataGrid";
			resources.ApplyResources(preview, "preview");
			preview.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			preview.Name = "preview";
			resources.ApplyResources(button1, "button1");
			button1.DialogResult = System.Windows.Forms.DialogResult.OK;
			button1.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			button1.MinimumSize = new System.Drawing.Size(75, 23);
			button1.Name = "button1";
			button1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			button1.Click += new System.EventHandler(Button1_Clicked);
			resources.ApplyResources(button2, "button2");
			button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			button2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			button2.MinimumSize = new System.Drawing.Size(75, 23);
			button2.Name = "button2";
			button2.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
			resources.ApplyResources(okCancelTableLayoutPanel, "okCancelTableLayoutPanel");
			overarchingTableLayoutPanel.SetColumnSpan(okCancelTableLayoutPanel, 2);
			okCancelTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			okCancelTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50f));
			okCancelTableLayoutPanel.Controls.Add(button1, 0, 0);
			okCancelTableLayoutPanel.Controls.Add(button2, 1, 0);
			okCancelTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
			okCancelTableLayoutPanel.Name = "okCancelTableLayoutPanel";
			okCancelTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			resources.ApplyResources(overarchingTableLayoutPanel, "overarchingTableLayoutPanel");
			overarchingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 146f));
			overarchingTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182f));
			overarchingTableLayoutPanel.Controls.Add(okCancelTableLayoutPanel, 0, 2);
			overarchingTableLayoutPanel.Controls.Add(preview, 1, 0);
			overarchingTableLayoutPanel.Controls.Add(dataGrid, 1, 1);
			overarchingTableLayoutPanel.Controls.Add(formats, 0, 0);
			overarchingTableLayoutPanel.Controls.Add(schemeName, 0, 1);
			overarchingTableLayoutPanel.Name = "overarchingTableLayoutPanel";
			overarchingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			overarchingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50f));
			overarchingTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			base.AcceptButton = button1;
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = button2;
			base.Controls.Add(overarchingTableLayoutPanel);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DataGridAutoFormatDialog";
			base.ShowIcon = false;
			base.HelpRequested += new System.Windows.Forms.HelpEventHandler(AutoFormat_HelpRequested);
			((System.ComponentModel.ISupportInitialize)dataGrid).EndInit();
			okCancelTableLayoutPanel.ResumeLayout(false);
			okCancelTableLayoutPanel.PerformLayout();
			overarchingTableLayoutPanel.ResumeLayout(false);
			overarchingTableLayoutPanel.PerformLayout();
			ResumeLayout(false);
		}

		private static bool IsTableProperty(string propName)
		{
			if (propName.Equals("HeaderColor"))
			{
				return true;
			}
			if (propName.Equals("AlternatingBackColor"))
			{
				return true;
			}
			if (propName.Equals("BackColor"))
			{
				return true;
			}
			if (propName.Equals("ForeColor"))
			{
				return true;
			}
			if (propName.Equals("GridLineColor"))
			{
				return true;
			}
			if (propName.Equals("GridLineStyle"))
			{
				return true;
			}
			if (propName.Equals("HeaderBackColor"))
			{
				return true;
			}
			if (propName.Equals("HeaderForeColor"))
			{
				return true;
			}
			if (propName.Equals("LinkColor"))
			{
				return true;
			}
			if (propName.Equals("LinkHoverColor"))
			{
				return true;
			}
			if (propName.Equals("SelectionForeColor"))
			{
				return true;
			}
			if (propName.Equals("SelectionBackColor"))
			{
				return true;
			}
			if (propName.Equals("HeaderFont"))
			{
				return true;
			}
			return false;
		}

		private void SchemeName_SelectionChanged(object sender, EventArgs e)
		{
			if (IMBusy)
			{
				return;
			}
			DataRow row = ((DataRowView)schemeName.SelectedItem).Row;
			if (row == null)
			{
				return;
			}
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(DataGrid));
			PropertyDescriptorCollection properties2 = TypeDescriptor.GetProperties(typeof(DataGridTableStyle));
			foreach (DataColumn column in row.Table.Columns)
			{
				object obj = row[column];
				PropertyDescriptor propertyDescriptor;
				object component;
				if (IsTableProperty(column.ColumnName))
				{
					propertyDescriptor = properties2[column.ColumnName];
					component = tableStyle;
				}
				else
				{
					propertyDescriptor = properties[column.ColumnName];
					component = dataGrid;
				}
				if (propertyDescriptor == null)
				{
					continue;
				}
				if (Convert.IsDBNull(obj) || obj.ToString().Length == 0)
				{
					propertyDescriptor.ResetValue(component);
					continue;
				}
				try
				{
					TypeConverter converter = propertyDescriptor.Converter;
					object value = converter.ConvertFromString(obj.ToString());
					propertyDescriptor.SetValue(component, value);
				}
				catch
				{
				}
			}
		}
	}
}