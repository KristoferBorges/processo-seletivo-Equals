using OfficeOpenXml;
using System;

public class Analise
{
	public static void Planilhas()
    {
        // Caminhos relativos para os arquivos
        string caminhoPortal = "..\\..\\..\\archive\\received\\VendasPortal.xlsx";
        string caminhoERP = "..\\..\\..\\archive\\received\\VendasERP.xlsx";
        int maxRow = 0;
        int divergencias = 0;


        using (var packageVendasPortal = new ExcelPackage(new FileInfo(caminhoPortal)))
        {
            using (var packageVendasERP = new ExcelPackage(new FileInfo(caminhoERP)))
            {
                // Teste para saber se o arquivo foi achado
                if (packageVendasPortal.Workbook.Worksheets.Count == 0 || packageVendasERP.Workbook.Worksheets.Count == 0)
                {
                    Console.WriteLine("[AVISO] Planilhas não encontradas!");
                    return;
                }
                else
                {
                    Console.WriteLine("[INFO] Planilhas encontradas!");
                }

                // Coleta a primeira planilha de cada arquivo
                ExcelWorksheet worksheetPortal = packageVendasPortal.Workbook.Worksheets[0];
                ExcelWorksheet worksheetERP = packageVendasERP.Workbook.Worksheets[0];

                // Coleta de informações importantes
                int totalLinhasPortal = worksheetPortal.Dimension.End.Row;
                int totalLinhasERP = worksheetERP.Dimension.End.Row;
                Console.WriteLine($"[INFO] TOTAL DE LINHAS NO ARQUIVO (VendasPortal): {totalLinhasPortal}");
                Console.WriteLine($"[INFO] TOTAL DE LINHAS NO ARQUIVO (VendasERP): {totalLinhasERP})\n");

                if (totalLinhasPortal > totalLinhasERP)
                {
                    maxRow = totalLinhasPortal;
                }
                else
                {
                    maxRow = totalLinhasERP;
                }
                // Comparando as planilhas
                for (int row = 2; row <= maxRow; row++)
                {
                    // Coleta de informações (VendasPortal)
                    string dataPortal = worksheetPortal.Cells[row, 1].Text;
                    int parcelasPortal = Convert.ToInt32(worksheetPortal.Cells[row, 2].Value);
                    int nsuPortal = Convert.ToInt32(worksheetPortal.Cells[row, 3].Value);
                    double autorizacaoPortal = Convert.ToInt32(worksheetPortal.Cells[row, 4].Value);
                    double valorPortal = Convert.ToDouble(worksheetPortal.Cells[row, 5].Value);

                    // Coleta de informações (VendasERP)
                    string dataERP = worksheetERP.Cells[row, 1].Text;
                    int parcelasERP = Convert.ToInt32(worksheetERP.Cells[row, 2].Value);
                    int nsuERP = Convert.ToInt32(worksheetERP.Cells[row, 3].Value);
                    double autorizacaoERP = Convert.ToInt32(worksheetERP.Cells[row, 4].Value);
                    double valorERP = Convert.ToDouble(worksheetERP.Cells[row, 5].Value);

                    // Comparação total

                    // Comparação unitária
                    if (dataPortal != dataERP)
                    {
                        Console.WriteLine($"[INFO] Divergência encontrada na linha {row}");
                        GerarRelatorio.Relatorio(row, "Datas", dataPortal, dataERP);
                        divergencias++;
                    }
                    if (parcelasPortal != parcelasERP)
                    {
                        Console.WriteLine($"[INFO] Divergência encontrada na linha {row}");
                        GerarRelatorio.Relatorio(row, "Parcelas", parcelasPortal.ToString(), parcelasERP.ToString());
                        divergencias++;
                    }
                    if (nsuPortal != nsuERP)
                    {
                        Console.WriteLine($"[INFO] Divergência encontrada na linha {row}");
                        GerarRelatorio.Relatorio(row, "NSU", nsuPortal.ToString(), nsuERP.ToString());
                        divergencias++;
                    }
                    if (autorizacaoPortal != autorizacaoERP)
                    {
                        Console.WriteLine($"[INFO] Divergência encontrada na linha {row}");
                        GerarRelatorio.Relatorio(row, "Autorizações", autorizacaoPortal.ToString(), autorizacaoERP.ToString());
                        divergencias++;
                    }
                    if (valorPortal != valorERP)
                    {
                        Console.WriteLine($"[INFO] Divergência encontrada na linha {row}");
                        GerarRelatorio.Relatorio(row, "Valores", valorPortal.ToString("C"), valorERP.ToString("C"));
                        divergencias++;
                    }
                }
            }
        }

        Console.WriteLine($"\n[INFO] Divergências de dados encontradas: [{divergencias}]\n");

    }
}
