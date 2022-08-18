namespace service_manager
{
    partial class frm_PainelPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_PainelPrincipal));
            this.lvw_Servicos = new System.Windows.Forms.ListView();
            this.Serviço = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txb_Pesquisar = new System.Windows.Forms.TextBox();
            this.lvw_BuscaRapida = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ckb_ComecaCom = new System.Windows.Forms.CheckBox();
            this.ckb_Contem = new System.Windows.Forms.CheckBox();
            this.lbl_TotalServicos = new System.Windows.Forms.Label();
            this.lbl_SelecioneUmItem = new System.Windows.Forms.Label();
            this.ckb_Automatico = new System.Windows.Forms.CheckBox();
            this.gpb_Pesquisa = new System.Windows.Forms.GroupBox();
            this.btn_Atualizar = new System.Windows.Forms.Button();
            this.ckb_Destacar = new System.Windows.Forms.CheckBox();
            this.btn_Pesquisar = new System.Windows.Forms.Button();
            this.gpb_Executar = new System.Windows.Forms.GroupBox();
            this.btn_Deletar = new System.Windows.Forms.Button();
            this.btn_Reiniciar = new System.Windows.Forms.Button();
            this.btn_Pausar = new System.Windows.Forms.Button();
            this.btn_Iniciar = new System.Windows.Forms.Button();
            this.btn_Parar = new System.Windows.Forms.Button();
            this.gpb_BuscaRapida = new System.Windows.Forms.GroupBox();
            this.txb_BuscaRapida = new System.Windows.Forms.TextBox();
            this.btn_DeletarBuscaRapida = new System.Windows.Forms.Button();
            this.btn_AdicionarBuscaRapida = new System.Windows.Forms.Button();
            this.ckb_SelecionarTodos = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gpb_Conectar = new System.Windows.Forms.GroupBox();
            this.lbl_IndicadorStatusConexao = new System.Windows.Forms.Label();
            this.btn_Conectar = new System.Windows.Forms.Button();
            this.txb_Conectar = new System.Windows.Forms.TextBox();
            this.gpb_Pesquisa.SuspendLayout();
            this.gpb_Executar.SuspendLayout();
            this.gpb_BuscaRapida.SuspendLayout();
            this.gpb_Conectar.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvw_Servicos
            // 
            this.lvw_Servicos.BackColor = System.Drawing.Color.White;
            this.lvw_Servicos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Serviço,
            this.Status,
            this.Nome});
            this.lvw_Servicos.HideSelection = false;
            this.lvw_Servicos.Location = new System.Drawing.Point(6, 165);
            this.lvw_Servicos.Name = "lvw_Servicos";
            this.lvw_Servicos.Size = new System.Drawing.Size(711, 418);
            this.lvw_Servicos.TabIndex = 0;
            this.lvw_Servicos.UseCompatibleStateImageBehavior = false;
            // 
            // Serviço
            // 
            this.Serviço.Text = "Serviço";
            this.Serviço.Width = 350;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 100;
            // 
            // Nome
            // 
            this.Nome.Text = "Nome";
            this.Nome.Width = 250;
            // 
            // txb_Pesquisar
            // 
            this.txb_Pesquisar.Location = new System.Drawing.Point(8, 53);
            this.txb_Pesquisar.Name = "txb_Pesquisar";
            this.txb_Pesquisar.Size = new System.Drawing.Size(320, 20);
            this.txb_Pesquisar.TabIndex = 4;
            this.txb_Pesquisar.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lvw_BuscaRapida
            // 
            this.lvw_BuscaRapida.BackColor = System.Drawing.Color.White;
            this.lvw_BuscaRapida.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvw_BuscaRapida.HideSelection = false;
            this.lvw_BuscaRapida.Location = new System.Drawing.Point(724, 229);
            this.lvw_BuscaRapida.Name = "lvw_BuscaRapida";
            this.lvw_BuscaRapida.Size = new System.Drawing.Size(154, 354);
            this.lvw_BuscaRapida.TabIndex = 5;
            this.lvw_BuscaRapida.UseCompatibleStateImageBehavior = false;
            this.lvw_BuscaRapida.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Buscas";
            this.columnHeader1.Width = 150;
            // 
            // ckb_ComecaCom
            // 
            this.ckb_ComecaCom.AutoSize = true;
            this.ckb_ComecaCom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ckb_ComecaCom.Location = new System.Drawing.Point(177, 80);
            this.ckb_ComecaCom.Name = "ckb_ComecaCom";
            this.ckb_ComecaCom.Size = new System.Drawing.Size(88, 17);
            this.ckb_ComecaCom.TabIndex = 2;
            this.ckb_ComecaCom.Text = "Começa com";
            this.ckb_ComecaCom.UseVisualStyleBackColor = true;
            this.ckb_ComecaCom.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ckb_Contem
            // 
            this.ckb_Contem.AutoSize = true;
            this.ckb_Contem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ckb_Contem.Location = new System.Drawing.Point(271, 80);
            this.ckb_Contem.Name = "ckb_Contem";
            this.ckb_Contem.Size = new System.Drawing.Size(62, 17);
            this.ckb_Contem.TabIndex = 3;
            this.ckb_Contem.Text = "Contém";
            this.ckb_Contem.UseVisualStyleBackColor = true;
            this.ckb_Contem.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // lbl_TotalServicos
            // 
            this.lbl_TotalServicos.AutoSize = true;
            this.lbl_TotalServicos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_TotalServicos.Location = new System.Drawing.Point(117, 143);
            this.lbl_TotalServicos.Name = "lbl_TotalServicos";
            this.lbl_TotalServicos.Size = new System.Drawing.Size(35, 13);
            this.lbl_TotalServicos.TabIndex = 9;
            this.lbl_TotalServicos.Text = "label1";
            // 
            // lbl_SelecioneUmItem
            // 
            this.lbl_SelecioneUmItem.AutoSize = true;
            this.lbl_SelecioneUmItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_SelecioneUmItem.Location = new System.Drawing.Point(721, 213);
            this.lbl_SelecioneUmItem.Name = "lbl_SelecioneUmItem";
            this.lbl_SelecioneUmItem.Size = new System.Drawing.Size(96, 13);
            this.lbl_SelecioneUmItem.TabIndex = 10;
            this.lbl_SelecioneUmItem.Text = "Selecione um item:";
            // 
            // ckb_Automatico
            // 
            this.ckb_Automatico.AutoSize = true;
            this.ckb_Automatico.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ckb_Automatico.Location = new System.Drawing.Point(8, 30);
            this.ckb_Automatico.Name = "ckb_Automatico";
            this.ckb_Automatico.Size = new System.Drawing.Size(79, 17);
            this.ckb_Automatico.TabIndex = 0;
            this.ckb_Automatico.Text = "Automática";
            this.toolTip1.SetToolTip(this.ckb_Automatico, "Ative para realizar a pesquisa sem a necessidade do botão buscar.");
            this.ckb_Automatico.UseVisualStyleBackColor = true;
            this.ckb_Automatico.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // gpb_Pesquisa
            // 
            this.gpb_Pesquisa.BackColor = System.Drawing.Color.White;
            this.gpb_Pesquisa.Controls.Add(this.btn_Atualizar);
            this.gpb_Pesquisa.Controls.Add(this.ckb_Destacar);
            this.gpb_Pesquisa.Controls.Add(this.ckb_Automatico);
            this.gpb_Pesquisa.Controls.Add(this.btn_Pesquisar);
            this.gpb_Pesquisa.Controls.Add(this.ckb_Contem);
            this.gpb_Pesquisa.Controls.Add(this.ckb_ComecaCom);
            this.gpb_Pesquisa.Controls.Add(this.txb_Pesquisar);
            this.gpb_Pesquisa.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gpb_Pesquisa.Location = new System.Drawing.Point(7, 10);
            this.gpb_Pesquisa.Name = "gpb_Pesquisa";
            this.gpb_Pesquisa.Size = new System.Drawing.Size(433, 118);
            this.gpb_Pesquisa.TabIndex = 13;
            this.gpb_Pesquisa.TabStop = false;
            this.gpb_Pesquisa.Text = "Pesquisa";
            // 
            // btn_Atualizar
            // 
            this.btn_Atualizar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btn_Atualizar.Image = global::service_manager.Properties.Resources.refresh002;
            this.btn_Atualizar.Location = new System.Drawing.Point(384, 30);
            this.btn_Atualizar.Name = "btn_Atualizar";
            this.btn_Atualizar.Size = new System.Drawing.Size(43, 67);
            this.btn_Atualizar.TabIndex = 6;
            this.toolTip1.SetToolTip(this.btn_Atualizar, "Atualizar tabela");
            this.btn_Atualizar.UseVisualStyleBackColor = true;
            this.btn_Atualizar.Click += new System.EventHandler(this.button9_Click);
            // 
            // ckb_Destacar
            // 
            this.ckb_Destacar.AutoSize = true;
            this.ckb_Destacar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ckb_Destacar.Location = new System.Drawing.Point(93, 30);
            this.ckb_Destacar.Name = "ckb_Destacar";
            this.ckb_Destacar.Size = new System.Drawing.Size(69, 17);
            this.ckb_Destacar.TabIndex = 1;
            this.ckb_Destacar.Text = "Destacar";
            this.toolTip1.SetToolTip(this.ckb_Destacar, "Facilita a visibilidade do status dos serviços");
            this.ckb_Destacar.UseVisualStyleBackColor = true;
            this.ckb_Destacar.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // btn_Pesquisar
            // 
            this.btn_Pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pesquisar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Pesquisar.Image = global::service_manager.Properties.Resources.lupa;
            this.btn_Pesquisar.Location = new System.Drawing.Point(334, 30);
            this.btn_Pesquisar.Name = "btn_Pesquisar";
            this.btn_Pesquisar.Size = new System.Drawing.Size(44, 67);
            this.btn_Pesquisar.TabIndex = 5;
            this.toolTip1.SetToolTip(this.btn_Pesquisar, "Buscar");
            this.btn_Pesquisar.UseVisualStyleBackColor = true;
            this.btn_Pesquisar.Click += new System.EventHandler(this.button4_Click);
            // 
            // gpb_Executar
            // 
            this.gpb_Executar.BackColor = System.Drawing.Color.White;
            this.gpb_Executar.Controls.Add(this.btn_Deletar);
            this.gpb_Executar.Controls.Add(this.btn_Reiniciar);
            this.gpb_Executar.Controls.Add(this.btn_Pausar);
            this.gpb_Executar.Controls.Add(this.btn_Iniciar);
            this.gpb_Executar.Controls.Add(this.btn_Parar);
            this.gpb_Executar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gpb_Executar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gpb_Executar.Location = new System.Drawing.Point(453, 10);
            this.gpb_Executar.Name = "gpb_Executar";
            this.gpb_Executar.Size = new System.Drawing.Size(264, 117);
            this.gpb_Executar.TabIndex = 14;
            this.gpb_Executar.TabStop = false;
            this.gpb_Executar.Text = "Executar";
            // 
            // btn_Deletar
            // 
            this.btn_Deletar.AccessibleDescription = "Reiniciar";
            this.btn_Deletar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Deletar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Deletar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Deletar.Image = global::service_manager.Properties.Resources.delete;
            this.btn_Deletar.Location = new System.Drawing.Point(212, 19);
            this.btn_Deletar.Name = "btn_Deletar";
            this.btn_Deletar.Size = new System.Drawing.Size(45, 92);
            this.btn_Deletar.TabIndex = 11;
            this.toolTip1.SetToolTip(this.btn_Deletar, "Deletar");
            this.btn_Deletar.UseVisualStyleBackColor = false;
            this.btn_Deletar.Click += new System.EventHandler(this.button10_Click);
            // 
            // btn_Reiniciar
            // 
            this.btn_Reiniciar.AccessibleDescription = "Reiniciar";
            this.btn_Reiniciar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Reiniciar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Reiniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Reiniciar.Image = global::service_manager.Properties.Resources.refresh;
            this.btn_Reiniciar.Location = new System.Drawing.Point(161, 19);
            this.btn_Reiniciar.Name = "btn_Reiniciar";
            this.btn_Reiniciar.Size = new System.Drawing.Size(45, 92);
            this.btn_Reiniciar.TabIndex = 10;
            this.toolTip1.SetToolTip(this.btn_Reiniciar, "Reiniciar");
            this.btn_Reiniciar.UseVisualStyleBackColor = false;
            this.btn_Reiniciar.Click += new System.EventHandler(this.button7_Click);
            // 
            // btn_Pausar
            // 
            this.btn_Pausar.AccessibleDescription = "Pausar";
            this.btn_Pausar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Pausar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Pausar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Pausar.Image = global::service_manager.Properties.Resources.pause_button;
            this.btn_Pausar.Location = new System.Drawing.Point(110, 19);
            this.btn_Pausar.Name = "btn_Pausar";
            this.btn_Pausar.Size = new System.Drawing.Size(45, 92);
            this.btn_Pausar.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btn_Pausar, "Pausar");
            this.btn_Pausar.UseVisualStyleBackColor = false;
            this.btn_Pausar.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_Iniciar
            // 
            this.btn_Iniciar.AccessibleDescription = "Iniciar";
            this.btn_Iniciar.AccessibleName = "Iniciar";
            this.btn_Iniciar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Iniciar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Iniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Iniciar.Image = global::service_manager.Properties.Resources.power;
            this.btn_Iniciar.Location = new System.Drawing.Point(7, 19);
            this.btn_Iniciar.Name = "btn_Iniciar";
            this.btn_Iniciar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_Iniciar.Size = new System.Drawing.Size(46, 92);
            this.btn_Iniciar.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btn_Iniciar, "Iniciar");
            this.btn_Iniciar.UseMnemonic = false;
            this.btn_Iniciar.UseVisualStyleBackColor = false;
            this.btn_Iniciar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_Parar
            // 
            this.btn_Parar.AccessibleDescription = "Parar";
            this.btn_Parar.AutoEllipsis = true;
            this.btn_Parar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Parar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Parar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Parar.Image = global::service_manager.Properties.Resources.stop_button;
            this.btn_Parar.Location = new System.Drawing.Point(59, 19);
            this.btn_Parar.Name = "btn_Parar";
            this.btn_Parar.Size = new System.Drawing.Size(45, 92);
            this.btn_Parar.TabIndex = 8;
            this.toolTip1.SetToolTip(this.btn_Parar, "Parar");
            this.btn_Parar.UseVisualStyleBackColor = false;
            this.btn_Parar.Click += new System.EventHandler(this.button2_Click);
            // 
            // gpb_BuscaRapida
            // 
            this.gpb_BuscaRapida.BackColor = System.Drawing.Color.White;
            this.gpb_BuscaRapida.Controls.Add(this.txb_BuscaRapida);
            this.gpb_BuscaRapida.Controls.Add(this.btn_DeletarBuscaRapida);
            this.gpb_BuscaRapida.Controls.Add(this.btn_AdicionarBuscaRapida);
            this.gpb_BuscaRapida.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gpb_BuscaRapida.Location = new System.Drawing.Point(724, 90);
            this.gpb_BuscaRapida.Name = "gpb_BuscaRapida";
            this.gpb_BuscaRapida.Size = new System.Drawing.Size(153, 118);
            this.gpb_BuscaRapida.TabIndex = 15;
            this.gpb_BuscaRapida.TabStop = false;
            this.gpb_BuscaRapida.Text = "Busca rápida";
            // 
            // txb_BuscaRapida
            // 
            this.txb_BuscaRapida.Location = new System.Drawing.Point(6, 32);
            this.txb_BuscaRapida.Name = "txb_BuscaRapida";
            this.txb_BuscaRapida.Size = new System.Drawing.Size(141, 20);
            this.txb_BuscaRapida.TabIndex = 14;
            // 
            // btn_DeletarBuscaRapida
            // 
            this.btn_DeletarBuscaRapida.BackColor = System.Drawing.Color.Transparent;
            this.btn_DeletarBuscaRapida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DeletarBuscaRapida.Location = new System.Drawing.Point(82, 63);
            this.btn_DeletarBuscaRapida.Name = "btn_DeletarBuscaRapida";
            this.btn_DeletarBuscaRapida.Size = new System.Drawing.Size(65, 23);
            this.btn_DeletarBuscaRapida.TabIndex = 16;
            this.btn_DeletarBuscaRapida.Text = "Remover";
            this.toolTip1.SetToolTip(this.btn_DeletarBuscaRapida, "Remover");
            this.btn_DeletarBuscaRapida.UseVisualStyleBackColor = false;
            this.btn_DeletarBuscaRapida.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_AdicionarBuscaRapida
            // 
            this.btn_AdicionarBuscaRapida.BackColor = System.Drawing.Color.Transparent;
            this.btn_AdicionarBuscaRapida.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_AdicionarBuscaRapida.Location = new System.Drawing.Point(6, 63);
            this.btn_AdicionarBuscaRapida.Name = "btn_AdicionarBuscaRapida";
            this.btn_AdicionarBuscaRapida.Size = new System.Drawing.Size(65, 23);
            this.btn_AdicionarBuscaRapida.TabIndex = 15;
            this.btn_AdicionarBuscaRapida.Text = "Adicionar";
            this.toolTip1.SetToolTip(this.btn_AdicionarBuscaRapida, "Adicionar");
            this.btn_AdicionarBuscaRapida.UseVisualStyleBackColor = false;
            this.btn_AdicionarBuscaRapida.Click += new System.EventHandler(this.button3_Click);
            // 
            // ckb_SelecionarTodos
            // 
            this.ckb_SelecionarTodos.AutoSize = true;
            this.ckb_SelecionarTodos.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ckb_SelecionarTodos.Location = new System.Drawing.Point(6, 142);
            this.ckb_SelecionarTodos.Name = "ckb_SelecionarTodos";
            this.ckb_SelecionarTodos.Size = new System.Drawing.Size(105, 17);
            this.ckb_SelecionarTodos.TabIndex = 17;
            this.ckb_SelecionarTodos.Text = "Selecionar todos";
            this.ckb_SelecionarTodos.UseVisualStyleBackColor = true;
            this.ckb_SelecionarTodos.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // gpb_Conectar
            // 
            this.gpb_Conectar.Controls.Add(this.lbl_IndicadorStatusConexao);
            this.gpb_Conectar.Controls.Add(this.btn_Conectar);
            this.gpb_Conectar.Controls.Add(this.txb_Conectar);
            this.gpb_Conectar.Location = new System.Drawing.Point(724, 10);
            this.gpb_Conectar.Name = "gpb_Conectar";
            this.gpb_Conectar.Size = new System.Drawing.Size(153, 72);
            this.gpb_Conectar.TabIndex = 17;
            this.gpb_Conectar.TabStop = false;
            this.gpb_Conectar.Text = "Conectar";
            // 
            // lbl_IndicadorStatusConexao
            // 
            this.lbl_IndicadorStatusConexao.AutoSize = true;
            this.lbl_IndicadorStatusConexao.BackColor = System.Drawing.Color.Transparent;
            this.lbl_IndicadorStatusConexao.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_IndicadorStatusConexao.Location = new System.Drawing.Point(6, -3);
            this.lbl_IndicadorStatusConexao.Name = "lbl_IndicadorStatusConexao";
            this.lbl_IndicadorStatusConexao.Size = new System.Drawing.Size(29, 42);
            this.lbl_IndicadorStatusConexao.TabIndex = 14;
            this.lbl_IndicadorStatusConexao.Text = ".";
            this.lbl_IndicadorStatusConexao.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Conectar
            // 
            this.btn_Conectar.Location = new System.Drawing.Point(82, 45);
            this.btn_Conectar.Name = "btn_Conectar";
            this.btn_Conectar.Size = new System.Drawing.Size(64, 21);
            this.btn_Conectar.TabIndex = 13;
            this.btn_Conectar.Text = "Conectar";
            this.btn_Conectar.UseVisualStyleBackColor = true;
            this.btn_Conectar.Click += new System.EventHandler(this.button8_Click);
            // 
            // txb_Conectar
            // 
            this.txb_Conectar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_Conectar.Location = new System.Drawing.Point(38, 19);
            this.txb_Conectar.Name = "txb_Conectar";
            this.txb_Conectar.Size = new System.Drawing.Size(108, 20);
            this.txb_Conectar.TabIndex = 12;
            // 
            // frm_PainelPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(885, 595);
            this.Controls.Add(this.gpb_Conectar);
            this.Controls.Add(this.ckb_SelecionarTodos);
            this.Controls.Add(this.gpb_BuscaRapida);
            this.Controls.Add(this.gpb_Executar);
            this.Controls.Add(this.gpb_Pesquisa);
            this.Controls.Add(this.lbl_SelecioneUmItem);
            this.Controls.Add(this.lbl_TotalServicos);
            this.Controls.Add(this.lvw_BuscaRapida);
            this.Controls.Add(this.lvw_Servicos);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_PainelPrincipal";
            this.Text = "Gerenciador de Serviços do Windows - por André Arruda";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gpb_Pesquisa.ResumeLayout(false);
            this.gpb_Pesquisa.PerformLayout();
            this.gpb_Executar.ResumeLayout(false);
            this.gpb_BuscaRapida.ResumeLayout(false);
            this.gpb_BuscaRapida.PerformLayout();
            this.gpb_Conectar.ResumeLayout(false);
            this.gpb_Conectar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvw_Servicos;
        private System.Windows.Forms.ColumnHeader Serviço;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.Button btn_Iniciar;
        private System.Windows.Forms.Button btn_Parar;
        private System.Windows.Forms.TextBox txb_Pesquisar;
        private System.Windows.Forms.Button btn_AdicionarBuscaRapida;
        private System.Windows.Forms.ListView lvw_BuscaRapida;
        private System.Windows.Forms.CheckBox ckb_ComecaCom;
        private System.Windows.Forms.CheckBox ckb_Contem;
        private System.Windows.Forms.Button btn_Pesquisar;
        private System.Windows.Forms.Label lbl_TotalServicos;
        private System.Windows.Forms.Label lbl_SelecioneUmItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btn_DeletarBuscaRapida;
        private System.Windows.Forms.CheckBox ckb_Automatico;
        private System.Windows.Forms.GroupBox gpb_Pesquisa;
        private System.Windows.Forms.GroupBox gpb_Executar;
        private System.Windows.Forms.GroupBox gpb_BuscaRapida;
        private System.Windows.Forms.TextBox txb_BuscaRapida;
        private System.Windows.Forms.CheckBox ckb_Destacar;
        private System.Windows.Forms.CheckBox ckb_SelecionarTodos;
        private System.Windows.Forms.Button btn_Reiniciar;
        private System.Windows.Forms.Button btn_Pausar;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox gpb_Conectar;
        private System.Windows.Forms.TextBox txb_Conectar;
        private System.Windows.Forms.Button btn_Conectar;
        private System.Windows.Forms.Button btn_Atualizar;
        private System.Windows.Forms.Button btn_Deletar;
        private System.Windows.Forms.Label lbl_IndicadorStatusConexao;
    }
}

