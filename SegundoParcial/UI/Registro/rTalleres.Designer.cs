namespace SegundoParcial.UI.Registro
{
    partial class rTalleres
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rTalleres));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TallerIdnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.NombretextBox = new System.Windows.Forms.TextBox();
            this.Eliminarbutton = new System.Windows.Forms.Button();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.NuevoButton = new System.Windows.Forms.Button();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TallerIdnumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TallerID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // TallerIdnumericUpDown
            // 
            this.TallerIdnumericUpDown.Location = new System.Drawing.Point(65, 7);
            this.TallerIdnumericUpDown.Name = "TallerIdnumericUpDown";
            this.TallerIdnumericUpDown.Size = new System.Drawing.Size(73, 20);
            this.TallerIdnumericUpDown.TabIndex = 2;
            // 
            // NombretextBox
            // 
            this.NombretextBox.Location = new System.Drawing.Point(65, 38);
            this.NombretextBox.Multiline = true;
            this.NombretextBox.Name = "NombretextBox";
            this.NombretextBox.Size = new System.Drawing.Size(141, 52);
            this.NombretextBox.TabIndex = 3;
            // 
            // Eliminarbutton
            // 
            this.Eliminarbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Eliminarbutton.Image = ((System.Drawing.Image)(resources.GetObject("Eliminarbutton.Image")));
            this.Eliminarbutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Eliminarbutton.Location = new System.Drawing.Point(179, 108);
            this.Eliminarbutton.Name = "Eliminarbutton";
            this.Eliminarbutton.Size = new System.Drawing.Size(80, 43);
            this.Eliminarbutton.TabIndex = 115;
            this.Eliminarbutton.Text = "Eliminar";
            this.Eliminarbutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Eliminarbutton.UseVisualStyleBackColor = true;
            this.Eliminarbutton.Click += new System.EventHandler(this.Eliminarbutton_Click);
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Guardarbutton.Image = ((System.Drawing.Image)(resources.GetObject("Guardarbutton.Image")));
            this.Guardarbutton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Guardarbutton.Location = new System.Drawing.Point(93, 108);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(80, 43);
            this.Guardarbutton.TabIndex = 114;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // NuevoButton
            // 
            this.NuevoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.NuevoButton.Image = ((System.Drawing.Image)(resources.GetObject("NuevoButton.Image")));
            this.NuevoButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.NuevoButton.Location = new System.Drawing.Point(7, 108);
            this.NuevoButton.Name = "NuevoButton";
            this.NuevoButton.Size = new System.Drawing.Size(80, 43);
            this.NuevoButton.TabIndex = 113;
            this.NuevoButton.Text = "Nuevo";
            this.NuevoButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NuevoButton.UseVisualStyleBackColor = true;
            this.NuevoButton.Click += new System.EventHandler(this.NuevoButton_Click);
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = ((System.Drawing.Image)(resources.GetObject("Buscarbutton.Image")));
            this.Buscarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscarbutton.Location = new System.Drawing.Point(144, 4);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(62, 23);
            this.Buscarbutton.TabIndex = 112;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // rTalleres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 163);
            this.Controls.Add(this.Eliminarbutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.NuevoButton);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.NombretextBox);
            this.Controls.Add(this.TallerIdnumericUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "rTalleres";
            this.Text = "rTalleres";
            ((System.ComponentModel.ISupportInitialize)(this.TallerIdnumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TallerIdnumericUpDown;
        private System.Windows.Forms.TextBox NombretextBox;
        private System.Windows.Forms.Button Eliminarbutton;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button NuevoButton;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}