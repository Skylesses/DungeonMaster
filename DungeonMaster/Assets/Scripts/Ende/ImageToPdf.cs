using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

public class ImageToPdf : MonoBehaviour
{
    public void SaveAsPDF()
    {
        string imgPath = Application.persistentDataPath + "/CanvasImage.png";
        string pdfPath = Application.persistentDataPath + "/CanvasOutput.pdf";

        Document document = new Document();
        PdfWriter.GetInstance(document, new FileStream(pdfPath, FileMode.Create));
        document.Open();

        iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(imgPath);
        image.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height);
        document.Add(image);

        document.Close();

        Debug.Log("PDF saved at: " + pdfPath);
    }
}
