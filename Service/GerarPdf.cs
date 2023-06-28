using System.IO;
using System.Reflection.Metadata;
using iTextSharp.text;
using iTextSharp.text.pdf;
using web_api_min.Models;

public class GerarPdf
{
    public static void GerarPDFAluno(AlunoModel aluno)
    {
         iTextSharp.text.Document doc = new iTextSharp.text.Document();

        // Definição do caminho e nome do arquivo PDF gerado
        string filePath = "C:/TestePDF/Certificao.pdf";

        // Criação do objeto PDFWriter para escrever no documento
        PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));

        // Abertura do documento
        doc.Open();

        // Adicionar logo ou imagem
        iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("C:/TestePDF/logo/logoCertificado.png");
        logo.Alignment = Element.ALIGN_CENTER;
        doc.Add(logo);

        // Adicionar título
        Paragraph titulo = new Paragraph("Certificado", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 24, iTextSharp.text.Font.BOLD, BaseColor.BLACK));
        titulo.Alignment = Element.ALIGN_CENTER;
        doc.Add(titulo);

        // Adicionar informações do aluno
        Paragraph alunoInfo = new Paragraph();
        alunoInfo.Alignment = Element.ALIGN_LEFT;
        alunoInfo.Add($"Nome: {aluno.Nome}\n");
        alunoInfo.Add($"Matrícula: {aluno.Matricula}\n");
        alunoInfo.Add($"Notas: {aluno.Notas}\n");
        alunoInfo.Add($"Média: {aluno.Media}\n");
        alunoInfo.Add($"Situação: {aluno.Situacao}\n");
        doc.Add(alunoInfo);

        // Adicionar texto adicional
        Paragraph textoAdicional = new Paragraph("Parabéns pela conclusão do curso!", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.DARK_GRAY));
        textoAdicional.Alignment = Element.ALIGN_CENTER;
        textoAdicional.SpacingBefore = 20f;
        textoAdicional.SpacingAfter = 20f;
        doc.Add(textoAdicional);

        // Fechamento do documento
        doc.Close();

    }
   
}
