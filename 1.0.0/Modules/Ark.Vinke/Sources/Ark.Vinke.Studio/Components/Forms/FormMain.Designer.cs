
namespace Ark.Vinke.Studio
{
    partial class FormMain
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
            tabControl = new Lazy.Vinke.Windows.Forms.LazyTabControl();
            tabPageProject = new System.Windows.Forms.TabPage();
            checkBoxProjectGenerateBatchFiles = new Lazy.Vinke.Windows.Forms.LazyCheckBox();
            labelFeatureRepositoryUrl = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxProjectRepositoryUrl = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            buttonProjectGenerate = new Lazy.Vinke.Windows.Forms.LazyButton();
            checkBoxProjectGenerateSolutionModule = new Lazy.Vinke.Windows.Forms.LazyCheckBox();
            checkBoxProjectGenerateSolution = new Lazy.Vinke.Windows.Forms.LazyCheckBox();
            buttonProjectExplore = new Lazy.Vinke.Windows.Forms.LazyButton();
            labelProjectDestinationPath = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxProjectDestinationPath = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            labelProjectName = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxProjectName = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            labelProjectModule = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxProjectModule = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            labelProjectDeveloper = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxProjectDeveloper = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            textBoxProjectProduct = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            labelProjectProduct = new Lazy.Vinke.Windows.Forms.LazyLabel();
            tabControl.SuspendLayout();
            tabPageProject.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageProject);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.DockOnCenter = false;
            tabControl.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabControl.Location = new System.Drawing.Point(8, 8);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(736, 482);
            tabControl.TabIndex = 0;
            // 
            // tabPageProject
            // 
            tabPageProject.Controls.Add(checkBoxProjectGenerateBatchFiles);
            tabPageProject.Controls.Add(labelFeatureRepositoryUrl);
            tabPageProject.Controls.Add(textBoxProjectRepositoryUrl);
            tabPageProject.Controls.Add(buttonProjectGenerate);
            tabPageProject.Controls.Add(checkBoxProjectGenerateSolutionModule);
            tabPageProject.Controls.Add(checkBoxProjectGenerateSolution);
            tabPageProject.Controls.Add(buttonProjectExplore);
            tabPageProject.Controls.Add(labelProjectDestinationPath);
            tabPageProject.Controls.Add(textBoxProjectDestinationPath);
            tabPageProject.Controls.Add(labelProjectName);
            tabPageProject.Controls.Add(textBoxProjectName);
            tabPageProject.Controls.Add(labelProjectModule);
            tabPageProject.Controls.Add(textBoxProjectModule);
            tabPageProject.Controls.Add(labelProjectDeveloper);
            tabPageProject.Controls.Add(textBoxProjectDeveloper);
            tabPageProject.Controls.Add(textBoxProjectProduct);
            tabPageProject.Controls.Add(labelProjectProduct);
            tabPageProject.Location = new System.Drawing.Point(4, 36);
            tabPageProject.Name = "tabPageProject";
            tabPageProject.Padding = new System.Windows.Forms.Padding(3);
            tabPageProject.Size = new System.Drawing.Size(728, 442);
            tabPageProject.TabIndex = 0;
            tabPageProject.Text = "Project";
            tabPageProject.UseVisualStyleBackColor = true;
            // 
            // checkBoxProjectGenerateBatchFiles
            // 
            checkBoxProjectGenerateBatchFiles.AutoSize = true;
            checkBoxProjectGenerateBatchFiles.Checked = true;
            checkBoxProjectGenerateBatchFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxProjectGenerateBatchFiles.DockOnCenter = false;
            checkBoxProjectGenerateBatchFiles.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBoxProjectGenerateBatchFiles.Location = new System.Drawing.Point(29, 320);
            checkBoxProjectGenerateBatchFiles.Name = "checkBoxProjectGenerateBatchFiles";
            checkBoxProjectGenerateBatchFiles.Size = new System.Drawing.Size(274, 31);
            checkBoxProjectGenerateBatchFiles.TabIndex = 20;
            checkBoxProjectGenerateBatchFiles.Text = "Generate batch files";
            checkBoxProjectGenerateBatchFiles.UseVisualStyleBackColor = true;
            // 
            // labelFeatureRepositoryUrl
            // 
            labelFeatureRepositoryUrl.AutoSize = true;
            labelFeatureRepositoryUrl.DockOnCenter = false;
            labelFeatureRepositoryUrl.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeatureRepositoryUrl.Location = new System.Drawing.Point(29, 171);
            labelFeatureRepositoryUrl.Name = "labelFeatureRepositoryUrl";
            labelFeatureRepositoryUrl.Size = new System.Drawing.Size(180, 27);
            labelFeatureRepositoryUrl.TabIndex = 18;
            labelFeatureRepositoryUrl.Text = "Repository url";
            // 
            // textBoxProjectRepositoryUrl
            // 
            textBoxProjectRepositoryUrl.DockOnCenter = false;
            textBoxProjectRepositoryUrl.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxProjectRepositoryUrl.Location = new System.Drawing.Point(29, 201);
            textBoxProjectRepositoryUrl.Name = "textBoxProjectRepositoryUrl";
            textBoxProjectRepositoryUrl.Size = new System.Drawing.Size(631, 31);
            textBoxProjectRepositoryUrl.TabIndex = 19;
            textBoxProjectRepositoryUrl.Text = "https://github.com/isaacsaraiva-vinke/Ark.Isaac";
            // 
            // buttonProjectGenerate
            // 
            buttonProjectGenerate.DockOnCenter = false;
            buttonProjectGenerate.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonProjectGenerate.Location = new System.Drawing.Point(302, 394);
            buttonProjectGenerate.Name = "buttonProjectGenerate";
            buttonProjectGenerate.Size = new System.Drawing.Size(125, 42);
            buttonProjectGenerate.TabIndex = 13;
            buttonProjectGenerate.Text = "Generate";
            buttonProjectGenerate.UseVisualStyleBackColor = true;
            buttonProjectGenerate.Click += OnButtonProjectGenerate_Click;
            // 
            // checkBoxProjectGenerateSolutionModule
            // 
            checkBoxProjectGenerateSolutionModule.AutoSize = true;
            checkBoxProjectGenerateSolutionModule.Checked = true;
            checkBoxProjectGenerateSolutionModule.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxProjectGenerateSolutionModule.DockOnCenter = false;
            checkBoxProjectGenerateSolutionModule.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBoxProjectGenerateSolutionModule.Location = new System.Drawing.Point(29, 283);
            checkBoxProjectGenerateSolutionModule.Name = "checkBoxProjectGenerateSolutionModule";
            checkBoxProjectGenerateSolutionModule.Size = new System.Drawing.Size(310, 31);
            checkBoxProjectGenerateSolutionModule.TabIndex = 12;
            checkBoxProjectGenerateSolutionModule.Text = "Generate module project";
            checkBoxProjectGenerateSolutionModule.UseVisualStyleBackColor = true;
            checkBoxProjectGenerateSolutionModule.CheckedChanged += OnCheckBoxProjectGenerateSolutionModule_CheckedChanged;
            // 
            // checkBoxProjectGenerateSolution
            // 
            checkBoxProjectGenerateSolution.AutoSize = true;
            checkBoxProjectGenerateSolution.Checked = true;
            checkBoxProjectGenerateSolution.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxProjectGenerateSolution.DockOnCenter = false;
            checkBoxProjectGenerateSolution.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBoxProjectGenerateSolution.Location = new System.Drawing.Point(29, 246);
            checkBoxProjectGenerateSolution.Name = "checkBoxProjectGenerateSolution";
            checkBoxProjectGenerateSolution.Size = new System.Drawing.Size(238, 31);
            checkBoxProjectGenerateSolution.TabIndex = 11;
            checkBoxProjectGenerateSolution.Text = "Generate solution";
            checkBoxProjectGenerateSolution.UseVisualStyleBackColor = true;
            checkBoxProjectGenerateSolution.CheckedChanged += OnCheckBoxProjectGenerateSolution_CheckedChanged;
            // 
            // buttonProjectExplore
            // 
            buttonProjectExplore.DockOnCenter = false;
            buttonProjectExplore.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonProjectExplore.Location = new System.Drawing.Point(666, 129);
            buttonProjectExplore.Name = "buttonProjectExplore";
            buttonProjectExplore.Size = new System.Drawing.Size(31, 31);
            buttonProjectExplore.TabIndex = 10;
            buttonProjectExplore.UseVisualStyleBackColor = true;
            // 
            // labelProjectDestinationPath
            // 
            labelProjectDestinationPath.AutoSize = true;
            labelProjectDestinationPath.DockOnCenter = false;
            labelProjectDestinationPath.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelProjectDestinationPath.Location = new System.Drawing.Point(29, 99);
            labelProjectDestinationPath.Name = "labelProjectDestinationPath";
            labelProjectDestinationPath.Size = new System.Drawing.Size(204, 27);
            labelProjectDestinationPath.TabIndex = 8;
            labelProjectDestinationPath.Text = "Destination path";
            // 
            // textBoxProjectDestinationPath
            // 
            textBoxProjectDestinationPath.DockOnCenter = false;
            textBoxProjectDestinationPath.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxProjectDestinationPath.Location = new System.Drawing.Point(29, 129);
            textBoxProjectDestinationPath.Name = "textBoxProjectDestinationPath";
            textBoxProjectDestinationPath.Size = new System.Drawing.Size(631, 31);
            textBoxProjectDestinationPath.TabIndex = 9;
            textBoxProjectDestinationPath.Text = "C:\\Users\\isaac\\Downloads\\Sources";
            // 
            // labelProjectName
            // 
            labelProjectName.AutoSize = true;
            labelProjectName.DockOnCenter = false;
            labelProjectName.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelProjectName.Location = new System.Drawing.Point(522, 27);
            labelProjectName.Name = "labelProjectName";
            labelProjectName.Size = new System.Drawing.Size(96, 27);
            labelProjectName.TabIndex = 6;
            labelProjectName.Text = "Project";
            // 
            // textBoxProjectName
            // 
            textBoxProjectName.DockOnCenter = false;
            textBoxProjectName.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxProjectName.Location = new System.Drawing.Point(522, 57);
            textBoxProjectName.Name = "textBoxProjectName";
            textBoxProjectName.Size = new System.Drawing.Size(175, 31);
            textBoxProjectName.TabIndex = 7;
            textBoxProjectName.Text = "Investment";
            textBoxProjectName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelProjectModule
            // 
            labelProjectModule.AutoSize = true;
            labelProjectModule.DockOnCenter = false;
            labelProjectModule.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelProjectModule.Location = new System.Drawing.Point(341, 27);
            labelProjectModule.Name = "labelProjectModule";
            labelProjectModule.Size = new System.Drawing.Size(84, 27);
            labelProjectModule.TabIndex = 4;
            labelProjectModule.Text = "Module";
            // 
            // textBoxProjectModule
            // 
            textBoxProjectModule.DockOnCenter = false;
            textBoxProjectModule.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxProjectModule.Location = new System.Drawing.Point(341, 57);
            textBoxProjectModule.Name = "textBoxProjectModule";
            textBoxProjectModule.Size = new System.Drawing.Size(175, 31);
            textBoxProjectModule.TabIndex = 5;
            textBoxProjectModule.Text = "Financial";
            textBoxProjectModule.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelProjectDeveloper
            // 
            labelProjectDeveloper.AutoSize = true;
            labelProjectDeveloper.DockOnCenter = false;
            labelProjectDeveloper.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelProjectDeveloper.Location = new System.Drawing.Point(160, 27);
            labelProjectDeveloper.Name = "labelProjectDeveloper";
            labelProjectDeveloper.Size = new System.Drawing.Size(120, 27);
            labelProjectDeveloper.TabIndex = 2;
            labelProjectDeveloper.Text = "Developer";
            // 
            // textBoxProjectDeveloper
            // 
            textBoxProjectDeveloper.DockOnCenter = false;
            textBoxProjectDeveloper.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxProjectDeveloper.Location = new System.Drawing.Point(160, 57);
            textBoxProjectDeveloper.Name = "textBoxProjectDeveloper";
            textBoxProjectDeveloper.Size = new System.Drawing.Size(175, 31);
            textBoxProjectDeveloper.TabIndex = 3;
            textBoxProjectDeveloper.Text = "Isaac";
            textBoxProjectDeveloper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxProjectProduct
            // 
            textBoxProjectProduct.DockOnCenter = false;
            textBoxProjectProduct.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxProjectProduct.Location = new System.Drawing.Point(29, 57);
            textBoxProjectProduct.Name = "textBoxProjectProduct";
            textBoxProjectProduct.ReadOnly = true;
            textBoxProjectProduct.Size = new System.Drawing.Size(125, 31);
            textBoxProjectProduct.TabIndex = 1;
            textBoxProjectProduct.Text = "Ark";
            textBoxProjectProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelProjectProduct
            // 
            labelProjectProduct.AutoSize = true;
            labelProjectProduct.DockOnCenter = false;
            labelProjectProduct.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelProjectProduct.Location = new System.Drawing.Point(29, 27);
            labelProjectProduct.Name = "labelProjectProduct";
            labelProjectProduct.Size = new System.Drawing.Size(96, 27);
            labelProjectProduct.TabIndex = 0;
            labelProjectProduct.Text = "Product";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(752, 498);
            Controls.Add(tabControl);
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMain";
            Padding = new System.Windows.Forms.Padding(8);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Ark Vinke Studio";
            tabControl.ResumeLayout(false);
            tabPageProject.ResumeLayout(false);
            tabPageProject.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Lazy.Vinke.Windows.Forms.LazyTabControl tabControl;
        private System.Windows.Forms.TabPage tabPageProject;
        private Lazy.Vinke.Windows.Forms.LazyCheckBox checkBoxProjectGenerateSolutionModule;
        private Lazy.Vinke.Windows.Forms.LazyCheckBox checkBoxProjectGenerateSolution;
        private Lazy.Vinke.Windows.Forms.LazyButton buttonProjectExplore;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelProjectDestinationPath;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxProjectDestinationPath;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelProjectName;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxProjectName;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelProjectModule;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxProjectModule;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelProjectDeveloper;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxProjectDeveloper;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxProjectProduct;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelProjectProduct;
        private Lazy.Vinke.Windows.Forms.LazyButton buttonProjectGenerate;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeatureRepositoryUrl;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxProjectRepositoryUrl;
        private Lazy.Vinke.Windows.Forms.LazyCheckBox checkBoxProjectGenerateBatchFiles;
    }
}

