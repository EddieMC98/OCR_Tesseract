# OCR_Tesseract

Repositorio que contiene la biblioteca Tesseract, para el escaneo de cheques a texto.

-- Requerimientos
Instalar Tesseract en el Administrador de Paquetes Nuget.
Descarga de los paquetes del lenguaje Español: https://github.com/tesseract-ocr/tessdata
Descargar los archivos con los nombres
* spa.traineddata
* spa_old.traineddata

o haciendo click en los siguientes enlaces
* https://github.com/tesseract-ocr/tessdata/blob/main/spa.traineddata
* https://github.com/tesseract-ocr/tessdata/blob/main/spa_old.traineddata

Crear una nueva carpeta dentro del proyecto con el nombre "tessdata" y añadir los archvos descargados

-- Implementación
Se añade una nueva referencia al proyecto que se desee, la cuál es el archivo OCR.dll

-- Utilización y Comandos
   OCR.Class1 hola = new OCR.Class1();                // Creación de una nueva instancia
   var name = hola.ObtenerTexto(nombre_imagen, Directory.GetCurrentDirectory()+"\\tessdata\\");         // Almacenar en una variable "name" el texto devuelto, "nombre_imagen" es representantivo de la ruta absoluta de la imagen a escanear, mientras que el segundo parámetro hace referencia a la ruta dónde se encuentran los paquetes del lenguaje español.
   Console.WriteLine(name); // Impresión del resultado
