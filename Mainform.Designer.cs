namespace MaimaiNetCrawler
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListViewSongs = new System.Windows.Forms.ListView();
            this.ColGenre = new System.Windows.Forms.ColumnHeader();
            this.ColSongName = new System.Windows.Forms.ColumnHeader();
            this.ColArtist = new System.Windows.Forms.ColumnHeader();
            this.ColTabType = new System.Windows.Forms.ColumnHeader();
            this.ColDiffBasic = new System.Windows.Forms.ColumnHeader();
            this.ColDiffNormal = new System.Windows.Forms.ColumnHeader();
            this.ColDiffExpert = new System.Windows.Forms.ColumnHeader();
            this.ColDiffMaster = new System.Windows.Forms.ColumnHeader();
            this.ColDiffReMaster = new System.Windows.Forms.ColumnHeader();
            this.ColTabType2 = new System.Windows.Forms.ColumnHeader();
            this.ColDiffBasic2 = new System.Windows.Forms.ColumnHeader();
            this.ColDiffNormal2 = new System.Windows.Forms.ColumnHeader();
            this.ColDiffExpert2 = new System.Windows.Forms.ColumnHeader();
            this.ColDiffMaster2 = new System.Windows.Forms.ColumnHeader();
            this.ColDiffReMaster2 = new System.Windows.Forms.ColumnHeader();
            this.ColLocked = new System.Windows.Forms.ColumnHeader();
            this.btStart = new System.Windows.Forms.Button();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btSaveAs = new System.Windows.Forms.Button();
            this.pgBar = new System.Windows.Forms.ProgressBar();
            this.btnDropDuplicated = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ListViewSongs
            // 
            this.ListViewSongs.AllowColumnReorder = true;
            this.ListViewSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColGenre,
            this.ColSongName,
            this.ColArtist,
            this.ColTabType,
            this.ColDiffBasic,
            this.ColDiffNormal,
            this.ColDiffExpert,
            this.ColDiffMaster,
            this.ColDiffReMaster,
            this.ColTabType2,
            this.ColDiffBasic2,
            this.ColDiffNormal2,
            this.ColDiffExpert2,
            this.ColDiffMaster2,
            this.ColDiffReMaster2,
            this.ColLocked});
            this.ListViewSongs.FullRowSelect = true;
            this.ListViewSongs.Location = new System.Drawing.Point(12, 66);
            this.ListViewSongs.Name = "ListViewSongs";
            this.ListViewSongs.Size = new System.Drawing.Size(1140, 669);
            this.ListViewSongs.TabIndex = 0;
            this.ListViewSongs.UseCompatibleStateImageBehavior = false;
            this.ListViewSongs.View = System.Windows.Forms.View.Details;
            // 
            // ColGenre
            // 
            this.ColGenre.Text = "Genre";
            this.ColGenre.Width = 120;
            // 
            // ColSongName
            // 
            this.ColSongName.Text = "Title";
            this.ColSongName.Width = 240;
            // 
            // ColArtist
            // 
            this.ColArtist.Text = "Artist";
            this.ColArtist.Width = 200;
            // 
            // ColTabType
            // 
            this.ColTabType.Text = "Type";
            this.ColTabType.Width = 100;
            // 
            // ColDiffBasic
            // 
            this.ColDiffBasic.Text = "B";
            this.ColDiffBasic.Width = 30;
            // 
            // ColDiffNormal
            // 
            this.ColDiffNormal.Text = "N";
            this.ColDiffNormal.Width = 30;
            // 
            // ColDiffExpert
            // 
            this.ColDiffExpert.Text = "E";
            this.ColDiffExpert.Width = 30;
            // 
            // ColDiffMaster
            // 
            this.ColDiffMaster.Text = "M";
            this.ColDiffMaster.Width = 30;
            // 
            // ColDiffReMaster
            // 
            this.ColDiffReMaster.Text = "R";
            this.ColDiffReMaster.Width = 30;
            // 
            // ColTabType2
            // 
            this.ColTabType2.Text = "Type";
            this.ColTabType2.Width = 100;
            // 
            // ColDiffBasic2
            // 
            this.ColDiffBasic2.Text = "B";
            this.ColDiffBasic2.Width = 30;
            // 
            // ColDiffNormal2
            // 
            this.ColDiffNormal2.Text = "N";
            this.ColDiffNormal2.Width = 30;
            // 
            // ColDiffExpert2
            // 
            this.ColDiffExpert2.Text = "E";
            this.ColDiffExpert2.Width = 30;
            // 
            // ColDiffMaster2
            // 
            this.ColDiffMaster2.Text = "M";
            this.ColDiffMaster2.Width = 30;
            // 
            // ColDiffReMaster2
            // 
            this.ColDiffReMaster2.Text = "R";
            this.ColDiffReMaster2.Width = 30;
            // 
            // ColLocked
            // 
            this.ColLocked.Text = "Locked";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(1077, 12);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // tbURL
            // 
            this.tbURL.Enabled = false;
            this.tbURL.Location = new System.Drawing.Point(46, 12);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(1025, 23);
            this.tbURL.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Result";
            // 
            // btSaveAs
            // 
            this.btSaveAs.Location = new System.Drawing.Point(1077, 741);
            this.btSaveAs.Name = "btSaveAs";
            this.btSaveAs.Size = new System.Drawing.Size(75, 23);
            this.btSaveAs.TabIndex = 5;
            this.btSaveAs.Text = "Save As";
            this.btSaveAs.UseVisualStyleBackColor = true;
            // 
            // pgBar
            // 
            this.pgBar.Location = new System.Drawing.Point(12, 741);
            this.pgBar.Name = "pgBar";
            this.pgBar.Size = new System.Drawing.Size(337, 23);
            this.pgBar.TabIndex = 6;
            // 
            // btnDropDuplicated
            // 
            this.btnDropDuplicated.Location = new System.Drawing.Point(957, 741);
            this.btnDropDuplicated.Name = "btnDropDuplicated";
            this.btnDropDuplicated.Size = new System.Drawing.Size(114, 23);
            this.btnDropDuplicated.TabIndex = 7;
            this.btnDropDuplicated.Text = "Drop Duplicated";
            this.btnDropDuplicated.UseVisualStyleBackColor = true;
            this.btnDropDuplicated.Click += new System.EventHandler(this.btnDropDuplicated_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(837, 741);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(114, 23);
            this.btnDeleteAll.TabIndex = 8;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(355, 745);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Status : ";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(400, 745);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(26, 15);
            this.lbStatus.TabIndex = 10;
            this.lbStatus.Text = "Idle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 776);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnDropDuplicated);
            this.Controls.Add(this.pgBar);
            this.Controls.Add(this.btSaveAs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.ListViewSongs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Maimai crawler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView ListViewSongs;
        private ColumnHeader ColSongName;
        private ColumnHeader ColArtist;
        private ColumnHeader ColTabType;
        private ColumnHeader ColDiffBasic;
        private Button btStart;
        private TextBox tbURL;
        private Label label1;
        private Label label2;
        private Button btSaveAs;
        private ColumnHeader ColDiffNormal;
        private ColumnHeader ColDiffExpert;
        private ColumnHeader ColDiffMaster;
        private ColumnHeader ColDiffReMaster;
        private ColumnHeader ColTabType2;
        private ColumnHeader ColDiffBasic2;
        private ColumnHeader ColDiffNormal2;
        private ColumnHeader ColDiffExpert2;
        private ColumnHeader ColDiffMaster2;
        private ColumnHeader ColDiffReMaster2;
        private ProgressBar pgBar;
        private Button btnDropDuplicated;
        private ColumnHeader ColGenre;
        private ColumnHeader ColLocked;
        private Button btnDeleteAll;
        private Label label3;
        private Label lbStatus;
    }
}