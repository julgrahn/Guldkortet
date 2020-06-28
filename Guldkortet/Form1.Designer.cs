namespace Guldkortet
{
    partial class Guldkortet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Guldkortet));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TbxReception = new System.Windows.Forms.TextBox();
            this.BtnStartServer = new System.Windows.Forms.Button();
            this.BtnUpdateUser = new System.Windows.Forms.Button();
            this.BtnUpdateCard = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.PbxGuldkort = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxGuldkort)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 143);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TbxReception
            // 
            this.TbxReception.Location = new System.Drawing.Point(203, 13);
            this.TbxReception.Multiline = true;
            this.TbxReception.Name = "TbxReception";
            this.TbxReception.Size = new System.Drawing.Size(517, 143);
            this.TbxReception.TabIndex = 1;
            // 
            // BtnStartServer
            // 
            this.BtnStartServer.Location = new System.Drawing.Point(12, 162);
            this.BtnStartServer.Name = "BtnStartServer";
            this.BtnStartServer.Size = new System.Drawing.Size(474, 33);
            this.BtnStartServer.TabIndex = 2;
            this.BtnStartServer.Text = "Start the Server";
            this.BtnStartServer.UseVisualStyleBackColor = true;
            this.BtnStartServer.Click += new System.EventHandler(this.BtnStartServer_Click);
            // 
            // BtnUpdateUser
            // 
            this.BtnUpdateUser.Location = new System.Drawing.Point(13, 201);
            this.BtnUpdateUser.Name = "BtnUpdateUser";
            this.BtnUpdateUser.Size = new System.Drawing.Size(474, 33);
            this.BtnUpdateUser.TabIndex = 4;
            this.BtnUpdateUser.Text = "Update Userlist";
            this.BtnUpdateUser.UseVisualStyleBackColor = true;
            this.BtnUpdateUser.Click += new System.EventHandler(this.BtnUpdateUser_Click);
            // 
            // BtnUpdateCard
            // 
            this.BtnUpdateCard.Location = new System.Drawing.Point(13, 240);
            this.BtnUpdateCard.Name = "BtnUpdateCard";
            this.BtnUpdateCard.Size = new System.Drawing.Size(474, 33);
            this.BtnUpdateCard.TabIndex = 5;
            this.BtnUpdateCard.Text = "Update Cardlist";
            this.BtnUpdateCard.UseVisualStyleBackColor = true;
            this.BtnUpdateCard.Click += new System.EventHandler(this.BtnUpdateCard_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Location = new System.Drawing.Point(12, 279);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(474, 33);
            this.BtnExit.TabIndex = 6;
            this.BtnExit.Text = "Exit";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // PbxGuldkort
            // 
            this.PbxGuldkort.Location = new System.Drawing.Point(494, 163);
            this.PbxGuldkort.Name = "PbxGuldkort";
            this.PbxGuldkort.Size = new System.Drawing.Size(226, 149);
            this.PbxGuldkort.TabIndex = 7;
            this.PbxGuldkort.TabStop = false;
            this.PbxGuldkort.Click += new System.EventHandler(this.PbxGuldkort_Click);
            // 
            // Guldkortet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 314);
            this.Controls.Add(this.PbxGuldkort);
            this.Controls.Add(this.BtnExit);
            this.Controls.Add(this.BtnUpdateCard);
            this.Controls.Add(this.BtnUpdateUser);
            this.Controls.Add(this.BtnStartServer);
            this.Controls.Add(this.TbxReception);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Guldkortet";
            this.Text = "Guldkortet";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxGuldkort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TbxReception;
        private System.Windows.Forms.Button BtnStartServer;
        private System.Windows.Forms.Button BtnUpdateUser;
        private System.Windows.Forms.Button BtnUpdateCard;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.PictureBox PbxGuldkort;
    }
}

