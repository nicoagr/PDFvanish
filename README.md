# PDFvanish
Metadata remover for PDF files
## Screenshot
![PDFVanish Screenshot](https://i.imgur.com/RkfW4RR.png)
## Premise
Everytime a PDF file is generated, wichever program generated the file will leave a trail of metadata behind. That is: The creation date, the user that created the file, the title of the local file, the application name, and much more...

The aim of this application is to provide a layer of privacy.

Well, and how is that achieved? The open-source application provided here in itself does not have any "special" tricks. The dirty part is in the library that is generating the PDF file. All libraries out there leave a mark, and so, go against this application philosophy. So, this app uses a (custom) modified open-source library to achieve its goals. There are some open-source proyects where its license allows it for modifications. One of them is [itextsharp](https://github.com/itext/itextsharp/) by itext. In that project, specifically, [this](https://github.com/itext/itextsharp/blob/633699c65df566d9cde1c6013d9739f595498c88/src/core/iTextSharp/text/pdf/PdfDocument.cs#L162), [this](https://github.com/itext/itextsharp/blob/633699c65df566d9cde1c6013d9739f595498c88/src/core/iTextSharp/text/pdf/PdfDocument.cs#L172) and [this](https://github.com/itext/itextsharp/blob/633699c65df566d9cde1c6013d9739f595498c88/src/core/iTextSharp/text/pdf/PdfDocument.cs#L173) line were modified. The compiled version of the modified library can be found in the Resources folder ([here](https://github.com/nicoagr/PDFvanish/blob/master/PDFvanish/Resources/itextsharp.dll))
## Application Download
It's a portable executable, with no install needed. Download Link:
> Windows 7,8,10,11 : https://github.com/nicoagr/PDFvanish/releases/latest/download/PDFVanish.zip

The program should also work fine in Linux systems with the WINE emulation layer.
### Legal
*This proyect DOES have an "open-source license". If you want to know more about open-source licenses, click [here](https://opensource.org/faq). If you want to know more about the "open-source" GNU GPLv3  license, click [here](https://choosealicense.com/licenses/gpl-3.0/).*
