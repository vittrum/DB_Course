namespace DB_Course
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pagePositions = new System.Windows.Forms.TabPage();
            this.pageOrders = new System.Windows.Forms.TabPage();
            this.pageTitles = new System.Windows.Forms.TabPage();
            this.groupboxTitles = new System.Windows.Forms.GroupBox();
            this.panelTitlesSelect = new System.Windows.Forms.Panel();
            this.dgvTitles = new System.Windows.Forms.DataGridView();
            this.titlename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectAllTitles = new System.Windows.Forms.Button();
            this.btnTitleChooseSelect = new System.Windows.Forms.Button();
            this.panelTitleChoose = new System.Windows.Forms.Panel();
            this.tbTitleIDorName = new System.Windows.Forms.TextBox();
            this.rbtnTitleById = new System.Windows.Forms.RadioButton();
            this.rbtnTitleByName = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddTitle = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupboxDegrees = new System.Windows.Forms.GroupBox();
            this.panelSelectDegree = new System.Windows.Forms.Panel();
            this.dgvDegrees = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSelectAllDegrees = new System.Windows.Forms.Button();
            this.btnSelectSomeDegrees = new System.Windows.Forms.Button();
            this.panelChooseDegree = new System.Windows.Forms.Panel();
            this.tbDegreeIDorName = new System.Windows.Forms.TextBox();
            this.rbtnDegreeById = new System.Windows.Forms.RadioButton();
            this.rbtnDegreeByName = new System.Windows.Forms.RadioButton();
            this.labelInputDegreeID = new System.Windows.Forms.Label();
            this.panelAddDegree = new System.Windows.Forms.Panel();
            this.btnAddDegree = new System.Windows.Forms.Button();
            this.tbAddDegree = new System.Windows.Forms.TextBox();
            this.labelAddDegree = new System.Windows.Forms.Label();
            this.pageChair = new System.Windows.Forms.TabPage();
            this.pageStaff = new System.Windows.Forms.TabPage();
            this.tabControlStaff = new System.Windows.Forms.TabControl();
            this.pageStaffOrders = new System.Windows.Forms.TabPage();
            this.pageStaffDegrees = new System.Windows.Forms.TabPage();
            this.pageStaffGeneral = new System.Windows.Forms.TabPage();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.pageTitles.SuspendLayout();
            this.groupboxTitles.SuspendLayout();
            this.panelTitlesSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).BeginInit();
            this.panelTitleChoose.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupboxDegrees.SuspendLayout();
            this.panelSelectDegree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDegrees)).BeginInit();
            this.panelChooseDegree.SuspendLayout();
            this.panelAddDegree.SuspendLayout();
            this.pageStaff.SuspendLayout();
            this.tabControlStaff.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pagePositions
            // 
            this.pagePositions.Location = new System.Drawing.Point(4, 22);
            this.pagePositions.Name = "pagePositions";
            this.pagePositions.Padding = new System.Windows.Forms.Padding(3);
            this.pagePositions.Size = new System.Drawing.Size(794, 540);
            this.pagePositions.TabIndex = 4;
            this.pagePositions.Text = "Должности";
            this.pagePositions.UseVisualStyleBackColor = true;
            // 
            // pageOrders
            // 
            this.pageOrders.Location = new System.Drawing.Point(4, 22);
            this.pageOrders.Name = "pageOrders";
            this.pageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.pageOrders.Size = new System.Drawing.Size(794, 540);
            this.pageOrders.TabIndex = 3;
            this.pageOrders.Text = "Приказы";
            this.pageOrders.UseVisualStyleBackColor = true;
            // 
            // pageTitles
            // 
            this.pageTitles.Controls.Add(this.groupboxDegrees);
            this.pageTitles.Controls.Add(this.groupboxTitles);
            this.pageTitles.Location = new System.Drawing.Point(4, 22);
            this.pageTitles.Margin = new System.Windows.Forms.Padding(2);
            this.pageTitles.Name = "pageTitles";
            this.pageTitles.Padding = new System.Windows.Forms.Padding(2);
            this.pageTitles.Size = new System.Drawing.Size(794, 540);
            this.pageTitles.TabIndex = 2;
            this.pageTitles.Text = "Звания и степени";
            this.pageTitles.UseVisualStyleBackColor = true;
            // 
            // groupboxTitles
            // 
            this.groupboxTitles.Controls.Add(this.panel1);
            this.groupboxTitles.Controls.Add(this.panelTitlesSelect);
            this.groupboxTitles.Location = new System.Drawing.Point(400, 5);
            this.groupboxTitles.Name = "groupboxTitles";
            this.groupboxTitles.Size = new System.Drawing.Size(389, 530);
            this.groupboxTitles.TabIndex = 5;
            this.groupboxTitles.TabStop = false;
            this.groupboxTitles.Text = "Звания";
            // 
            // panelTitlesSelect
            // 
            this.panelTitlesSelect.Controls.Add(this.panelTitleChoose);
            this.panelTitlesSelect.Controls.Add(this.btnTitleChooseSelect);
            this.panelTitlesSelect.Controls.Add(this.btnSelectAllTitles);
            this.panelTitlesSelect.Controls.Add(this.dgvTitles);
            this.panelTitlesSelect.Location = new System.Drawing.Point(6, 19);
            this.panelTitlesSelect.Name = "panelTitlesSelect";
            this.panelTitlesSelect.Size = new System.Drawing.Size(377, 415);
            this.panelTitlesSelect.TabIndex = 5;
            // 
            // dgvTitles
            // 
            this.dgvTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTitles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Title,
            this.titlename});
            this.dgvTitles.Location = new System.Drawing.Point(2, 118);
            this.dgvTitles.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTitles.Name = "dgvTitles";
            this.dgvTitles.RowTemplate.Height = 27;
            this.dgvTitles.Size = new System.Drawing.Size(373, 295);
            this.dgvTitles.TabIndex = 4;
            // 
            // titlename
            // 
            this.titlename.HeaderText = "Name";
            this.titlename.Name = "titlename";
            // 
            // ID_Title
            // 
            this.ID_Title.HeaderText = "ID_Title";
            this.ID_Title.Name = "ID_Title";
            // 
            // btnSelectAllTitles
            // 
            this.btnSelectAllTitles.Location = new System.Drawing.Point(3, 88);
            this.btnSelectAllTitles.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAllTitles.Name = "btnSelectAllTitles";
            this.btnSelectAllTitles.Size = new System.Drawing.Size(148, 26);
            this.btnSelectAllTitles.TabIndex = 3;
            this.btnSelectAllTitles.Text = "Выбрать все звания";
            this.btnSelectAllTitles.UseVisualStyleBackColor = true;
            this.btnSelectAllTitles.Click += new System.EventHandler(this.Button1_Click_1);
            // 
            // btnTitleChooseSelect
            // 
            this.btnTitleChooseSelect.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTitleChooseSelect.Location = new System.Drawing.Point(3, 3);
            this.btnTitleChooseSelect.Name = "btnTitleChooseSelect";
            this.btnTitleChooseSelect.Size = new System.Drawing.Size(148, 73);
            this.btnTitleChooseSelect.TabIndex = 8;
            this.btnTitleChooseSelect.Text = "Выбрать одно или несколько званий";
            this.btnTitleChooseSelect.UseVisualStyleBackColor = true;
            // 
            // panelTitleChoose
            // 
            this.panelTitleChoose.Controls.Add(this.label2);
            this.panelTitleChoose.Controls.Add(this.rbtnTitleByName);
            this.panelTitleChoose.Controls.Add(this.rbtnTitleById);
            this.panelTitleChoose.Controls.Add(this.tbTitleIDorName);
            this.panelTitleChoose.Location = new System.Drawing.Point(157, 3);
            this.panelTitleChoose.Name = "panelTitleChoose";
            this.panelTitleChoose.Size = new System.Drawing.Size(217, 73);
            this.panelTitleChoose.TabIndex = 9;
            // 
            // tbTitleIDorName
            // 
            this.tbTitleIDorName.Location = new System.Drawing.Point(18, 45);
            this.tbTitleIDorName.Name = "tbTitleIDorName";
            this.tbTitleIDorName.Size = new System.Drawing.Size(184, 20);
            this.tbTitleIDorName.TabIndex = 8;
            // 
            // rbtnTitleById
            // 
            this.rbtnTitleById.AutoSize = true;
            this.rbtnTitleById.Location = new System.Drawing.Point(18, 9);
            this.rbtnTitleById.Name = "rbtnTitleById";
            this.rbtnTitleById.Size = new System.Drawing.Size(53, 17);
            this.rbtnTitleById.TabIndex = 9;
            this.rbtnTitleById.TabStop = true;
            this.rbtnTitleById.Text = "По ID";
            this.rbtnTitleById.UseVisualStyleBackColor = true;
            // 
            // rbtnTitleByName
            // 
            this.rbtnTitleByName.AutoSize = true;
            this.rbtnTitleByName.Location = new System.Drawing.Point(110, 9);
            this.rbtnTitleByName.Name = "rbtnTitleByName";
            this.rbtnTitleByName.Size = new System.Drawing.Size(92, 17);
            this.rbtnTitleByName.TabIndex = 10;
            this.rbtnTitleByName.TabStop = true;
            this.rbtnTitleByName.Text = "По названию";
            this.rbtnTitleByName.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Введите id или название:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btnAddTitle);
            this.panel1.Location = new System.Drawing.Point(6, 440);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(377, 84);
            this.panel1.TabIndex = 6;
            // 
            // btnAddTitle
            // 
            this.btnAddTitle.Location = new System.Drawing.Point(207, 35);
            this.btnAddTitle.Name = "btnAddTitle";
            this.btnAddTitle.Size = new System.Drawing.Size(152, 23);
            this.btnAddTitle.TabIndex = 0;
            this.btnAddTitle.Text = "Добавить звание";
            this.btnAddTitle.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Наименование звания:";
            // 
            // groupboxDegrees
            // 
            this.groupboxDegrees.Controls.Add(this.panelAddDegree);
            this.groupboxDegrees.Controls.Add(this.panelSelectDegree);
            this.groupboxDegrees.Location = new System.Drawing.Point(5, 5);
            this.groupboxDegrees.Name = "groupboxDegrees";
            this.groupboxDegrees.Size = new System.Drawing.Size(389, 530);
            this.groupboxDegrees.TabIndex = 7;
            this.groupboxDegrees.TabStop = false;
            this.groupboxDegrees.Text = "Звания";
            // 
            // panelSelectDegree
            // 
            this.panelSelectDegree.Controls.Add(this.panelChooseDegree);
            this.panelSelectDegree.Controls.Add(this.btnSelectSomeDegrees);
            this.panelSelectDegree.Controls.Add(this.btnSelectAllDegrees);
            this.panelSelectDegree.Controls.Add(this.dgvDegrees);
            this.panelSelectDegree.Location = new System.Drawing.Point(6, 19);
            this.panelSelectDegree.Name = "panelSelectDegree";
            this.panelSelectDegree.Size = new System.Drawing.Size(377, 415);
            this.panelSelectDegree.TabIndex = 5;
            // 
            // dgvDegrees
            // 
            this.dgvDegrees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDegrees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvDegrees.Location = new System.Drawing.Point(2, 118);
            this.dgvDegrees.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDegrees.Name = "dgvDegrees";
            this.dgvDegrees.RowTemplate.Height = 27;
            this.dgvDegrees.Size = new System.Drawing.Size(373, 295);
            this.dgvDegrees.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID_Title";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // btnSelectAllDegrees
            // 
            this.btnSelectAllDegrees.Location = new System.Drawing.Point(3, 88);
            this.btnSelectAllDegrees.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectAllDegrees.Name = "btnSelectAllDegrees";
            this.btnSelectAllDegrees.Size = new System.Drawing.Size(148, 26);
            this.btnSelectAllDegrees.TabIndex = 3;
            this.btnSelectAllDegrees.Text = "Выбрать все степени";
            this.btnSelectAllDegrees.UseVisualStyleBackColor = true;
            // 
            // btnSelectSomeDegrees
            // 
            this.btnSelectSomeDegrees.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSelectSomeDegrees.Location = new System.Drawing.Point(3, 3);
            this.btnSelectSomeDegrees.Name = "btnSelectSomeDegrees";
            this.btnSelectSomeDegrees.Size = new System.Drawing.Size(148, 73);
            this.btnSelectSomeDegrees.TabIndex = 8;
            this.btnSelectSomeDegrees.Text = "Выбрать одну или несколько степеней";
            this.btnSelectSomeDegrees.UseVisualStyleBackColor = true;
            // 
            // panelChooseDegree
            // 
            this.panelChooseDegree.Controls.Add(this.labelInputDegreeID);
            this.panelChooseDegree.Controls.Add(this.rbtnDegreeByName);
            this.panelChooseDegree.Controls.Add(this.rbtnDegreeById);
            this.panelChooseDegree.Controls.Add(this.tbDegreeIDorName);
            this.panelChooseDegree.Location = new System.Drawing.Point(157, 3);
            this.panelChooseDegree.Name = "panelChooseDegree";
            this.panelChooseDegree.Size = new System.Drawing.Size(217, 73);
            this.panelChooseDegree.TabIndex = 9;
            // 
            // tbDegreeIDorName
            // 
            this.tbDegreeIDorName.Location = new System.Drawing.Point(18, 45);
            this.tbDegreeIDorName.Name = "tbDegreeIDorName";
            this.tbDegreeIDorName.Size = new System.Drawing.Size(184, 20);
            this.tbDegreeIDorName.TabIndex = 8;
            // 
            // rbtnDegreeById
            // 
            this.rbtnDegreeById.AutoSize = true;
            this.rbtnDegreeById.Location = new System.Drawing.Point(18, 9);
            this.rbtnDegreeById.Name = "rbtnDegreeById";
            this.rbtnDegreeById.Size = new System.Drawing.Size(53, 17);
            this.rbtnDegreeById.TabIndex = 9;
            this.rbtnDegreeById.TabStop = true;
            this.rbtnDegreeById.Text = "По ID";
            this.rbtnDegreeById.UseVisualStyleBackColor = true;
            // 
            // rbtnDegreeByName
            // 
            this.rbtnDegreeByName.AutoSize = true;
            this.rbtnDegreeByName.Location = new System.Drawing.Point(110, 9);
            this.rbtnDegreeByName.Name = "rbtnDegreeByName";
            this.rbtnDegreeByName.Size = new System.Drawing.Size(92, 17);
            this.rbtnDegreeByName.TabIndex = 10;
            this.rbtnDegreeByName.TabStop = true;
            this.rbtnDegreeByName.Text = "По названию";
            this.rbtnDegreeByName.UseVisualStyleBackColor = true;
            // 
            // labelInputDegreeID
            // 
            this.labelInputDegreeID.AutoSize = true;
            this.labelInputDegreeID.Location = new System.Drawing.Point(34, 29);
            this.labelInputDegreeID.Name = "labelInputDegreeID";
            this.labelInputDegreeID.Size = new System.Drawing.Size(135, 13);
            this.labelInputDegreeID.TabIndex = 11;
            this.labelInputDegreeID.Text = "Введите id или название:";
            // 
            // panelAddDegree
            // 
            this.panelAddDegree.Controls.Add(this.labelAddDegree);
            this.panelAddDegree.Controls.Add(this.tbAddDegree);
            this.panelAddDegree.Controls.Add(this.btnAddDegree);
            this.panelAddDegree.Location = new System.Drawing.Point(6, 440);
            this.panelAddDegree.Name = "panelAddDegree";
            this.panelAddDegree.Size = new System.Drawing.Size(377, 84);
            this.panelAddDegree.TabIndex = 6;
            // 
            // btnAddDegree
            // 
            this.btnAddDegree.Location = new System.Drawing.Point(207, 35);
            this.btnAddDegree.Name = "btnAddDegree";
            this.btnAddDegree.Size = new System.Drawing.Size(152, 23);
            this.btnAddDegree.TabIndex = 0;
            this.btnAddDegree.Text = "Добавить степень";
            this.btnAddDegree.UseVisualStyleBackColor = true;
            // 
            // tbAddDegree
            // 
            this.tbAddDegree.Location = new System.Drawing.Point(20, 37);
            this.tbAddDegree.Name = "tbAddDegree";
            this.tbAddDegree.Size = new System.Drawing.Size(170, 20);
            this.tbAddDegree.TabIndex = 1;
            // 
            // labelAddDegree
            // 
            this.labelAddDegree.AutoSize = true;
            this.labelAddDegree.Location = new System.Drawing.Point(17, 18);
            this.labelAddDegree.Name = "labelAddDegree";
            this.labelAddDegree.Size = new System.Drawing.Size(130, 13);
            this.labelAddDegree.TabIndex = 2;
            this.labelAddDegree.Text = "Наименование степени:";
            // 
            // pageChair
            // 
            this.pageChair.Location = new System.Drawing.Point(4, 22);
            this.pageChair.Margin = new System.Windows.Forms.Padding(2);
            this.pageChair.Name = "pageChair";
            this.pageChair.Padding = new System.Windows.Forms.Padding(2);
            this.pageChair.Size = new System.Drawing.Size(794, 540);
            this.pageChair.TabIndex = 1;
            this.pageChair.Text = "Кафедра";
            this.pageChair.UseVisualStyleBackColor = true;
            // 
            // pageStaff
            // 
            this.pageStaff.Controls.Add(this.tabControlStaff);
            this.pageStaff.Location = new System.Drawing.Point(4, 22);
            this.pageStaff.Margin = new System.Windows.Forms.Padding(2);
            this.pageStaff.Name = "pageStaff";
            this.pageStaff.Padding = new System.Windows.Forms.Padding(2);
            this.pageStaff.Size = new System.Drawing.Size(794, 540);
            this.pageStaff.TabIndex = 0;
            this.pageStaff.Text = "Сотрудник";
            this.pageStaff.UseVisualStyleBackColor = true;
            // 
            // tabControlStaff
            // 
            this.tabControlStaff.Controls.Add(this.pageStaffGeneral);
            this.tabControlStaff.Controls.Add(this.pageStaffDegrees);
            this.tabControlStaff.Controls.Add(this.pageStaffOrders);
            this.tabControlStaff.Location = new System.Drawing.Point(5, 5);
            this.tabControlStaff.Name = "tabControlStaff";
            this.tabControlStaff.SelectedIndex = 0;
            this.tabControlStaff.Size = new System.Drawing.Size(784, 530);
            this.tabControlStaff.TabIndex = 0;
            // 
            // pageStaffOrders
            // 
            this.pageStaffOrders.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pageStaffOrders.Location = new System.Drawing.Point(4, 22);
            this.pageStaffOrders.Name = "pageStaffOrders";
            this.pageStaffOrders.Padding = new System.Windows.Forms.Padding(3);
            this.pageStaffOrders.Size = new System.Drawing.Size(776, 504);
            this.pageStaffOrders.TabIndex = 2;
            this.pageStaffOrders.Text = "Приказы по сотруднику";
            this.pageStaffOrders.UseVisualStyleBackColor = true;
            // 
            // pageStaffDegrees
            // 
            this.pageStaffDegrees.Location = new System.Drawing.Point(4, 22);
            this.pageStaffDegrees.Name = "pageStaffDegrees";
            this.pageStaffDegrees.Padding = new System.Windows.Forms.Padding(3);
            this.pageStaffDegrees.Size = new System.Drawing.Size(776, 504);
            this.pageStaffDegrees.TabIndex = 1;
            this.pageStaffDegrees.Text = "Звания и степени сотрудника";
            this.pageStaffDegrees.UseVisualStyleBackColor = true;
            // 
            // pageStaffGeneral
            // 
            this.pageStaffGeneral.Location = new System.Drawing.Point(4, 22);
            this.pageStaffGeneral.Name = "pageStaffGeneral";
            this.pageStaffGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.pageStaffGeneral.Size = new System.Drawing.Size(776, 504);
            this.pageStaffGeneral.TabIndex = 0;
            this.pageStaffGeneral.Text = "Общее";
            this.pageStaffGeneral.UseVisualStyleBackColor = true;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.pageStaff);
            this.tabControlMain.Controls.Add(this.pageChair);
            this.tabControlMain.Controls.Add(this.pageTitles);
            this.tabControlMain.Controls.Add(this.pageOrders);
            this.tabControlMain.Controls.Add(this.pagePositions);
            this.tabControlMain.Location = new System.Drawing.Point(9, 9);
            this.tabControlMain.Margin = new System.Windows.Forms.Padding(2);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(802, 566);
            this.tabControlMain.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 584);
            this.Controls.Add(this.tabControlMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.pageTitles.ResumeLayout(false);
            this.groupboxTitles.ResumeLayout(false);
            this.panelTitlesSelect.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTitles)).EndInit();
            this.panelTitleChoose.ResumeLayout(false);
            this.panelTitleChoose.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupboxDegrees.ResumeLayout(false);
            this.panelSelectDegree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDegrees)).EndInit();
            this.panelChooseDegree.ResumeLayout(false);
            this.panelChooseDegree.PerformLayout();
            this.panelAddDegree.ResumeLayout(false);
            this.panelAddDegree.PerformLayout();
            this.pageStaff.ResumeLayout(false);
            this.tabControlStaff.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage pagePositions;
        private System.Windows.Forms.TabPage pageOrders;
        private System.Windows.Forms.TabPage pageTitles;
        private System.Windows.Forms.GroupBox groupboxDegrees;
        private System.Windows.Forms.Panel panelAddDegree;
        private System.Windows.Forms.Label labelAddDegree;
        private System.Windows.Forms.TextBox tbAddDegree;
        private System.Windows.Forms.Button btnAddDegree;
        private System.Windows.Forms.Panel panelSelectDegree;
        private System.Windows.Forms.Panel panelChooseDegree;
        private System.Windows.Forms.Label labelInputDegreeID;
        private System.Windows.Forms.RadioButton rbtnDegreeByName;
        private System.Windows.Forms.RadioButton rbtnDegreeById;
        private System.Windows.Forms.TextBox tbDegreeIDorName;
        private System.Windows.Forms.Button btnSelectSomeDegrees;
        private System.Windows.Forms.Button btnSelectAllDegrees;
        private System.Windows.Forms.DataGridView dgvDegrees;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupboxTitles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAddTitle;
        private System.Windows.Forms.Panel panelTitlesSelect;
        private System.Windows.Forms.Panel panelTitleChoose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbtnTitleByName;
        private System.Windows.Forms.RadioButton rbtnTitleById;
        private System.Windows.Forms.TextBox tbTitleIDorName;
        private System.Windows.Forms.Button btnTitleChooseSelect;
        private System.Windows.Forms.Button btnSelectAllTitles;
        private System.Windows.Forms.DataGridView dgvTitles;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn titlename;
        private System.Windows.Forms.TabPage pageChair;
        private System.Windows.Forms.TabPage pageStaff;
        private System.Windows.Forms.TabControl tabControlStaff;
        private System.Windows.Forms.TabPage pageStaffGeneral;
        private System.Windows.Forms.TabPage pageStaffDegrees;
        private System.Windows.Forms.TabPage pageStaffOrders;
        private System.Windows.Forms.TabControl tabControlMain;
    }
}

