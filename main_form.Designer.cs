namespace PaymentCreator
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.courseLabel = new System.Windows.Forms.Label();
            this.courseSelect = new System.Windows.Forms.ComboBox();
            this.numPayLabel = new System.Windows.Forms.Label();
            this.paySelect = new System.Windows.Forms.ComboBox();
            this.FIOLabel = new System.Windows.Forms.Label();
            this.payYesFrom = new System.Windows.Forms.MonthCalendar();
            this.payYesLabel = new System.Windows.Forms.Label();
            this.payYesGroup = new System.Windows.Forms.GroupBox();
            this.payYesLabelTo = new System.Windows.Forms.Label();
            this.payYesLabelFrom = new System.Windows.Forms.Label();
            this.payYesTo = new System.Windows.Forms.MonthCalendar();
            this.payNoGroup = new System.Windows.Forms.GroupBox();
            this.payNoLabelTo = new System.Windows.Forms.Label();
            this.payNoLabelFrom = new System.Windows.Forms.Label();
            this.payNoTo = new System.Windows.Forms.MonthCalendar();
            this.payNoLabel = new System.Windows.Forms.Label();
            this.payNoFrom = new System.Windows.Forms.MonthCalendar();
            this.createPayment = new System.Windows.Forms.Button();
            this.settings = new System.Windows.Forms.Button();
            this.notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.FIOBox = new System.Windows.Forms.ComboBox();
            this.isPersonal = new System.Windows.Forms.CheckBox();
            this.payYesGroup.SuspendLayout();
            this.payNoGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // courseLabel
            // 
            this.courseLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.courseLabel.AutoSize = true;
            this.courseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.courseLabel.Location = new System.Drawing.Point(16, 20);
            this.courseLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.courseLabel.Name = "courseLabel";
            this.courseLabel.Size = new System.Drawing.Size(103, 17);
            this.courseLabel.TabIndex = 0;
            this.courseLabel.Text = "Оплата курса:";
            // 
            // courseSelect
            // 
            this.courseSelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.courseSelect.FormattingEnabled = true;
            this.courseSelect.Location = new System.Drawing.Point(119, 18);
            this.courseSelect.Margin = new System.Windows.Forms.Padding(2);
            this.courseSelect.Name = "courseSelect";
            this.courseSelect.Size = new System.Drawing.Size(131, 21);
            this.courseSelect.TabIndex = 1;
            this.courseSelect.SelectedIndexChanged += new System.EventHandler(this.courseSelect_SelectedIndexChanged);
            // 
            // numPayLabel
            // 
            this.numPayLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numPayLabel.AutoSize = true;
            this.numPayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numPayLabel.Location = new System.Drawing.Point(254, 20);
            this.numPayLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.numPayLabel.Name = "numPayLabel";
            this.numPayLabel.Size = new System.Drawing.Size(80, 17);
            this.numPayLabel.TabIndex = 0;
            this.numPayLabel.Text = "Платеж №:";
            // 
            // paySelect
            // 
            this.paySelect.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.paySelect.FormattingEnabled = true;
            this.paySelect.Location = new System.Drawing.Point(338, 18);
            this.paySelect.Margin = new System.Windows.Forms.Padding(2);
            this.paySelect.Name = "paySelect";
            this.paySelect.Size = new System.Drawing.Size(111, 21);
            this.paySelect.TabIndex = 2;
            this.paySelect.SelectedIndexChanged += new System.EventHandler(this.paySelect_SelectedIndexChanged);
            // 
            // FIOLabel
            // 
            this.FIOLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FIOLabel.AutoSize = true;
            this.FIOLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FIOLabel.Location = new System.Drawing.Point(16, 46);
            this.FIOLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FIOLabel.Name = "FIOLabel";
            this.FIOLabel.Size = new System.Drawing.Size(105, 17);
            this.FIOLabel.TabIndex = 0;
            this.FIOLabel.Text = "ФИО ребенка:";
            // 
            // payYesFrom
            // 
            this.payYesFrom.BackColor = System.Drawing.Color.Silver;
            this.payYesFrom.Location = new System.Drawing.Point(9, 38);
            this.payYesFrom.Margin = new System.Windows.Forms.Padding(7);
            this.payYesFrom.Name = "payYesFrom";
            this.payYesFrom.ShowToday = false;
            this.payYesFrom.TabIndex = 7;
            // 
            // payYesLabel
            // 
            this.payYesLabel.AutoSize = true;
            this.payYesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.payYesLabel.Location = new System.Drawing.Point(118, 15);
            this.payYesLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.payYesLabel.Name = "payYesLabel";
            this.payYesLabel.Size = new System.Drawing.Size(79, 17);
            this.payYesLabel.TabIndex = 0;
            this.payYesLabel.Text = "Оплачено:";
            // 
            // payYesGroup
            // 
            this.payYesGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.payYesGroup.AutoSize = true;
            this.payYesGroup.Controls.Add(this.payYesLabelTo);
            this.payYesGroup.Controls.Add(this.payYesLabelFrom);
            this.payYesGroup.Controls.Add(this.payYesTo);
            this.payYesGroup.Controls.Add(this.payYesLabel);
            this.payYesGroup.Controls.Add(this.payYesFrom);
            this.payYesGroup.Location = new System.Drawing.Point(9, 77);
            this.payYesGroup.Margin = new System.Windows.Forms.Padding(2);
            this.payYesGroup.Name = "payYesGroup";
            this.payYesGroup.Padding = new System.Windows.Forms.Padding(2);
            this.payYesGroup.Size = new System.Drawing.Size(346, 228);
            this.payYesGroup.TabIndex = 8;
            this.payYesGroup.TabStop = false;
            // 
            // payYesLabelTo
            // 
            this.payYesLabelTo.AutoSize = true;
            this.payYesLabelTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.payYesLabelTo.Location = new System.Drawing.Point(285, 15);
            this.payYesLabelTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.payYesLabelTo.Name = "payYesLabelTo";
            this.payYesLabelTo.Size = new System.Drawing.Size(30, 17);
            this.payYesLabelTo.TabIndex = 0;
            this.payYesLabelTo.Text = "По:";
            // 
            // payYesLabelFrom
            // 
            this.payYesLabelFrom.AutoSize = true;
            this.payYesLabelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.payYesLabelFrom.Location = new System.Drawing.Point(6, 15);
            this.payYesLabelFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.payYesLabelFrom.Name = "payYesLabelFrom";
            this.payYesLabelFrom.Size = new System.Drawing.Size(21, 17);
            this.payYesLabelFrom.TabIndex = 0;
            this.payYesLabelFrom.Text = "С:";
            // 
            // payYesTo
            // 
            this.payYesTo.Location = new System.Drawing.Point(173, 38);
            this.payYesTo.Margin = new System.Windows.Forms.Padding(7);
            this.payYesTo.Name = "payYesTo";
            this.payYesTo.ShowToday = false;
            this.payYesTo.TabIndex = 8;
            // 
            // payNoGroup
            // 
            this.payNoGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.payNoGroup.AutoSize = true;
            this.payNoGroup.Controls.Add(this.payNoLabelTo);
            this.payNoGroup.Controls.Add(this.payNoLabelFrom);
            this.payNoGroup.Controls.Add(this.payNoTo);
            this.payNoGroup.Controls.Add(this.payNoLabel);
            this.payNoGroup.Controls.Add(this.payNoFrom);
            this.payNoGroup.Location = new System.Drawing.Point(391, 77);
            this.payNoGroup.Margin = new System.Windows.Forms.Padding(2);
            this.payNoGroup.Name = "payNoGroup";
            this.payNoGroup.Padding = new System.Windows.Forms.Padding(2);
            this.payNoGroup.Size = new System.Drawing.Size(344, 228);
            this.payNoGroup.TabIndex = 11;
            this.payNoGroup.TabStop = false;
            // 
            // payNoLabelTo
            // 
            this.payNoLabelTo.AutoSize = true;
            this.payNoLabelTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.payNoLabelTo.Location = new System.Drawing.Point(287, 15);
            this.payNoLabelTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.payNoLabelTo.Name = "payNoLabelTo";
            this.payNoLabelTo.Size = new System.Drawing.Size(30, 17);
            this.payNoLabelTo.TabIndex = 0;
            this.payNoLabelTo.Text = "По:";
            // 
            // payNoLabelFrom
            // 
            this.payNoLabelFrom.AutoSize = true;
            this.payNoLabelFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.payNoLabelFrom.Location = new System.Drawing.Point(6, 15);
            this.payNoLabelFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.payNoLabelFrom.Name = "payNoLabelFrom";
            this.payNoLabelFrom.Size = new System.Drawing.Size(21, 17);
            this.payNoLabelFrom.TabIndex = 0;
            this.payNoLabelFrom.Text = "С:";
            // 
            // payNoTo
            // 
            this.payNoTo.Location = new System.Drawing.Point(171, 38);
            this.payNoTo.Margin = new System.Windows.Forms.Padding(7);
            this.payNoTo.Name = "payNoTo";
            this.payNoTo.ShowToday = false;
            this.payNoTo.TabIndex = 10;
            // 
            // payNoLabel
            // 
            this.payNoLabel.AutoSize = true;
            this.payNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.payNoLabel.Location = new System.Drawing.Point(106, 15);
            this.payNoLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.payNoLabel.Name = "payNoLabel";
            this.payNoLabel.Size = new System.Drawing.Size(120, 17);
            this.payNoLabel.TabIndex = 0;
            this.payNoLabel.Text = "Оплата занятий:";
            // 
            // payNoFrom
            // 
            this.payNoFrom.BackColor = System.Drawing.Color.Silver;
            this.payNoFrom.Location = new System.Drawing.Point(9, 38);
            this.payNoFrom.Margin = new System.Windows.Forms.Padding(7);
            this.payNoFrom.Name = "payNoFrom";
            this.payNoFrom.ShowToday = false;
            this.payNoFrom.TabIndex = 9;
            // 
            // createPayment
            // 
            this.createPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createPayment.Location = new System.Drawing.Point(608, 10);
            this.createPayment.Margin = new System.Windows.Forms.Padding(2);
            this.createPayment.Name = "createPayment";
            this.createPayment.Size = new System.Drawing.Size(128, 27);
            this.createPayment.TabIndex = 5;
            this.createPayment.Text = "Создать";
            this.createPayment.UseVisualStyleBackColor = true;
            this.createPayment.Click += new System.EventHandler(this.createPayment_Click);
            // 
            // settings
            // 
            this.settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings.Location = new System.Drawing.Point(608, 41);
            this.settings.Margin = new System.Windows.Forms.Padding(2);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(128, 27);
            this.settings.TabIndex = 6;
            this.settings.Text = "Настройки";
            this.settings.UseVisualStyleBackColor = true;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // notify
            // 
            this.notify.Text = "PaymentCreator";
            this.notify.Click += new System.EventHandler(this.notify_Click);
            this.notify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notify_MouseDoubleClick);
            // 
            // FIOBox
            // 
            this.FIOBox.FormattingEnabled = true;
            this.FIOBox.Location = new System.Drawing.Point(126, 44);
            this.FIOBox.Name = "FIOBox";
            this.FIOBox.Size = new System.Drawing.Size(424, 21);
            this.FIOBox.TabIndex = 4;
            // 
            // isPersonal
            // 
            this.isPersonal.AutoSize = true;
            this.isPersonal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isPersonal.Location = new System.Drawing.Point(454, 19);
            this.isPersonal.Name = "isPersonal";
            this.isPersonal.Size = new System.Drawing.Size(132, 20);
            this.isPersonal.TabIndex = 3;
            this.isPersonal.Text = "Индивидуально";
            this.isPersonal.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 311);
            this.Controls.Add(this.isPersonal);
            this.Controls.Add(this.FIOBox);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.createPayment);
            this.Controls.Add(this.payNoGroup);
            this.Controls.Add(this.payYesGroup);
            this.Controls.Add(this.FIOLabel);
            this.Controls.Add(this.paySelect);
            this.Controls.Add(this.numPayLabel);
            this.Controls.Add(this.courseSelect);
            this.Controls.Add(this.courseLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Генератор платежей";
            this.Load += new System.EventHandler(this.Main_Load);
            this.payYesGroup.ResumeLayout(false);
            this.payYesGroup.PerformLayout();
            this.payNoGroup.ResumeLayout(false);
            this.payNoGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label courseLabel;
        private System.Windows.Forms.ComboBox courseSelect;
        private System.Windows.Forms.Label numPayLabel;
        private System.Windows.Forms.ComboBox paySelect;
        private System.Windows.Forms.Label FIOLabel;
        private System.Windows.Forms.MonthCalendar payYesFrom;
        private System.Windows.Forms.Label payYesLabel;
        private System.Windows.Forms.GroupBox payYesGroup;
        private System.Windows.Forms.Label payYesLabelTo;
        private System.Windows.Forms.Label payYesLabelFrom;
        private System.Windows.Forms.MonthCalendar payYesTo;
        private System.Windows.Forms.GroupBox payNoGroup;
        private System.Windows.Forms.Label payNoLabelTo;
        private System.Windows.Forms.Label payNoLabelFrom;
        private System.Windows.Forms.MonthCalendar payNoTo;
        private System.Windows.Forms.Label payNoLabel;
        private System.Windows.Forms.MonthCalendar payNoFrom;
        private System.Windows.Forms.Button createPayment;
        private System.Windows.Forms.Button settings;
        private System.Windows.Forms.NotifyIcon notify;
        private System.Windows.Forms.ComboBox FIOBox;
        private System.Windows.Forms.CheckBox isPersonal;
    }
}

