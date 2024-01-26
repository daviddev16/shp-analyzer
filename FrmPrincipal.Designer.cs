

partial class FrmPrincipal
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.txBxDiretorio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsBxArquivos = new System.Windows.Forms.ListBox();
            this.chckBxSubPasta = new System.Windows.Forms.CheckBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txProgresso = new System.Windows.Forms.Label();
            this.btnExcluirSelecionado = new System.Windows.Forms.Button();
            this.btnExcluirTodos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txBxDiretorio
            // 
            this.txBxDiretorio.Location = new System.Drawing.Point(12, 30);
            this.txBxDiretorio.Name = "txBxDiretorio";
            this.txBxDiretorio.Size = new System.Drawing.Size(320, 20);
            this.txBxDiretorio.TabIndex = 0;
            this.txBxDiretorio.DoubleClick += new System.EventHandler(this.txBxDiretorio_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Diretório para análise:";
            // 
            // lsBxArquivos
            // 
            this.lsBxArquivos.FormattingEnabled = true;
            this.lsBxArquivos.Location = new System.Drawing.Point(12, 57);
            this.lsBxArquivos.Name = "lsBxArquivos";
            this.lsBxArquivos.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lsBxArquivos.Size = new System.Drawing.Size(556, 186);
            this.lsBxArquivos.TabIndex = 2;
            // 
            // chckBxSubPasta
            // 
            this.chckBxSubPasta.AutoSize = true;
            this.chckBxSubPasta.Checked = true;
            this.chckBxSubPasta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chckBxSubPasta.Location = new System.Drawing.Point(338, 32);
            this.chckBxSubPasta.Name = "chckBxSubPasta";
            this.chckBxSubPasta.Size = new System.Drawing.Size(131, 17);
            this.chckBxSubPasta.TabIndex = 3;
            this.chckBxSubPasta.Text = "Escanear sub-pastas?";
            this.chckBxSubPasta.UseVisualStyleBackColor = true;
            // 
            // btnIniciar
            // 
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Location = new System.Drawing.Point(493, 28);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 4;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // txProgresso
            // 
            this.txProgresso.Location = new System.Drawing.Point(12, 254);
            this.txProgresso.Name = "txProgresso";
            this.txProgresso.Size = new System.Drawing.Size(320, 13);
            this.txProgresso.TabIndex = 5;
            this.txProgresso.UseWaitCursor = true;
            // 
            // btnExcluirSelecionado
            // 
            this.btnExcluirSelecionado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirSelecionado.Location = new System.Drawing.Point(455, 249);
            this.btnExcluirSelecionado.Name = "btnExcluirSelecionado";
            this.btnExcluirSelecionado.Size = new System.Drawing.Size(113, 23);
            this.btnExcluirSelecionado.TabIndex = 6;
            this.btnExcluirSelecionado.Text = "Excluir selecionado";
            this.btnExcluirSelecionado.UseVisualStyleBackColor = true;
            this.btnExcluirSelecionado.Click += new System.EventHandler(this.btnExcluirSelecionado_Click);
            // 
            // btnExcluirTodos
            // 
            this.btnExcluirTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluirTodos.Location = new System.Drawing.Point(338, 249);
            this.btnExcluirTodos.Name = "btnExcluirTodos";
            this.btnExcluirTodos.Size = new System.Drawing.Size(113, 23);
            this.btnExcluirTodos.TabIndex = 7;
            this.btnExcluirTodos.Text = "Excluir todos";
            this.btnExcluirTodos.UseVisualStyleBackColor = true;
            this.btnExcluirTodos.Click += new System.EventHandler(this.btnExcluirTodos_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 284);
            this.Controls.Add(this.btnExcluirTodos);
            this.Controls.Add(this.btnExcluirSelecionado);
            this.Controls.Add(this.txProgresso);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.chckBxSubPasta);
            this.Controls.Add(this.lsBxArquivos);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txBxDiretorio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.RightToLeftLayout = true;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "shp-analyzer 2.0";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox txBxDiretorio;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ListBox lsBxArquivos;
    private System.Windows.Forms.CheckBox chckBxSubPasta;
    private System.Windows.Forms.Button btnIniciar;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private System.Windows.Forms.Label txProgresso;
    private System.Windows.Forms.Button btnExcluirSelecionado;
    private System.Windows.Forms.Button btnExcluirTodos;
}