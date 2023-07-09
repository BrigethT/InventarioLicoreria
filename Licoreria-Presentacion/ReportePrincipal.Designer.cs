
namespace Licoreria_Presentacion
{
    partial class ReportePrincipal
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
            System.Windows.Forms.Button btnPMC;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportePrincipal));
            this.btnExistenciasP = new System.Windows.Forms.Button();
            this.btnDeudores = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            btnPMC = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPMC
            // 
            btnPMC.BackColor = System.Drawing.Color.White;
            btnPMC.FlatAppearance.BorderSize = 3;
            btnPMC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnPMC.Image = ((System.Drawing.Image)(resources.GetObject("btnPMC.Image")));
            btnPMC.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            btnPMC.Location = new System.Drawing.Point(137, 48);
            btnPMC.Name = "btnPMC";
            btnPMC.Size = new System.Drawing.Size(230, 40);
            btnPMC.TabIndex = 17;
            btnPMC.Text = "Productos mas consumidos";
            btnPMC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btnPMC.UseVisualStyleBackColor = false;
            btnPMC.Click += new System.EventHandler(this.btnPMC_Click);
            // 
            // btnExistenciasP
            // 
            this.btnExistenciasP.BackColor = System.Drawing.Color.White;
            this.btnExistenciasP.FlatAppearance.BorderSize = 3;
            this.btnExistenciasP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExistenciasP.Image = ((System.Drawing.Image)(resources.GetObject("btnExistenciasP.Image")));
            this.btnExistenciasP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExistenciasP.Location = new System.Drawing.Point(137, 94);
            this.btnExistenciasP.Name = "btnExistenciasP";
            this.btnExistenciasP.Size = new System.Drawing.Size(230, 40);
            this.btnExistenciasP.TabIndex = 18;
            this.btnExistenciasP.Text = "Existencias de productos\r\n";
            this.btnExistenciasP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExistenciasP.UseVisualStyleBackColor = false;
            this.btnExistenciasP.Click += new System.EventHandler(this.btnExistenciasP_Click);
            // 
            // btnDeudores
            // 
            this.btnDeudores.BackColor = System.Drawing.Color.White;
            this.btnDeudores.FlatAppearance.BorderSize = 3;
            this.btnDeudores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeudores.Image = ((System.Drawing.Image)(resources.GetObject("btnDeudores.Image")));
            this.btnDeudores.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeudores.Location = new System.Drawing.Point(137, 139);
            this.btnDeudores.Name = "btnDeudores";
            this.btnDeudores.Size = new System.Drawing.Size(230, 40);
            this.btnDeudores.TabIndex = 19;
            this.btnDeudores.Text = "Deudores Actuales\r\n\r\n";
            this.btnDeudores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeudores.UseVisualStyleBackColor = false;
            this.btnDeudores.Click += new System.EventHandler(this.btnDeudores_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::Licoreria_Presentacion.Properties.Resources.hacia_atras;
            this.pictureBox2.Location = new System.Drawing.Point(1, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 17);
            this.label1.TabIndex = 20;
            this.label1.Text = "Seleccione el reporte que desee: ";
            // 
            // ReportePrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(521, 221);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeudores);
            this.Controls.Add(this.btnExistenciasP);
            this.Controls.Add(btnPMC);
            this.Controls.Add(this.pictureBox2);
            this.Location = new System.Drawing.Point(500, 185);
            this.Name = "ReportePrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportePrincipal";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnExistenciasP;
        private System.Windows.Forms.Button btnDeudores;
        private System.Windows.Forms.Label label1;
    }
}