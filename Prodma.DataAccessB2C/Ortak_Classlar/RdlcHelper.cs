using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace Prodma.DataAccessB2C
{
    public static class RdlcHelper
    {
        /// <summary>
        /// Dictionary with translations
        /// </summary>
        private static SortedDictionary<string, SortedDictionary<string, PropertyInfo>> translations;

        /// <summary>
        /// The regular expression to match something that should be localized.
        /// </summary>
        /// <remarks>If changed, remember to have two groups. First for resource file, 
        /// and second for key in resource file.</remarks>
        private static readonly Regex localize = new Regex(@"^::(\w+)\.(.+)::$", RegexOptions.Compiled);

        /// <summary>
        /// Fill up the translations dictionary
        /// </summary>
        static void Rdlc()
        {
            // The assembly with the resource files 
            // (Should consist of strongly typed resource files, with public strings)
           
            //Assembly a = REPLACE_ME; // I.e: Assembly.GetAssembly(typeof(SomeTypeInResourceAssembly));

           ////////System.Reflection.Assembly assem = System.Reflection.Assembly.Load("Prodma.DataAccess");
           ////////Globals.rman = new System.Resources.ResourceManager("Prodma.DataAccessB2C.Resources.Resource1.trTR", assem);

           ////////  Assembly a = Assembly.GetAssembly(typeof(assem));

            //Assembly a =  Assembly.GetAssembly(typeof(Prodma.DataAccessB2C.Resources.rsReportIngilizce));
            //// Create dictionary
            //translations = new SortedDictionary<string, SortedDictionary<string, PropertyInfo>>();

            //// Then fill it up with all the translations in the assembly and all their public and static 
            //// properties.
            //foreach (Type t in a.GetTypes())
            //{
            //    translations.Add(t.Name, new SortedDictionary<string, PropertyInfo>(t
            //        .GetProperties(BindingFlags.Public | BindingFlags.Static)
            //        .ToDictionary(ø => ø.Name)));
            //}
           
        }

        /// <summary>
        /// Localizes the given report definition.
        /// </summary>
        /// <param name="reportDefinition">Rdlc file as a stream.</param>
        /// 

        public static TextReader Localize(Stream ReportDefinition,Dictionary<string,string> parameters)
        {
            System.Reflection.Assembly assem = System.Reflection.Assembly.Load("Prodma.DataAccessB2C");
            System.Resources.ResourceManager rManRapor;
            if (parameters.ContainsKey("DIL_ID") && parameters["DIL_ID"] == "2")
            {
                rManRapor = new System.Resources.ResourceManager("Prodma.DataAccessB2C.Resources.Resource1.enUS", assem);
            }
            else
            {
                rManRapor = new System.Resources.ResourceManager("Prodma.DataAccessB2C.Resources.Resource1.trTR", assem);
            }
            //  Rdlc();
            // Make sure we are at the beginning of the stream
            ReportDefinition.Position = 0;

            // Create the XDocument and load it with the xml from the report definition
            XDocument x;
            XmlTextReader reader = new XmlTextReader(ReportDefinition);
            {
                x = XDocument.Load(reader);
            }

            // Get default xml namespace in rdlc file (So we don't have to type it in manually...)
            XNamespace n = x.Root.Name.Namespace;

            //var listColumn = from XElement e in x.Descendants(n + "TablixColumn").Descendants(n + "Width")
            //           select e;
            //foreach (var item1 in listColumn)
            //{
            //    item1.Value = "1in";
            //}  Bu kodlar tum columnların widthlerini degistirebiliyorumç

            var list = from XElement e in x.Descendants(n + "Textbox")
                       select e;
            bool rowTextBoxBulundu = false;
            foreach (var item in list)
            {
                rowTextBoxBulundu = false;
                var canGrow = item.Descendants(n + "CanGrow").FirstOrDefault();
                //PRODMA_HR  if (canGrow != null) canGrow.Value = "false";
                #region paragraphs
                string name = item.FirstAttribute.Value;
                var list2 = item.Descendants(n + "Paragraphs").Descendants(n + "Paragraph").Descendants(n + "TextRuns").Descendants(n + "TextRun").ToList();
                if (list2.Count > 0)
                {
                    var listIsimlendir = list2.Descendants(n + "Value").ToList();

                    if (String.IsNullOrEmpty(listIsimlendir[0].Value) == false && listIsimlendir[0].Value.StartsWith("=") == false)
                    {
                        if (name.Length > 3)
                        {
                            name = name.Substring(0, name.Length - 3);
                            string deger = rManRapor.GetString(name);
                            if (deger != null && deger != "") listIsimlendir[0].Value = deger;
                        }
                    }
                    foreach (var item1 in list2)
                    {
                        var listFormat = item1.Descendants(n + "Style").Descendants(n + "Format").ToList();
                        if (listFormat.Count > 0)
                        {
                            if (listFormat[0].Value == "miktar")
                            {
                                var listExpressionValue = item1.Descendants(n + "Value").ToList();
                                if (listExpressionValue.Count > 0)
                                {
                                    if (listExpressionValue[0].Value.ToString()!="" && listExpressionValue[0].Value.ToString().Substring(0, 1) == "=")
                                    {
                                        listExpressionValue[0].Value = listExpressionValue[0].Value.ToString().Remove(0, 1);
                                        listExpressionValue[0].Value = "=iif(" + listExpressionValue[0].Value + " = \"0\",\"\"," + listExpressionValue[0].Value + ")";
                                    }
                                }
                                try
                                {
                                    listFormat[0].Value = "=iif(Fields!STOK_BIRIM_IC.Value = \"AD\" ,\"0;-0\",\"0.0000;-0.0000\")";
                                }
                                catch (Exception)
                                {
                                    listFormat[0].Value = "0.0000;-0.0000";
                                }
                                
                            }
                            else if (listFormat[0].Value == "altiFormat")
                            {
                                listFormat[0].Value = "0.000000;-0.000000";
                            }
                            else if (listFormat[0].Value == "oran")
                            {
                                listFormat[0].Value = "0.00;-0.00";
                            }
                            else if (listFormat[0].Value == "ucFormat")
                            {
                                listFormat[0].Value = "0.00;-0.00";
                            }
                            else if (listFormat[0].Value == "miktar1")
                            {
                                listFormat[0].Value = "0.0000;-0.0000";
                            }
                            else if (listFormat[0].Value == "dortFormat")
                            {
                                listFormat[0].Value = "0.0000;-0.0000";
                            }
                            else if (listFormat[0].Value == "agirlik")
                            {
                                listFormat[0].Value = "0.0000;-0.0000";
                            }
                            else if (listFormat[0].Value == "fiyat")
                            {
                                listFormat[0].Value = "0.00000;-0.00000";
                            }
                            else if (listFormat[0].Value == "dovizKur")
                            {
                                listFormat[0].Value = "0.00000;-0.00000";
                            }
                            else if (listFormat[0].Value == "tutar")
                            {
                                //e.Value = "0.0000;(0.0000)";
                                listFormat[0].Value = "#,0.00;#,0.00-";
                                //listFormat[0].Value = "#,0.00;-#,0.00";
                               
                            }
                            else if (listFormat[0].Value == "tarih")
                            {
                                //e.Value = "0.0000;(0.0000)";
                                listFormat[0].Value = "d";
                            }
                            else if (listFormat[0].Value == "row")
                            {
                                rowTextBoxBulundu = true;
                            }
                        }
                        var listFontSize = item1.Descendants(n + "Style").Descendants(n + "FontSize").ToList();
                        if (listFontSize.Count > 0)
                        {
                          //PRODMA_HR  listFontSize[0].Value = "8pt";
                        }
                    }
                }
                #endregion
                if (rowTextBoxBulundu == true)
                {
                     var border = item.Descendants(n + "Style").Descendants(n + "Border").FirstOrDefault();
                     if (border != null)
                     {
                        var border2 =  border.Descendants(n + "Style").FirstOrDefault();
                        if (border2 != null)
                        {
                            border2.Value = "Solid";
                        }
                        var border3 = border.Descendants(n + "Color").FirstOrDefault();
                        if (border3!=null)
                        {
                           border3.Value = "black";                             
                        }
                     }
                     ////////////var BottomBorder = item.Descendants(n + "Style").Descendants(n + "BottomBorder").FirstOrDefault();
                     ////////////if (BottomBorder != null)
                     ////////////{
                     ////////////    var BottomBorder2 = border.Descendants(n + "Style").FirstOrDefault();
                     ////////////    if (BottomBorder2!=null)
                     ////////////    {
                     ////////////        BottomBorder2.Value = "5pt";
                     ////////////    }
                     ////////////}
                      //<Border>
                      //    <Style>Solid</Style>
                      //  </Border>
                      //  <TopBorder>
                      //    <Style>Solid</Style>
                      //    <Width>1pt</Width>
                      //  </TopBorder>
                      //  <BottomBorder>
                      //    <Style>Solid</Style>
                      //    <Width>1.5pt</Width>
                      //  </BottomBorder>
                      //  <LeftBorder>
                      //    <Style>Solid</Style>
                      //    <Width>1pt</Width>
                      //  </LeftBorder>
                      //  <RightBorder>
                      //    <Style>Solid</Style>
                      //    <Width>1pt</Width>
                      //  </RightBorder>
                    var Color = item.Descendants(n + "Style").Descendants(n + "BackgroundColor").FirstOrDefault();
                    if (Color != null)
                    {
                        //Color.Value = "red";
                    }
                    else
                    {
                                 //XElement xColor = new XElement("Sytle","");
                                  //item.Add(xColor);
                        var Color1 = item.Descendants(n + "Style").ToList();
                                // XElement xBgColor = new XElement(n+"BackgroundColor");
                        XElement xBgColor = new XElement(n + "BackgroundColor");
                        xBgColor.Value = "red";
                        if (Color1.Count > 3)
                        {
                  //          Color1[2].AddFirst(xBgColor);
                        }
                    }
                }
                var listHeight = item.Descendants(n + "Height").ToList();
                foreach (var itemHeight in listHeight)
                {
                    //PRODMA_HR  itemHeight.Value = "0.5cm";
                }


            }
           

            
            // Write and return
            StringWriterWithEncoding output = new StringWriterWithEncoding(Encoding.UTF8);
            x.Save(output);

            StringReader r = new StringReader(output.ToString());

            return r;
        }

        public static TextReader Localize1(Stream ReportDefinition)
        {
          //  Rdlc();
            // Make sure we are at the beginning of the stream
            ReportDefinition.Position = 0;

            // Create the XDocument and load it with the xml from the report definition
            XDocument x;
            XmlTextReader reader = new XmlTextReader(ReportDefinition);
            {
                x = XDocument.Load(reader);
            }

            // Get default xml namespace in rdlc file (So we don't have to type it in manually...)
            XNamespace n = x.Root.Name.Namespace;

            var list = from XElement e in x.Descendants(n + "Textbox")
                       select e;

            foreach (var item in list)
            {
                var list2 = item.Descendants(n+"Paragraphs").Descendants(n+"Paragraph").Descendants(n+"TextRuns").Descendants(n+"TextRun").ToList();
                if (list2.Count > 0)
                {
                    foreach (var item1 in list2)
	                {
                        var list3 = item1.Descendants(n+"Style").Descendants(n+"Format").ToList();
                        if (list3.Count>0)
                        {
                            if (list3[0].Value == "miktar")
                            {
                                var list4 = item1.Descendants(n + "Value").ToList();
                                if (list4.Count > 0)
                                {
                                    if (list4[0].Value.ToString().Substring(0, 1) == "=")
                                    {
                                        list4[0].Value = list4[0].Value.ToString().Remove(0, 1);
                                        list4[0].Value = "=iif(" + list4[0].Value + " = \"0\",\"\"," + list4[0].Value + ")";
                                    }
                                }
                            }
                        }
                      
                    }
                }
            }
            //foreach (XElement e in x.Descendants(n + "Textbox"))
            //{
            //    if (String.IsNullOrEmpty(e.Value) || e.Value.StartsWith("="))
            //        continue;

            //    var list = from e in d.Descendants("record")
            //               where e.Attribute("id").Value == "2"
            //               select e;

            //    if (e.Descendants(n+"Style") == "miktar")
            //    {

            //    }
            //    // Skip if it is empty or an expression
                

            //    // Otherwise run it through our regular expression
            //    Match m = localize.Match(e.Value);

            //    // If it matches our expression, and we find a matching translation in our translations dictionary
            //    // Replace the value with our translation
            //    //  e.Value = Globals.rman.GetString("TARIH").ToString();
            //}

            // Go through all Value nodes in all Textbox nodes
            foreach (XElement e in x.Descendants(n + "Textbox").Descendants(n + "Value"))
            {
                // Skip if it is empty or an expression
                if (String.IsNullOrEmpty(e.Value) || e.Value.StartsWith("="))
                    continue;

                // Otherwise run it through our regular expression
                Match m = localize.Match(e.Value);

                // If it matches our expression, and we find a matching translation in our translations dictionary
               // Replace the value with our translation
              //  e.Value = Globals.rman.GetString("TARIH").ToString();
            }

            foreach (XElement e in x.Descendants(n + "Textbox").Descendants(n + "Value"))
            {
                // Skip if it is empty or an expression
                if (String.IsNullOrEmpty(e.Value))
                    continue;

                // Otherwise run it through our regular expression
                Match m = localize.Match(e.Value);

                // If it matches our expression, and we find a matching translation in our translations dictionary
                // Replace the value with our translation
                if (e.Value.ToString().Substring(0, 1) == "=")
                {
                    //e.Value = e.Value.ToString().Remove(0, 1);
                    //e.Value = "=iif(" + e.Value + " = \"0\",\"\"," + e.Value + ")";
                    //=iif(Fields!GIRIS_MIKTAR.Value="0","",Fields!GIRIS_MIKTAR.Value)
                    //=iif(Fields!CIKIS_MIKTAR.Value="0","",Fields!CIKIS_MIKTAR.Value
                }
            }
            foreach (XElement e in x.Descendants(n + "Textbox").Descendants(n + "FontSize"))
            {
                // Skip if it is empty or an expression
                if (String.IsNullOrEmpty(e.Value) || e.Value.StartsWith("="))
                    continue;

                // Otherwise run it through our regular expression
                Match m = localize.Match(e.Value);

                // If it matches our expression, and we find a matching translation in our translations dictionary
                // Replace the value with our translation
                e.Value = "8pt";
            }
            foreach (XElement e in x.Descendants(n + "Textbox").Descendants(n + "CanGrow"))
            {
                // Skip if it is empty or an expression
                if (String.IsNullOrEmpty(e.Value) || e.Value.StartsWith("="))
                    continue;

                // Otherwise run it through our regular expression
                Match m = localize.Match(e.Value);

                // If it matches our expression, and we find a matching translation in our translations dictionary
                // Replace the value with our translation
                e.Value = "false";
            }
            foreach (XElement e in x.Descendants(n + "Textbox").Descendants(n + "Format"))
            {
                // Skip if it is empty or an expression
                if (String.IsNullOrEmpty(e.Value) || e.Value.StartsWith("="))
                    continue;

                // Otherwise run it through our regular expression
                Match m = localize.Match(e.Value);

                // If it matches our expression, and we find a matching translation in our translations dictionary
                // Replace the value with our translation
                if (e.Value == "fiyat")
                {
                    e.Value = "0.00000;-0.00000";
                }
                else if (e.Value == "miktar")

                {
                    //e.Value = "0.0000;(0.0000)";
                    try
                    {
                        e.Value = "=iif(Fields!STOK_BIRIM_IC.Value = \"A\" ,\"0;-0\",\"0.0000;-0.0000\")";
                    }
                    catch (Exception)
                    {
                        e.Value = "0.0000;-0.0000";
                    }
                }
                else if (e.Value == "tutar")
                {
                    //e.Value = "0.0000;(0.0000)";
                    e.Value = "0.00;-0.00";
                }
                else if (e.Value == "miktarbirim")
                {
                    //e.Value = "0.0000;(0.0000)";
                    try
                    {
                        e.Value = "=iif(Fields!STOK_BIRIM_IC.Value = \"A\" ,\"0;-0\",\"0.0000;-0.0000\")";
                    }
                    catch (Exception)
                    {
                        e.Value = "0.0000;-0.0000";
                    }
                }
            }
            // Write and return
            StringWriterWithEncoding output = new StringWriterWithEncoding(Encoding.UTF8);
            x.Save(output);

            StringReader r = new StringReader(output.ToString());

            return r;
        }

        /// <summary>
        /// A string writer where we can specify the encoding.
        /// </summary>
        private class StringWriterWithEncoding : StringWriter
        {
            private Encoding encoding;
            public override Encoding Encoding { get { return encoding; } }
            public StringWriterWithEncoding(Encoding Encoding) { encoding = Encoding; }
        }
    }
}
