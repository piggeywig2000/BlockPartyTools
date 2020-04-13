namespace BlockPartyTools
{
    partial class FormColourDisplay
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
            this.labelCurrentColour = new System.Windows.Forms.Label();
            this.timerSetColour = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelCurrentColour
            // 
            this.labelCurrentColour.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentColour.BackColor = System.Drawing.Color.Transparent;
            this.labelCurrentColour.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrentColour.Location = new System.Drawing.Point(12, 9);
            this.labelCurrentColour.Name = "labelCurrentColour";
            this.labelCurrentColour.Size = new System.Drawing.Size(360, 343);
            this.labelCurrentColour.TabIndex = 0;
            this.labelCurrentColour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerSetColour
            // 
            this.timerSetColour.Enabled = true;
            this.timerSetColour.Interval = 50;
            this.timerSetColour.Tick += new System.EventHandler(this.timerSetColour_Tick);
            // 
            // FormColourDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.labelCurrentColour);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 16);
            this.Name = "FormColourDisplay";
            this.Text = "Colour Display";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelCurrentColour;
        private System.Windows.Forms.Timer timerSetColour;
    }
}