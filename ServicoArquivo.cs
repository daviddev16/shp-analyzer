using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.IO.Compression;
using System.ComponentModel;

public sealed class ServicoArquivo
{
    private string[] bloquearCaminhos = 
    {
        @"C:\",
        @"C:\Users",
        @"C:\Windows",
        @"C:\Program Files",
        @"C:\Program Files (x86)",
        @"C:\ProgramData"
    };

    public struct DadosPesquisaArquivo
    {
        public string Diretorio;
        public string Extensao;
        public bool ScanSubPastas;
    };

    public struct OperacaoProgresso
    {
        public string arquivoPath;
        public bool finalizado;
        public int totalArquivosProcessados;
        public int totalArquivosCorrompidos;
        public int totalArquivos;
    }

    class ServicoException : Exception
    {
        public ServicoException(string message) : base(message) { }
    };

    private string[] ObterArquivos(in DadosPesquisaArquivo dadosPesquisa)
    {

        if (!Directory.Exists(dadosPesquisa.Diretorio))
            throw new ServicoException("Diretório inválido.");

        foreach (string caminhoBloqueado in bloquearCaminhos)
        {
            if (dadosPesquisa.Diretorio.Equals(caminhoBloqueado, StringComparison.OrdinalIgnoreCase))
            {
                throw new ServicoException(string.Format("O caminho '{0}' é restrito de ser usado diretamente.", caminhoBloqueado));
            }
        }

        SearchOption searchOption = dadosPesquisa.ScanSubPastas ? (SearchOption.AllDirectories) : 
            (SearchOption.TopDirectoryOnly);
        
        string searchPattern = string.IsNullOrWhiteSpace(dadosPesquisa.Extensao) ? ("*") : 
            ("*." + dadosPesquisa.Extensao);

        return Directory.GetFiles(dadosPesquisa.Diretorio, searchPattern, searchOption);
    }
    public List<string> EncontrarArquivosCorrompidos(in DadosPesquisaArquivo dadosPesquisa, 
                                             ref BackgroundWorker backgroundWorker)
    {
        string[] arquivosListados = ObterArquivos(dadosPesquisa);

        List<string> arquivosCorrompidos = new List<string>();
        OperacaoProgresso operacaoProgresso = new OperacaoProgresso();
        
        operacaoProgresso.totalArquivos = arquivosListados.Length;

        foreach (string pathArquivo in arquivosListados)
        {
            operacaoProgresso.totalArquivosProcessados++;

            double porcentagem = (double)operacaoProgresso.totalArquivosProcessados / operacaoProgresso.totalArquivos;

            //Application.DoEvents();

            if (!ConsegueAbrirZip(pathArquivo))
            {
                arquivosCorrompidos.Add(pathArquivo);
                operacaoProgresso.totalArquivosCorrompidos++;
            }

            backgroundWorker.ReportProgress((int)(porcentagem * 100) - 1, 
                string.Format("[Validando]: {0}", ObterNomeBonito(pathArquivo)));
        }

        string mensagem = string.Format("[Info]: Total: {0:D4}, Processados: {1:D4}, Corrompidos: {2:D4}.", 
            operacaoProgresso.totalArquivos, operacaoProgresso.totalArquivosProcessados, operacaoProgresso.totalArquivosCorrompidos);

        backgroundWorker.ReportProgress(100, mensagem);

        return arquivosCorrompidos;

    }

    private string ObterNomeBonito(string pathArquivo)
    {
        return Path.GetFileName(pathArquivo);
    }

    private static bool ConsegueAbrirZip(string pathArquivo)
    {
        try
        {
            ZipArchive archive = ZipFile.OpenRead(pathArquivo);
            archive.Dispose();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
