using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;

public partial class FrmPrincipal : Form
{

    private readonly ServicoArquivo servicoArquivo;

    public FrmPrincipal()
    {
        servicoArquivo = new ServicoArquivo();
        InitializeComponent();
    }

    private void FrmPrincipal_Load(object sender, EventArgs e)
    {
        backgroundWorker1.WorkerReportsProgress = true;
        CenterToScreen();
    }

    private void btnIniciar_Click(object sender, EventArgs e)
    {
        if (!backgroundWorker1.IsBusy)
            backgroundWorker1.RunWorkerAsync();
    }

    void FinalizacaoEventHandler(string[] arquivosEncontrados)
    {
        Console.WriteLine(arquivosEncontrados);
    }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs eventArgs)
    {

        ServicoArquivo.DadosPesquisaArquivo dadosPesquisa = new ServicoArquivo.DadosPesquisaArquivo();

        /* PROPRIEDADES DA PESQUISA */

        dadosPesquisa.Diretorio = txBxDiretorio.Text;
        dadosPesquisa.Extensao = "shp";
        dadosPesquisa.ScanSubPastas = chckBxSubPasta.Checked;

        List<string> arquivosCorrompidos = servicoArquivo
            .EncontrarArquivosCorrompidos(dadosPesquisa, ref backgroundWorker1);

        eventArgs.Result = arquivosCorrompidos;
    }

    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        txProgresso.Text = (string)e.UserState; 
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        try
        {
            List<string> arquivosCorrompidos = (List<string>)e.Result;
            lsBxArquivos.Items.Clear();
            foreach (string arquivoCorrompidoPath in arquivosCorrompidos)
            {
                lsBxArquivos.Items.Add(arquivoCorrompidoPath);
            }

        }
        catch (Exception ex)
        {
            Exception causa = ex;
            
            if (ex.InnerException != null)
                causa = ex.InnerException;

            MessageBox.Show(string.Format("Houve um problema no processamento dos " +
                "arquivos corrompidos. \n\nCausa: {0}\nMensagem: {1}", causa.GetType().Name, causa.Message), 
                "Erro interno", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    private void btnExcluirTodos_Click(object sender, EventArgs e)
    {
        if (lsBxArquivos.Items.Count <= 0)
        {
            MessageBox.Show("Não há arquivos.");
            return;
        }

        DialogResult resultado = MessageBox.Show("Confirmar exclusão de todos os arquivos?",
            "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (resultado != DialogResult.Yes)
        {
            MessageBox.Show("Cancelado.");
            return;
        }

        foreach (string pathArquivo in lsBxArquivos.Items)
        {
            if (File.Exists(pathArquivo))
            {
                try
                {
                    /* garantia extra que apenas será excluir .shp */
                    if (pathArquivo.EndsWith(".shp"))
                    {
                        File.Delete(pathArquivo);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir o arquivo: {ex.Message}", "Erro de Exclusão",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        lsBxArquivos.Items.Clear();
        lsBxArquivos.Update();
        MessageBox.Show("Arquivos excluídos com sucesso.", "Exclusão Concluída",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnExcluirSelecionado_Click(object sender, EventArgs e)
    {
        if (lsBxArquivos.Items.Count <= 0)
        {
            MessageBox.Show("Não há arquivos.");
            return;
        }

        if (lsBxArquivos.SelectedItem == null)
        {
            MessageBox.Show("Nenhum arquivo foi selecionado.");
            return;
        }

        string pathArquivo = (string)lsBxArquivos.SelectedItem;

        DialogResult resultado = MessageBox.Show(String.Format("Confirmar exclusão de '{0}' os arquivos?", pathArquivo),
            "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (resultado != DialogResult.Yes)
        {
            MessageBox.Show("Cancelado.");
            return;
        }

        if (File.Exists(pathArquivo))
        {
            try
            {
                /* garantia extra que apenas será excluir .shp */
                if (pathArquivo.EndsWith(".shp"))
                {
                    File.Delete(pathArquivo);
                }
                lsBxArquivos.Items.Remove(pathArquivo);
                lsBxArquivos.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir o arquivo: {ex.Message}", "Erro de Exclusão",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    private void txBxDiretorio_DoubleClick(object sender, EventArgs e)
    {
        FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
        if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            string selectedFolderPath = folderBrowserDialog.SelectedPath;
            txBxDiretorio.Text = selectedFolderPath;
        }
    }
}
