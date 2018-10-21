namespace Expresiones_aritméticas
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtExpresión = new System.Windows.Forms.TextBox();
            this.btnResolver = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Escriba una expresión a resolver:";
            // 
            // txtExpresión
            // 
            this.txtExpresión.Location = new System.Drawing.Point(12, 36);
            this.txtExpresión.Name = "txtExpresión";
            this.txtExpresión.Size = new System.Drawing.Size(317, 24);
            this.txtExpresión.TabIndex = 1;
            // 
            // btnResolver
            // 
            this.btnResolver.AutoSize = true;
            this.btnResolver.Location = new System.Drawing.Point(132, 66);
            this.btnResolver.Name = "btnResolver";
            this.btnResolver.Size = new System.Drawing.Size(77, 28);
            this.btnResolver.TabIndex = 4;
            this.btnResolver.Text = "Resolver";
            this.btnResolver.UseVisualStyleBackColor = true;
            this.btnResolver.Click += new System.EventHandler(this.btnResolver_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Location = new System.Drawing.Point(168, 100);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(97, 24);
            this.txtResultado.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Resultado:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 139);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnResolver);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.txtExpresión);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Expresiones aritméticas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExpresión;
        private System.Windows.Forms.Button btnResolver;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label2;
    }
}

