namespace Lab4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.inform = new System.Windows.Forms.Label();
            this.Changing = new System.Windows.Forms.Panel();
            this.ChangingBackButton = new System.Windows.Forms.Button();
            this.ChangeLabel = new System.Windows.Forms.Label();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.PanelLabel = new System.Windows.Forms.Label();
            this.ChangeOkButton = new System.Windows.Forms.Button();
            this.ChangeSubStr = new System.Windows.Forms.TextBox();
            this.SearchSubStr = new System.Windows.Forms.TextBox();
            this.DeletePanel = new System.Windows.Forms.Panel();
            this.DeleteButtonBack = new System.Windows.Forms.Button();
            this.DeleteOkButton = new System.Windows.Forms.Button();
            this.SearchLabel2 = new System.Windows.Forms.Label();
            this.DeleteLabel = new System.Windows.Forms.Label();
            this.SearchSubStr2 = new System.Windows.Forms.TextBox();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.SearchBack = new System.Windows.Forms.Button();
            this.SymbolValue = new System.Windows.Forms.Label();
            this.Symbol = new System.Windows.Forms.Label();
            this.IndexValue = new System.Windows.Forms.TextBox();
            this.Index = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Changing.SuspendLayout();
            this.DeletePanel.SuspendLayout();
            this.SearchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.LightCoral;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button4.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(12, 172);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 44);
            this.button4.TabIndex = 4;
            this.button4.Text = "Длина";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.buttonLength_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.LightCoral;
            this.button5.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button5.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(12, 240);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(136, 44);
            this.button5.TabIndex = 5;
            this.button5.Text = "Гласные";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.buttonGl_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.LightCoral;
            this.button6.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button6.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(154, 240);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(145, 44);
            this.button6.TabIndex = 6;
            this.button6.Text = "Согласные";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.buttonSgl_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.LightCoral;
            this.button7.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button7.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(154, 311);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(145, 44);
            this.button7.TabIndex = 7;
            this.button7.Text = "Предложения";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.buttonSentence_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.LightCoral;
            this.button8.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button8.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(12, 311);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(136, 44);
            this.button8.TabIndex = 8;
            this.button8.Text = "Слова";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.buttonWord_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.LightCoral;
            this.button9.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button9.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(154, 172);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(145, 44);
            this.button9.TabIndex = 9;
            this.button9.Text = "Очистка";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(79, 29);
            this.textBox1.Margin = new System.Windows.Forms.Padding(6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(426, 65);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // inform
            // 
            this.inform.BackColor = System.Drawing.Color.MistyRose;
            this.inform.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.inform.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inform.ForeColor = System.Drawing.Color.Firebrick;
            this.inform.Location = new System.Drawing.Point(79, 109);
            this.inform.Name = "inform";
            this.inform.Size = new System.Drawing.Size(426, 30);
            this.inform.TabIndex = 11;
            this.inform.Click += new System.EventHandler(this.inform_Click);
            // 
            // Changing
            // 
            this.Changing.BackColor = System.Drawing.Color.LightCoral;
            this.Changing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Changing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Changing.Controls.Add(this.ChangingBackButton);
            this.Changing.Controls.Add(this.ChangeLabel);
            this.Changing.Controls.Add(this.SearchLabel);
            this.Changing.Controls.Add(this.PanelLabel);
            this.Changing.Controls.Add(this.ChangeOkButton);
            this.Changing.Controls.Add(this.ChangeSubStr);
            this.Changing.Controls.Add(this.SearchSubStr);
            this.Changing.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Changing.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Changing.Location = new System.Drawing.Point(325, 172);
            this.Changing.Name = "Changing";
            this.Changing.Size = new System.Drawing.Size(239, 108);
            this.Changing.TabIndex = 14;
            this.Changing.TabStop = true;
            // 
            // ChangingBackButton
            // 
            this.ChangingBackButton.BackColor = System.Drawing.Color.IndianRed;
            this.ChangingBackButton.Location = new System.Drawing.Point(94, 74);
            this.ChangingBackButton.Name = "ChangingBackButton";
            this.ChangingBackButton.Size = new System.Drawing.Size(75, 31);
            this.ChangingBackButton.TabIndex = 6;
            this.ChangingBackButton.Text = "Отмена";
            this.ChangingBackButton.UseVisualStyleBackColor = false;
            this.ChangingBackButton.Click += new System.EventHandler(this.ChangingBackButton_Click);
            // 
            // ChangeLabel
            // 
            this.ChangeLabel.AutoSize = true;
            this.ChangeLabel.Location = new System.Drawing.Point(129, 32);
            this.ChangeLabel.Name = "ChangeLabel";
            this.ChangeLabel.Size = new System.Drawing.Size(100, 18);
            this.ChangeLabel.TabIndex = 5;
            this.ChangeLabel.Text = "Заменить на:";
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(10, 32);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(127, 18);
            this.SearchLabel.TabIndex = 4;
            this.SearchLabel.Text = "Искомая строка:";
            // 
            // PanelLabel
            // 
            this.PanelLabel.AutoSize = true;
            this.PanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PanelLabel.Location = new System.Drawing.Point(37, 7);
            this.PanelLabel.Name = "PanelLabel";
            this.PanelLabel.Size = new System.Drawing.Size(166, 22);
            this.PanelLabel.TabIndex = 3;
            this.PanelLabel.Text = "Замена подстроки";
            // 
            // ChangeOkButton
            // 
            this.ChangeOkButton.BackColor = System.Drawing.Color.IndianRed;
            this.ChangeOkButton.Location = new System.Drawing.Point(13, 74);
            this.ChangeOkButton.Name = "ChangeOkButton";
            this.ChangeOkButton.Size = new System.Drawing.Size(75, 31);
            this.ChangeOkButton.TabIndex = 2;
            this.ChangeOkButton.Text = "Ок";
            this.ChangeOkButton.UseVisualStyleBackColor = false;
            this.ChangeOkButton.Click += new System.EventHandler(this.ChangeOkButton_Click);
            // 
            // ChangeSubStr
            // 
            this.ChangeSubStr.Location = new System.Drawing.Point(132, 48);
            this.ChangeSubStr.Name = "ChangeSubStr";
            this.ChangeSubStr.Size = new System.Drawing.Size(100, 24);
            this.ChangeSubStr.TabIndex = 1;
            // 
            // SearchSubStr
            // 
            this.SearchSubStr.Location = new System.Drawing.Point(13, 48);
            this.SearchSubStr.Name = "SearchSubStr";
            this.SearchSubStr.Size = new System.Drawing.Size(100, 24);
            this.SearchSubStr.TabIndex = 0;
            // 
            // DeletePanel
            // 
            this.DeletePanel.BackColor = System.Drawing.Color.LightCoral;
            this.DeletePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DeletePanel.Controls.Add(this.DeleteButtonBack);
            this.DeletePanel.Controls.Add(this.DeleteOkButton);
            this.DeletePanel.Controls.Add(this.SearchLabel2);
            this.DeletePanel.Controls.Add(this.DeleteLabel);
            this.DeletePanel.Controls.Add(this.SearchSubStr2);
            this.DeletePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeletePanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DeletePanel.Location = new System.Drawing.Point(355, 307);
            this.DeletePanel.Name = "DeletePanel";
            this.DeletePanel.Size = new System.Drawing.Size(184, 108);
            this.DeletePanel.TabIndex = 15;
            this.DeletePanel.TabStop = true;
            // 
            // DeleteButtonBack
            // 
            this.DeleteButtonBack.BackColor = System.Drawing.Color.IndianRed;
            this.DeleteButtonBack.Location = new System.Drawing.Point(91, 74);
            this.DeleteButtonBack.Name = "DeleteButtonBack";
            this.DeleteButtonBack.Size = new System.Drawing.Size(75, 31);
            this.DeleteButtonBack.TabIndex = 6;
            this.DeleteButtonBack.Text = "Отмена";
            this.DeleteButtonBack.UseVisualStyleBackColor = false;
            this.DeleteButtonBack.Click += new System.EventHandler(this.DeleteButtonBack_Click);
            // 
            // DeleteOkButton
            // 
            this.DeleteOkButton.BackColor = System.Drawing.Color.IndianRed;
            this.DeleteOkButton.Location = new System.Drawing.Point(12, 74);
            this.DeleteOkButton.Name = "DeleteOkButton";
            this.DeleteOkButton.Size = new System.Drawing.Size(75, 31);
            this.DeleteOkButton.TabIndex = 2;
            this.DeleteOkButton.Text = "Ok";
            this.DeleteOkButton.UseVisualStyleBackColor = false;
            this.DeleteOkButton.Click += new System.EventHandler(this.DeleteOkButton_Click);
            // 
            // SearchLabel2
            // 
            this.SearchLabel2.AutoSize = true;
            this.SearchLabel2.Location = new System.Drawing.Point(9, 32);
            this.SearchLabel2.Name = "SearchLabel2";
            this.SearchLabel2.Size = new System.Drawing.Size(118, 17);
            this.SearchLabel2.TabIndex = 4;
            this.SearchLabel2.Text = "Искомая строка:";
            // 
            // DeleteLabel
            // 
            this.DeleteLabel.AutoSize = true;
            this.DeleteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeleteLabel.Location = new System.Drawing.Point(11, 7);
            this.DeleteLabel.Name = "DeleteLabel";
            this.DeleteLabel.Size = new System.Drawing.Size(170, 20);
            this.DeleteLabel.TabIndex = 3;
            this.DeleteLabel.Text = "Удаление подстроки";
            // 
            // SearchSubStr2
            // 
            this.SearchSubStr2.Location = new System.Drawing.Point(12, 48);
            this.SearchSubStr2.Name = "SearchSubStr2";
            this.SearchSubStr2.Size = new System.Drawing.Size(154, 23);
            this.SearchSubStr2.TabIndex = 0;
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.LightCoral;
            this.SearchPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchPanel.Controls.Add(this.label1);
            this.SearchPanel.Controls.Add(this.SearchBack);
            this.SearchPanel.Controls.Add(this.SymbolValue);
            this.SearchPanel.Controls.Add(this.Symbol);
            this.SearchPanel.Controls.Add(this.IndexValue);
            this.SearchPanel.Controls.Add(this.Index);
            this.SearchPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchPanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SearchPanel.Location = new System.Drawing.Point(38, 379);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(245, 34);
            this.SearchPanel.TabIndex = 16;
            this.SearchPanel.TabStop = true;
            // 
            // SearchBack
            // 
            this.SearchBack.Location = new System.Drawing.Point(214, 6);
            this.SearchBack.Name = "SearchBack";
            this.SearchBack.Size = new System.Drawing.Size(26, 22);
            this.SearchBack.TabIndex = 4;
            this.SearchBack.Text = "<-";
            this.SearchBack.UseVisualStyleBackColor = true;
            // 
            // SymbolValue
            // 
            this.SymbolValue.AutoSize = true;
            this.SymbolValue.Location = new System.Drawing.Point(159, 3);
            this.SymbolValue.Name = "SymbolValue";
            this.SymbolValue.Size = new System.Drawing.Size(0, 17);
            this.SymbolValue.TabIndex = 3;
            // 
            // Symbol
            // 
            this.Symbol.AutoSize = true;
            this.Symbol.Location = new System.Drawing.Point(112, 6);
            this.Symbol.Name = "Symbol";
            this.Symbol.Size = new System.Drawing.Size(61, 17);
            this.Symbol.TabIndex = 2;
            this.Symbol.Text = "Символ:";
            // 
            // IndexValue
            // 
            this.IndexValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IndexValue.Location = new System.Drawing.Point(61, 3);
            this.IndexValue.Name = "IndexValue";
            this.IndexValue.Size = new System.Drawing.Size(46, 29);
            this.IndexValue.TabIndex = 1;
            this.IndexValue.TextChanged += new System.EventHandler(this.IndexValue_TextChanged);
            // 
            // Index
            // 
            this.Index.AutoSize = true;
            this.Index.Location = new System.Drawing.Point(3, 6);
            this.Index.Name = "Index";
            this.Index.Size = new System.Drawing.Size(60, 17);
            this.Index.TabIndex = 0;
            this.Index.Text = "Индекс:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MistyRose;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(174, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 30);
            this.label1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(587, 438);
            this.Controls.Add(this.SearchPanel);
            this.Controls.Add(this.DeletePanel);
            this.Controls.Add(this.Changing);
            this.Controls.Add(this.inform);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Changing.ResumeLayout(false);
            this.Changing.PerformLayout();
            this.DeletePanel.ResumeLayout(false);
            this.DeletePanel.PerformLayout();
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label inform;
        private System.Windows.Forms.Panel Changing;
        private System.Windows.Forms.Button ChangingBackButton;
        private System.Windows.Forms.Label ChangeLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Label PanelLabel;
        private System.Windows.Forms.Button ChangeOkButton;
        private System.Windows.Forms.TextBox ChangeSubStr;
        private System.Windows.Forms.TextBox SearchSubStr;
        private System.Windows.Forms.Panel DeletePanel;
        private System.Windows.Forms.Button DeleteButtonBack;
        private System.Windows.Forms.Button DeleteOkButton;
        private System.Windows.Forms.Label SearchLabel2;
        private System.Windows.Forms.Label DeleteLabel;
        private System.Windows.Forms.TextBox SearchSubStr2;
        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Button SearchBack;
        private System.Windows.Forms.Label SymbolValue;
        private System.Windows.Forms.Label Symbol;
        private System.Windows.Forms.TextBox IndexValue;
        private System.Windows.Forms.Label Index;
        private System.Windows.Forms.Label label1;
    }
}

