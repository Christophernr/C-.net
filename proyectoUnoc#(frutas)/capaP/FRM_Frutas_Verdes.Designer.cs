namespace capaP
{
    partial class FRM_Frutas_Verdes
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
            this.txtFrutasVerdes = new System.Windows.Forms.TextBox();
            this.btn_GuardarVerdes = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFrutasVerdes
            // 
            this.txtFrutasVerdes.Location = new System.Drawing.Point(334, 85);
            this.txtFrutasVerdes.Name = "txtFrutasVerdes";
            this.txtFrutasVerdes.Size = new System.Drawing.Size(110, 22);
            this.txtFrutasVerdes.TabIndex = 0;
            // 
            // btn_GuardarVerdes
            // 
            this.btn_GuardarVerdes.Location = new System.Drawing.Point(352, 225);
            this.btn_GuardarVerdes.Name = "btn_GuardarVerdes";
            this.btn_GuardarVerdes.Size = new System.Drawing.Size(75, 23);
            this.btn_GuardarVerdes.TabIndex = 1;
            this.btn_GuardarVerdes.Text = "Guardar";
            this.btn_GuardarVerdes.UseVisualStyleBackColor = true;
            this.btn_GuardarVerdes.Click += new System.EventHandler(this.btn_GuardarVerdes_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(331, 154);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(113, 22);
            this.txtPrecio.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(328, 42);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(129, 16);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre Fruta Verde";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Location = new System.Drawing.Point(328, 122);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(119, 16);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio Fruta Verde";
            // 
            // FRM_Frutas_Verdes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.btn_GuardarVerdes);
            this.Controls.Add(this.txtFrutasVerdes);
            this.Name = "FRM_Frutas_Verdes";
            this.Text = "FRM_Frutas_Verdes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFrutasVerdes;
        private System.Windows.Forms.Button btn_GuardarVerdes;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblPrecio;
    }
}