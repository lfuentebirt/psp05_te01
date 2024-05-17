using System.Security.Cryptography;

namespace PSP05_TE_GestorPass
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chVisualizar = new System.Windows.Forms.CheckBox();
            this.chRegistrar = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbContrasenaDescif = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFicheroClave = new System.Windows.Forms.Button();
            this.lbUbicacion = new System.Windows.Forms.Label();
            this.cbVisualizarDesc = new System.Windows.Forms.ComboBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbRegistrarDesc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRegistrarContrasena = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbBorrarDesc = new System.Windows.Forms.ComboBox();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.chBorrar = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.rbRegistroNo = new System.Windows.Forms.RadioButton();
            this.rbRegistroSi = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btnGuardarCerrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUsuario
            // 
            this.tbUsuario.Location = new System.Drawing.Point(109, 28);
            this.tbUsuario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Size = new System.Drawing.Size(205, 22);
            this.tbUsuario.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label3.Location = new System.Drawing.Point(32, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label4.Location = new System.Drawing.Point(28, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(227, 34);
            this.label4.TabIndex = 6;
            this.label4.Text = "El usuario indicado no existe: \r\n¿desea registrarlo?";
            // 
            // chVisualizar
            // 
            this.chVisualizar.AutoSize = true;
            this.chVisualizar.Enabled = false;
            this.chVisualizar.Location = new System.Drawing.Point(36, 64);
            this.chVisualizar.Margin = new System.Windows.Forms.Padding(4);
            this.chVisualizar.Name = "chVisualizar";
            this.chVisualizar.Size = new System.Drawing.Size(159, 20);
            this.chVisualizar.TabIndex = 7;
            this.chVisualizar.Text = "Visualizar Contraseña";
            this.chVisualizar.UseVisualStyleBackColor = true;
            this.chVisualizar.CheckedChanged += new System.EventHandler(this.chVisualizar_CheckedChanged);
            // 
            // chRegistrar
            // 
            this.chRegistrar.AutoSize = true;
            this.chRegistrar.Enabled = false;
            this.chRegistrar.Location = new System.Drawing.Point(36, 92);
            this.chRegistrar.Margin = new System.Windows.Forms.Padding(4);
            this.chRegistrar.Name = "chRegistrar";
            this.chRegistrar.Size = new System.Drawing.Size(156, 20);
            this.chRegistrar.TabIndex = 8;
            this.chRegistrar.Text = "Registrar Contraseña";
            this.chRegistrar.UseVisualStyleBackColor = true;
            this.chRegistrar.CheckedChanged += new System.EventHandler(this.chRegistrar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 108);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Esta es su contraseña:";
            // 
            // tbContrasenaDescif
            // 
            this.tbContrasenaDescif.Location = new System.Drawing.Point(237, 105);
            this.tbContrasenaDescif.Margin = new System.Windows.Forms.Padding(4);
            this.tbContrasenaDescif.Name = "tbContrasenaDescif";
            this.tbContrasenaDescif.Size = new System.Drawing.Size(483, 22);
            this.tbContrasenaDescif.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Registre el fichero de clave:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Elija la descripción:";
            // 
            // btnFicheroClave
            // 
            this.btnFicheroClave.Location = new System.Drawing.Point(237, 63);
            this.btnFicheroClave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFicheroClave.Name = "btnFicheroClave";
            this.btnFicheroClave.Size = new System.Drawing.Size(133, 26);
            this.btnFicheroClave.TabIndex = 13;
            this.btnFicheroClave.Text = "Fichero";
            this.btnFicheroClave.UseVisualStyleBackColor = true;
            this.btnFicheroClave.Click += new System.EventHandler(this.btnFicheroClave_Click);
            // 
            // lbUbicacion
            // 
            this.lbUbicacion.AutoSize = true;
            this.lbUbicacion.Location = new System.Drawing.Point(383, 63);
            this.lbUbicacion.Margin = new System.Windows.Forms.Padding(4);
            this.lbUbicacion.Name = "lbUbicacion";
            this.lbUbicacion.Size = new System.Drawing.Size(138, 16);
            this.lbUbicacion.TabIndex = 14;
            this.lbUbicacion.Text = "Ubicación del Fichero";
            // 
            // cbVisualizarDesc
            // 
            this.cbVisualizarDesc.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.cbVisualizarDesc.FormattingEnabled = true;
            this.cbVisualizarDesc.Location = new System.Drawing.Point(237, 22);
            this.cbVisualizarDesc.Margin = new System.Windows.Forms.Padding(4);
            this.cbVisualizarDesc.Name = "cbVisualizarDesc";
            this.cbVisualizarDesc.Size = new System.Drawing.Size(483, 24);
            this.cbVisualizarDesc.TabIndex = 15;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(321, 28);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(144, 26);
            this.btnRegistrar.TabIndex = 16;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 16);
            this.label7.TabIndex = 17;
            this.label7.Text = "Descipción:";
            // 
            // tbRegistrarDesc
            // 
            this.tbRegistrarDesc.Location = new System.Drawing.Point(237, 27);
            this.tbRegistrarDesc.Margin = new System.Windows.Forms.Padding(4);
            this.tbRegistrarDesc.Name = "tbRegistrarDesc";
            this.tbRegistrarDesc.Size = new System.Drawing.Size(483, 22);
            this.tbRegistrarDesc.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(145, 80);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Contraseña:";
            // 
            // tbRegistrarContrasena
            // 
            this.tbRegistrarContrasena.Location = new System.Drawing.Point(237, 76);
            this.tbRegistrarContrasena.Margin = new System.Windows.Forms.Padding(4);
            this.tbRegistrarContrasena.Name = "tbRegistrarContrasena";
            this.tbRegistrarContrasena.Size = new System.Drawing.Size(483, 22);
            this.tbRegistrarContrasena.TabIndex = 20;
            this.tbRegistrarContrasena.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.cbVisualizarDesc);
            this.groupBox1.Controls.Add(this.lbUbicacion);
            this.groupBox1.Controls.Add(this.btnFicheroClave);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbContrasenaDescif);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(16, 164);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(749, 145);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visualizar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.tbRegistrarContrasena);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbRegistrarDesc);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(16, 316);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(749, 160);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registrar";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(237, 117);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(133, 26);
            this.btnGuardar.TabIndex = 23;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbBorrarDesc);
            this.groupBox3.Controls.Add(this.btnBorrar);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Enabled = false;
            this.groupBox3.Location = new System.Drawing.Point(16, 484);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(749, 105);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Borrar";
            // 
            // cbBorrarDesc
            // 
            this.cbBorrarDesc.FormattingEnabled = true;
            this.cbBorrarDesc.Location = new System.Drawing.Point(237, 23);
            this.cbBorrarDesc.Margin = new System.Windows.Forms.Padding(4);
            this.cbBorrarDesc.Name = "cbBorrarDesc";
            this.cbBorrarDesc.Size = new System.Drawing.Size(483, 24);
            this.cbBorrarDesc.TabIndex = 15;
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(237, 64);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(133, 26);
            this.btnBorrar.TabIndex = 13;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(100, 33);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Elija la descripción:";
            // 
            // chBorrar
            // 
            this.chBorrar.AutoSize = true;
            this.chBorrar.Enabled = false;
            this.chBorrar.Location = new System.Drawing.Point(36, 122);
            this.chBorrar.Margin = new System.Windows.Forms.Padding(4);
            this.chBorrar.Name = "chBorrar";
            this.chBorrar.Size = new System.Drawing.Size(138, 20);
            this.chBorrar.TabIndex = 7;
            this.chBorrar.Text = "Borrar Contraseña";
            this.chBorrar.UseVisualStyleBackColor = true;
            this.chBorrar.CheckedChanged += new System.EventHandler(this.chBorrar_CheckedChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.tbEmail);
            this.groupBox4.Controls.Add(this.btnAceptar);
            this.groupBox4.Controls.Add(this.rbRegistroNo);
            this.groupBox4.Controls.Add(this.rbRegistroSi);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(485, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(293, 156);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Registro Usuario";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 94);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Email:";
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(52, 92);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(205, 22);
            this.tbEmail.TabIndex = 25;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(52, 124);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(133, 26);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // rbRegistroNo
            // 
            this.rbRegistroNo.AutoSize = true;
            this.rbRegistroNo.Checked = true;
            this.rbRegistroNo.Location = new System.Drawing.Point(120, 65);
            this.rbRegistroNo.Margin = new System.Windows.Forms.Padding(4);
            this.rbRegistroNo.Name = "rbRegistroNo";
            this.rbRegistroNo.Size = new System.Drawing.Size(46, 20);
            this.rbRegistroNo.TabIndex = 25;
            this.rbRegistroNo.TabStop = true;
            this.rbRegistroNo.Text = "No";
            this.rbRegistroNo.UseVisualStyleBackColor = true;
            // 
            // rbRegistroSi
            // 
            this.rbRegistroSi.AutoSize = true;
            this.rbRegistroSi.Location = new System.Drawing.Point(67, 65);
            this.rbRegistroSi.Margin = new System.Windows.Forms.Padding(4);
            this.rbRegistroSi.Name = "rbRegistroSi";
            this.rbRegistroSi.Size = new System.Drawing.Size(40, 20);
            this.rbRegistroSi.TabIndex = 24;
            this.rbRegistroSi.Text = "Si";
            this.rbRegistroSi.UseVisualStyleBackColor = true;
            this.rbRegistroSi.CheckedChanged += new System.EventHandler(this.rbRegistroSi_CheckedChanged);
            // 
            // btnGuardarCerrar
            // 
            this.btnGuardarCerrar.Location = new System.Drawing.Point(668, 596);
            this.btnGuardarCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarCerrar.Name = "btnGuardarCerrar";
            this.btnGuardarCerrar.Size = new System.Drawing.Size(139, 28);
            this.btnGuardarCerrar.TabIndex = 24;
            this.btnGuardarCerrar.Text = "Guardar y Cerrar";
            this.btnGuardarCerrar.UseVisualStyleBackColor = true;
            this.btnGuardarCerrar.Click += new System.EventHandler(this.btnGuardarCerrar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(823, 639);
            this.Controls.Add(this.btnGuardarCerrar);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chBorrar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.chRegistrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbUsuario);
            this.Controls.Add(this.chVisualizar);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "UD05 Gestor Password";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chVisualizar;
        private System.Windows.Forms.CheckBox chRegistrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbContrasenaDescif;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFicheroClave;
        private System.Windows.Forms.Label lbUbicacion;
        private System.Windows.Forms.ComboBox cbVisualizarDesc;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbRegistrarDesc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRegistrarContrasena;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbBorrarDesc;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chBorrar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.RadioButton rbRegistroNo;
        private System.Windows.Forms.RadioButton rbRegistroSi;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btnGuardarCerrar;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label9;
    }
}

