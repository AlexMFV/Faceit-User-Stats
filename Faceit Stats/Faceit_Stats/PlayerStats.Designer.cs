﻿namespace Faceit_Stats
{
    partial class PlayerStats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerStats));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.btnLogo = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnMinimize = new Bunifu.Framework.UI.BunifuImageButton();
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.btnFlag = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblIGN = new System.Windows.Forms.Label();
            this.btnPImage = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblPlayerLevel = new System.Windows.Forms.Label();
            this.prgLevel = new Bunifu.Framework.UI.BunifuCircleProgressbar();
            this.btnRegion = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnGlobalFlag = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblCountryRank = new System.Windows.Forms.Label();
            this.lblRegionRank = new System.Windows.Forms.Label();
            this.lblPlayerELO = new System.Windows.Forms.Label();
            this.lblNextLevel = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.prgElo = new MetroFramework.Controls.MetroProgressBar();
            this.pnlTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).BeginInit();
            this.pnlSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGlobalFlag)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.pnlTopBar.Controls.Add(this.btnLogo);
            this.pnlTopBar.Controls.Add(this.btnClose);
            this.pnlTopBar.Controls.Add(this.btnMinimize);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.MinimumSize = new System.Drawing.Size(0, 30);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(795, 30);
            this.pnlTopBar.TabIndex = 0;
            this.pnlTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseDown);
            this.pnlTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTopBar_MouseMove);
            // 
            // btnLogo
            // 
            this.btnLogo.Image = ((System.Drawing.Image)(resources.GetObject("btnLogo.Image")));
            this.btnLogo.ImageActive = null;
            this.btnLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnLogo.InitialImage")));
            this.btnLogo.Location = new System.Drawing.Point(0, 0);
            this.btnLogo.Name = "btnLogo";
            this.btnLogo.Size = new System.Drawing.Size(34, 30);
            this.btnLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnLogo.TabIndex = 1;
            this.btnLogo.TabStop = false;
            this.btnLogo.Zoom = 10;
            this.btnLogo.Click += new System.EventHandler(this.btnLogo_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::Faceit_Stats.Properties.Resources.close;
            this.btnClose.ImageActive = global::Faceit_Stats.Properties.Resources.close;
            this.btnClose.InitialImage = global::Faceit_Stats.Properties.Resources.close;
            this.btnClose.Location = new System.Drawing.Point(762, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 18);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 0;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMinimize
            // 
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.Image = global::Faceit_Stats.Properties.Resources.Minimize;
            this.btnMinimize.ImageActive = global::Faceit_Stats.Properties.Resources.Minimize;
            this.btnMinimize.InitialImage = global::Faceit_Stats.Properties.Resources.Minimize;
            this.btnMinimize.Location = new System.Drawing.Point(729, 6);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 18);
            this.btnMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Zoom = 0;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(29)))));
            this.pnlSideBar.Controls.Add(this.btnFlag);
            this.pnlSideBar.Controls.Add(this.lblIGN);
            this.pnlSideBar.Controls.Add(this.btnPImage);
            this.pnlSideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSideBar.Location = new System.Drawing.Point(0, 30);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(216, 487);
            this.pnlSideBar.TabIndex = 1;
            // 
            // btnFlag
            // 
            this.btnFlag.Image = ((System.Drawing.Image)(resources.GetObject("btnFlag.Image")));
            this.btnFlag.ImageActive = null;
            this.btnFlag.Location = new System.Drawing.Point(133, 26);
            this.btnFlag.Name = "btnFlag";
            this.btnFlag.Size = new System.Drawing.Size(30, 20);
            this.btnFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnFlag.TabIndex = 2;
            this.btnFlag.TabStop = false;
            this.btnFlag.Zoom = 10;
            // 
            // lblIGN
            // 
            this.lblIGN.Font = new System.Drawing.Font("Fragma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIGN.ForeColor = System.Drawing.Color.White;
            this.lblIGN.Location = new System.Drawing.Point(0, 141);
            this.lblIGN.Name = "lblIGN";
            this.lblIGN.Size = new System.Drawing.Size(216, 28);
            this.lblIGN.TabIndex = 1;
            this.lblIGN.Text = "Username";
            this.lblIGN.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPImage
            // 
            this.btnPImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPImage.Image = ((System.Drawing.Image)(resources.GetObject("btnPImage.Image")));
            this.btnPImage.ImageActive = null;
            this.btnPImage.Location = new System.Drawing.Point(53, 26);
            this.btnPImage.Name = "btnPImage";
            this.btnPImage.Size = new System.Drawing.Size(110, 110);
            this.btnPImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnPImage.TabIndex = 0;
            this.btnPImage.TabStop = false;
            this.btnPImage.Zoom = 0;
            this.btnPImage.Click += new System.EventHandler(this.btnPImage_Click);
            // 
            // lblPlayerLevel
            // 
            this.lblPlayerLevel.Font = new System.Drawing.Font("Fragma", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerLevel.ForeColor = System.Drawing.Color.White;
            this.lblPlayerLevel.Location = new System.Drawing.Point(285, 87);
            this.lblPlayerLevel.Name = "lblPlayerLevel";
            this.lblPlayerLevel.Size = new System.Drawing.Size(79, 43);
            this.lblPlayerLevel.TabIndex = 2;
            this.lblPlayerLevel.Text = "lvl";
            this.lblPlayerLevel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // prgLevel
            // 
            this.prgLevel.animated = false;
            this.prgLevel.animationIterval = 5;
            this.prgLevel.animationSpeed = 300;
            this.prgLevel.BackColor = System.Drawing.Color.Transparent;
            this.prgLevel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("prgLevel.BackgroundImage")));
            this.prgLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F);
            this.prgLevel.ForeColor = System.Drawing.Color.SeaGreen;
            this.prgLevel.LabelVisible = false;
            this.prgLevel.LineProgressThickness = 8;
            this.prgLevel.LineThickness = 5;
            this.prgLevel.Location = new System.Drawing.Point(259, 48);
            this.prgLevel.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.prgLevel.MaxValue = 10;
            this.prgLevel.Name = "prgLevel";
            this.prgLevel.ProgressBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.prgLevel.ProgressColor = System.Drawing.Color.SeaGreen;
            this.prgLevel.Size = new System.Drawing.Size(127, 127);
            this.prgLevel.TabIndex = 3;
            this.prgLevel.Value = 0;
            // 
            // btnRegion
            // 
            this.btnRegion.Image = ((System.Drawing.Image)(resources.GetObject("btnRegion.Image")));
            this.btnRegion.ImageActive = null;
            this.btnRegion.Location = new System.Drawing.Point(427, 75);
            this.btnRegion.Name = "btnRegion";
            this.btnRegion.Size = new System.Drawing.Size(30, 20);
            this.btnRegion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnRegion.TabIndex = 3;
            this.btnRegion.TabStop = false;
            this.btnRegion.Zoom = 10;
            // 
            // btnGlobalFlag
            // 
            this.btnGlobalFlag.Image = ((System.Drawing.Image)(resources.GetObject("btnGlobalFlag.Image")));
            this.btnGlobalFlag.ImageActive = null;
            this.btnGlobalFlag.Location = new System.Drawing.Point(427, 125);
            this.btnGlobalFlag.Name = "btnGlobalFlag";
            this.btnGlobalFlag.Size = new System.Drawing.Size(30, 20);
            this.btnGlobalFlag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnGlobalFlag.TabIndex = 5;
            this.btnGlobalFlag.TabStop = false;
            this.btnGlobalFlag.Zoom = 10;
            // 
            // lblCountryRank
            // 
            this.lblCountryRank.Font = new System.Drawing.Font("Fragma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryRank.ForeColor = System.Drawing.Color.White;
            this.lblCountryRank.Location = new System.Drawing.Point(463, 70);
            this.lblCountryRank.Name = "lblCountryRank";
            this.lblCountryRank.Size = new System.Drawing.Size(129, 26);
            this.lblCountryRank.TabIndex = 6;
            this.lblCountryRank.Text = "Country Rank";
            this.lblCountryRank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRegionRank
            // 
            this.lblRegionRank.Font = new System.Drawing.Font("Fragma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegionRank.ForeColor = System.Drawing.Color.White;
            this.lblRegionRank.Location = new System.Drawing.Point(463, 121);
            this.lblRegionRank.Name = "lblRegionRank";
            this.lblRegionRank.Size = new System.Drawing.Size(129, 26);
            this.lblRegionRank.TabIndex = 7;
            this.lblRegionRank.Text = "Region Rank";
            this.lblRegionRank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlayerELO
            // 
            this.lblPlayerELO.AutoSize = true;
            this.lblPlayerELO.Font = new System.Drawing.Font("Fragma", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerELO.ForeColor = System.Drawing.Color.White;
            this.lblPlayerELO.Location = new System.Drawing.Point(244, 204);
            this.lblPlayerELO.Name = "lblPlayerELO";
            this.lblPlayerELO.Size = new System.Drawing.Size(241, 28);
            this.lblPlayerELO.TabIndex = 9;
            this.lblPlayerELO.Text = "WXX\'s Elo is <Elo Value>";
            // 
            // lblNextLevel
            // 
            this.lblNextLevel.AutoSize = true;
            this.lblNextLevel.Font = new System.Drawing.Font("Fragma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextLevel.ForeColor = System.Drawing.Color.White;
            this.lblNextLevel.Location = new System.Drawing.Point(247, 239);
            this.lblNextLevel.Name = "lblNextLevel";
            this.lblNextLevel.Size = new System.Drawing.Size(257, 15);
            this.lblNextLevel.TabIndex = 10;
            this.lblNextLevel.Text = "To reach level <nextlevel> you need X more points";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(795, 517);
            this.shapeContainer1.TabIndex = 11;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 421;
            this.lineShape2.X2 = 421;
            this.lineShape2.Y1 = 279;
            this.lineShape2.Y2 = 341;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 394;
            this.lineShape1.X2 = 394;
            this.lineShape1.Y1 = 279;
            this.lineShape1.Y2 = 341;
            // 
            // prgElo
            // 
            this.prgElo.Location = new System.Drawing.Point(250, 258);
            this.prgElo.Maximum = 2200;
            this.prgElo.Name = "prgElo";
            this.prgElo.Size = new System.Drawing.Size(518, 23);
            this.prgElo.Style = MetroFramework.MetroColorStyle.Orange;
            this.prgElo.TabIndex = 12;
            this.prgElo.Value = 800;
            // 
            // PlayerStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(795, 517);
            this.Controls.Add(this.prgElo);
            this.Controls.Add(this.lblNextLevel);
            this.Controls.Add(this.lblPlayerELO);
            this.Controls.Add(this.lblRegionRank);
            this.Controls.Add(this.lblCountryRank);
            this.Controls.Add(this.btnGlobalFlag);
            this.Controls.Add(this.btnRegion);
            this.Controls.Add(this.lblPlayerLevel);
            this.Controls.Add(this.pnlSideBar);
            this.Controls.Add(this.pnlTopBar);
            this.Controls.Add(this.prgLevel);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PlayerStats";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PlayerStats";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PlayerStats_FormClosing);
            this.Load += new System.EventHandler(this.PlayerStats_Load);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimize)).EndInit();
            this.pnlSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnFlag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRegion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnGlobalFlag)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private Bunifu.Framework.UI.BunifuImageButton btnMinimize;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuImageButton btnLogo;
        private System.Windows.Forms.Panel pnlSideBar;
        private Bunifu.Framework.UI.BunifuImageButton btnPImage;
        private System.Windows.Forms.Label lblIGN;
        private Bunifu.Framework.UI.BunifuImageButton btnFlag;
        private System.Windows.Forms.Label lblPlayerLevel;
        private Bunifu.Framework.UI.BunifuCircleProgressbar prgLevel;
        private Bunifu.Framework.UI.BunifuImageButton btnRegion;
        private Bunifu.Framework.UI.BunifuImageButton btnGlobalFlag;
        private System.Windows.Forms.Label lblCountryRank;
        private System.Windows.Forms.Label lblRegionRank;
        private System.Windows.Forms.Label lblPlayerELO;
        private System.Windows.Forms.Label lblNextLevel;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private MetroFramework.Controls.MetroProgressBar prgElo;
    }
}