using System.Drawing;

namespace Lab6
{
    partial class Search
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TypeProduct = new System.Windows.Forms.ComboBox();
            this.radioPrice = new System.Windows.Forms.RadioButton();
            this.radioName = new System.Windows.Forms.RadioButton();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonBreak = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 26;
            this.listBox1.Location = new System.Drawing.Point(419, 13);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(561, 368);
            this.listBox1.TabIndex = 12;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.searchTextBox.Location = new System.Drawing.Point(13, 27);
            this.searchTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(368, 37);
            this.searchTextBox.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Plum;
            this.groupBox1.Controls.Add(this.buttonBreak);
            this.groupBox1.Controls.Add(this.TypeProduct);
            this.groupBox1.Controls.Add(this.radioPrice);
            this.groupBox1.Controls.Add(this.radioName);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.groupBox1.Location = new System.Drawing.Point(20, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(361, 174);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выбор параметра поиска";
            // 
            // TypeProduct
            // 
            this.TypeProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TypeProduct.FormattingEnabled = true;
            this.TypeProduct.Items.AddRange(new object[] {
            "Еда",
            "Канцелярия",
            "Одежда",
            "Прочее"});
            this.TypeProduct.Location = new System.Drawing.Point(8, 121);
            this.TypeProduct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TypeProduct.Name = "TypeProduct";
            this.TypeProduct.Size = new System.Drawing.Size(168, 38);
            this.TypeProduct.Sorted = true;
            this.TypeProduct.TabIndex = 16;
            // 
            // radioPrice
            // 
            this.radioPrice.AutoSize = true;
            this.radioPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioPrice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioPrice.Location = new System.Drawing.Point(8, 49);
            this.radioPrice.Margin = new System.Windows.Forms.Padding(4);
            this.radioPrice.Name = "radioPrice";
            this.radioPrice.Size = new System.Drawing.Size(108, 29);
            this.radioPrice.TabIndex = 2;
            this.radioPrice.TabStop = true;
            this.radioPrice.Text = "По цене";
            this.radioPrice.UseVisualStyleBackColor = true;
            // 
            // radioName
            // 
            this.radioName.AutoSize = true;
            this.radioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radioName.Location = new System.Drawing.Point(8, 86);
            this.radioName.Margin = new System.Windows.Forms.Padding(4);
            this.radioName.Name = "radioName";
            this.radioName.Size = new System.Drawing.Size(152, 29);
            this.radioName.TabIndex = 0;
            this.radioName.TabStop = true;
            this.radioName.Text = "По названию";
            this.radioName.UseVisualStyleBackColor = true;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.MediumOrchid;
            this.buttonSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSearch.Location = new System.Drawing.Point(84, 290);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(249, 91);
            this.buttonSearch.TabIndex = 15;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = false;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonBreak
            // 
            this.buttonBreak.BackColor = System.Drawing.Color.DarkViolet;
            this.buttonBreak.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.buttonBreak.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonBreak.Location = new System.Drawing.Point(286, 122);
            this.buttonBreak.Name = "buttonBreak";
            this.buttonBreak.Size = new System.Drawing.Size(75, 52);
            this.buttonBreak.TabIndex = 17;
            this.buttonBreak.Text = "Сбросить";
            this.buttonBreak.UseVisualStyleBackColor = false;
            this.buttonBreak.Click += new System.EventHandler(this.buttonBreak_Click);
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Plum;
            this.ClientSize = new System.Drawing.Size(1014, 410);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.listBox1);
            this.Name = "Search";
            this.Text = "Search";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioPrice;
        private System.Windows.Forms.RadioButton radioName;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.ComboBox TypeProduct;
        private System.Windows.Forms.Button buttonBreak;
    }
}