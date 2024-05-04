using System;
using System.IO;
using OfficeOpenXml;

public class GerarRelatorio
{
    public static void Relatorio(int linha, string divergencia, string dadoPortal, string dadoERP)
    {
        // Caminho do Relatório
        string caminhoRelatorio = "..\\..\\..\\archive\\generated\\Relatorio.xlsx";

        using (var packageRelatorio = new ExcelPackage(new FileInfo(caminhoRelatorio)))
        {
            // Verifica se o arquivo existe
            ExcelWorksheet worksheet = packageRelatorio.Workbook.Worksheets.FirstOrDefault();

            if (worksheet == null)
            {
                // Nomeia a planilha
                worksheet = packageRelatorio.Workbook.Worksheets.Add("Relatório");

                // Insere um cabeçalho
                worksheet.Cells[1, 1].Value = "Linha";
                worksheet.Cells[1, 2].Value = "Divergência";
                worksheet.Cells[1, 3].Value = "Dado Portal";
                worksheet.Cells[1, 4].Value = "Dado ERP";
            }

            int proximaLinha = worksheet.Dimension?.Rows ?? 1;

            // Adiciona os dados
            worksheet.Cells[proximaLinha + 1, 1].Value = linha;
            worksheet.Cells[proximaLinha + 1, 2].Value = divergencia;
            worksheet.Cells[proximaLinha + 1, 3].Value = (dadoPortal == "0" || string.IsNullOrEmpty(dadoPortal) || dadoPortal == "R$ 0,00") ? "-" : dadoPortal;
            worksheet.Cells[proximaLinha + 1, 4].Value = (dadoERP == "0" || string.IsNullOrEmpty(dadoERP) || dadoERP == "R$ 0,00") ? "-" : dadoERP;



            // Salva o arquivo
            packageRelatorio.Save();
        }
    }
}
