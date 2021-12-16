using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Tesseract;
using System.IO;
namespace OCR
{
    public class Class1
    {
        public string ObtenerTexto(string NombreImagen, string trainedDataFolderName)
        {
            var text = string.Empty;
            var texto_cheque = string.Empty;
            try
            {
                using (var engine = new TesseractEngine(trainedDataFolderName, "spa", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(NombreImagen))
                    {
                        using (var page = engine.Process(img))
                        {
                            text = page.GetText();
                            texto_cheque = Cuenta_Cheque(text);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            return texto_cheque;
        }

        public string Cuenta_Cheque(string texto)
        {
            var palabras = texto.Split("\n");
            var texto_requerido = "";
            foreach (var item in palabras)
            {
                if (item.StartsWith("Banco"))
                {
                    int found = item.IndexOf("Banco");
                    var aux = item.Substring(found + 6);
                    texto_requerido += aux + "\n";
                }
                if (item.Contains("CUENTA"))
                {
                    int found = item.IndexOf("CUENTA");
                    var aux = item.Substring(found + 10, 15);
                    texto_requerido += aux + "\n";
                }
                if (item.Contains("CHEQUE"))
                {
                    int found = item.IndexOf("CHEQUE");
                    var aux = item.Substring(found + 13, 6);
                    texto_requerido += aux + "\n";
                }
                if (item.StartsWith("GT"))
                {
                    int found = item.IndexOf("GT");
                    var aux = item.Substring(found);
                    texto_requerido += aux + "\n";
                }
            }
            texto_requerido += palabras[palabras.Length - 2].Substring(2) + "\n";
            return texto_requerido.Trim();
          
        }
    }
}
