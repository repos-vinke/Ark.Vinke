
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
            tabPageFeature = new System.Windows.Forms.TabPage();
            buttonFeatureExplore = new Lazy.Vinke.Windows.Forms.LazyButton();
            labelFeatureSolutionPath = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxFeatureDestinationPath = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            buttonFeatureGenerate = new Lazy.Vinke.Windows.Forms.LazyButton();
            textBoxFeatureDeveloperFullName = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            labelFeatureDeveloperFullName = new Lazy.Vinke.Windows.Forms.LazyLabel();
            labelFeatureType = new Lazy.Vinke.Windows.Forms.LazyLabel();
            comboBoxFeatureType = new Lazy.Vinke.Windows.Forms.LazyComboBox();
            labelFeatureProject = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxFeatureProject = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            labelFeatureModule = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxFeatureModule = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            labelFeatureDeveloper = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxFeatureDeveloper = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            textBoxFeatureProduct = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            labelFeatureProduct = new Lazy.Vinke.Windows.Forms.LazyLabel();
            labelFeatureName = new Lazy.Vinke.Windows.Forms.LazyLabel();
            textBoxFeatureName = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            textBoxFeaturePrefix = new Lazy.Vinke.Windows.Forms.LazyTextBox();
            labelFeaturePrefix = new Lazy.Vinke.Windows.Forms.LazyLabel();
            tabControl.SuspendLayout();
            tabPageProject.SuspendLayout();
            tabPageFeature.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageProject);
            tabControl.Controls.Add(tabPageFeature);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.DockOnCenter = false;
            tabControl.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            tabControl.Location = new System.Drawing.Point(8, 8);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(736, 493);
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
            tabPageProject.Size = new System.Drawing.Size(728, 453);
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
            // 
            // buttonProjectGenerate
            // 
            buttonProjectGenerate.DockOnCenter = false;
            buttonProjectGenerate.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonProjectGenerate.Location = new System.Drawing.Point(299, 394);
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
            // tabPageFeature
            // 
            tabPageFeature.Controls.Add(buttonFeatureExplore);
            tabPageFeature.Controls.Add(labelFeatureSolutionPath);
            tabPageFeature.Controls.Add(textBoxFeatureDestinationPath);
            tabPageFeature.Controls.Add(buttonFeatureGenerate);
            tabPageFeature.Controls.Add(textBoxFeatureDeveloperFullName);
            tabPageFeature.Controls.Add(labelFeatureDeveloperFullName);
            tabPageFeature.Controls.Add(labelFeatureType);
            tabPageFeature.Controls.Add(comboBoxFeatureType);
            tabPageFeature.Controls.Add(labelFeatureProject);
            tabPageFeature.Controls.Add(textBoxFeatureProject);
            tabPageFeature.Controls.Add(labelFeatureModule);
            tabPageFeature.Controls.Add(textBoxFeatureModule);
            tabPageFeature.Controls.Add(labelFeatureDeveloper);
            tabPageFeature.Controls.Add(textBoxFeatureDeveloper);
            tabPageFeature.Controls.Add(textBoxFeatureProduct);
            tabPageFeature.Controls.Add(labelFeatureProduct);
            tabPageFeature.Controls.Add(labelFeatureName);
            tabPageFeature.Controls.Add(textBoxFeatureName);
            tabPageFeature.Controls.Add(textBoxFeaturePrefix);
            tabPageFeature.Controls.Add(labelFeaturePrefix);
            tabPageFeature.Location = new System.Drawing.Point(4, 36);
            tabPageFeature.Name = "tabPageFeature";
            tabPageFeature.Size = new System.Drawing.Size(728, 453);
            tabPageFeature.TabIndex = 1;
            tabPageFeature.Text = "Feature";
            tabPageFeature.UseVisualStyleBackColor = true;
            // 
            // buttonFeatureExplore
            // 
            buttonFeatureExplore.DockOnCenter = false;
            buttonFeatureExplore.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonFeatureExplore.Location = new System.Drawing.Point(666, 273);
            buttonFeatureExplore.Name = "buttonFeatureExplore";
            buttonFeatureExplore.Size = new System.Drawing.Size(31, 31);
            buttonFeatureExplore.TabIndex = 23;
            buttonFeatureExplore.UseVisualStyleBackColor = true;
            // 
            // labelFeatureSolutionPath
            // 
            labelFeatureSolutionPath.AutoSize = true;
            labelFeatureSolutionPath.DockOnCenter = false;
            labelFeatureSolutionPath.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeatureSolutionPath.Location = new System.Drawing.Point(29, 243);
            labelFeatureSolutionPath.Name = "labelFeatureSolutionPath";
            labelFeatureSolutionPath.Size = new System.Drawing.Size(168, 27);
            labelFeatureSolutionPath.TabIndex = 21;
            labelFeatureSolutionPath.Text = "Solution path";
            // 
            // textBoxFeatureDestinationPath
            // 
            textBoxFeatureDestinationPath.DockOnCenter = false;
            textBoxFeatureDestinationPath.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFeatureDestinationPath.Location = new System.Drawing.Point(29, 273);
            textBoxFeatureDestinationPath.Name = "textBoxFeatureDestinationPath";
            textBoxFeatureDestinationPath.Size = new System.Drawing.Size(631, 31);
            textBoxFeatureDestinationPath.TabIndex = 22;
            // 
            // buttonFeatureGenerate
            // 
            buttonFeatureGenerate.DockOnCenter = false;
            buttonFeatureGenerate.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            buttonFeatureGenerate.Location = new System.Drawing.Point(299, 394);
            buttonFeatureGenerate.Name = "buttonFeatureGenerate";
            buttonFeatureGenerate.Size = new System.Drawing.Size(125, 42);
            buttonFeatureGenerate.TabIndex = 20;
            buttonFeatureGenerate.Text = "Generate";
            buttonFeatureGenerate.UseVisualStyleBackColor = true;
            buttonFeatureGenerate.Click += OnButtonFeatureGenerate_Click;
            // 
            // textBoxFeatureDeveloperFullName
            // 
            textBoxFeatureDeveloperFullName.DockOnCenter = false;
            textBoxFeatureDeveloperFullName.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFeatureDeveloperFullName.Location = new System.Drawing.Point(29, 201);
            textBoxFeatureDeveloperFullName.Name = "textBoxFeatureDeveloperFullName";
            textBoxFeatureDeveloperFullName.Size = new System.Drawing.Size(487, 31);
            textBoxFeatureDeveloperFullName.TabIndex = 19;
            // 
            // labelFeatureDeveloperFullName
            // 
            labelFeatureDeveloperFullName.AutoSize = true;
            labelFeatureDeveloperFullName.DockOnCenter = false;
            labelFeatureDeveloperFullName.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeatureDeveloperFullName.Location = new System.Drawing.Point(29, 171);
            labelFeatureDeveloperFullName.Name = "labelFeatureDeveloperFullName";
            labelFeatureDeveloperFullName.Size = new System.Drawing.Size(240, 27);
            labelFeatureDeveloperFullName.TabIndex = 18;
            labelFeatureDeveloperFullName.Text = "Developer full name";
            // 
            // labelFeatureType
            // 
            labelFeatureType.AutoSize = true;
            labelFeatureType.DockOnCenter = false;
            labelFeatureType.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeatureType.Location = new System.Drawing.Point(522, 99);
            labelFeatureType.Name = "labelFeatureType";
            labelFeatureType.Size = new System.Drawing.Size(60, 27);
            labelFeatureType.TabIndex = 17;
            labelFeatureType.Text = "Type";
            // 
            // comboBoxFeatureType
            // 
            comboBoxFeatureType.DockOnCenter = false;
            comboBoxFeatureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxFeatureType.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            comboBoxFeatureType.FormattingEnabled = true;
            comboBoxFeatureType.Items.AddRange(new object[] { "Base", "Basic", "Process", "Record", "View" });
            comboBoxFeatureType.Location = new System.Drawing.Point(522, 127);
            comboBoxFeatureType.Name = "comboBoxFeatureType";
            comboBoxFeatureType.Size = new System.Drawing.Size(175, 35);
            comboBoxFeatureType.TabIndex = 16;
            // 
            // labelFeatureProject
            // 
            labelFeatureProject.AutoSize = true;
            labelFeatureProject.DockOnCenter = false;
            labelFeatureProject.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeatureProject.Location = new System.Drawing.Point(522, 27);
            labelFeatureProject.Name = "labelFeatureProject";
            labelFeatureProject.Size = new System.Drawing.Size(96, 27);
            labelFeatureProject.TabIndex = 14;
            labelFeatureProject.Text = "Project";
            // 
            // textBoxFeatureProject
            // 
            textBoxFeatureProject.DockOnCenter = false;
            textBoxFeatureProject.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFeatureProject.Location = new System.Drawing.Point(522, 57);
            textBoxFeatureProject.Name = "textBoxFeatureProject";
            textBoxFeatureProject.Size = new System.Drawing.Size(175, 31);
            textBoxFeatureProject.TabIndex = 15;
            textBoxFeatureProject.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelFeatureModule
            // 
            labelFeatureModule.AutoSize = true;
            labelFeatureModule.DockOnCenter = false;
            labelFeatureModule.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeatureModule.Location = new System.Drawing.Point(341, 27);
            labelFeatureModule.Name = "labelFeatureModule";
            labelFeatureModule.Size = new System.Drawing.Size(84, 27);
            labelFeatureModule.TabIndex = 12;
            labelFeatureModule.Text = "Module";
            // 
            // textBoxFeatureModule
            // 
            textBoxFeatureModule.DockOnCenter = false;
            textBoxFeatureModule.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFeatureModule.Location = new System.Drawing.Point(341, 57);
            textBoxFeatureModule.Name = "textBoxFeatureModule";
            textBoxFeatureModule.Size = new System.Drawing.Size(175, 31);
            textBoxFeatureModule.TabIndex = 13;
            textBoxFeatureModule.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelFeatureDeveloper
            // 
            labelFeatureDeveloper.AutoSize = true;
            labelFeatureDeveloper.DockOnCenter = false;
            labelFeatureDeveloper.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeatureDeveloper.Location = new System.Drawing.Point(160, 27);
            labelFeatureDeveloper.Name = "labelFeatureDeveloper";
            labelFeatureDeveloper.Size = new System.Drawing.Size(120, 27);
            labelFeatureDeveloper.TabIndex = 10;
            labelFeatureDeveloper.Text = "Developer";
            // 
            // textBoxFeatureDeveloper
            // 
            textBoxFeatureDeveloper.DockOnCenter = false;
            textBoxFeatureDeveloper.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFeatureDeveloper.Location = new System.Drawing.Point(160, 57);
            textBoxFeatureDeveloper.Name = "textBoxFeatureDeveloper";
            textBoxFeatureDeveloper.Size = new System.Drawing.Size(175, 31);
            textBoxFeatureDeveloper.TabIndex = 11;
            textBoxFeatureDeveloper.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxFeatureProduct
            // 
            textBoxFeatureProduct.DockOnCenter = false;
            textBoxFeatureProduct.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFeatureProduct.Location = new System.Drawing.Point(29, 57);
            textBoxFeatureProduct.Name = "textBoxFeatureProduct";
            textBoxFeatureProduct.ReadOnly = true;
            textBoxFeatureProduct.Size = new System.Drawing.Size(125, 31);
            textBoxFeatureProduct.TabIndex = 9;
            textBoxFeatureProduct.Text = "Ark";
            textBoxFeatureProduct.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelFeatureProduct
            // 
            labelFeatureProduct.AutoSize = true;
            labelFeatureProduct.DockOnCenter = false;
            labelFeatureProduct.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeatureProduct.Location = new System.Drawing.Point(29, 27);
            labelFeatureProduct.Name = "labelFeatureProduct";
            labelFeatureProduct.Size = new System.Drawing.Size(96, 27);
            labelFeatureProduct.TabIndex = 8;
            labelFeatureProduct.Text = "Product";
            // 
            // labelFeatureName
            // 
            labelFeatureName.AutoSize = true;
            labelFeatureName.DockOnCenter = false;
            labelFeatureName.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeatureName.Location = new System.Drawing.Point(160, 99);
            labelFeatureName.Name = "labelFeatureName";
            labelFeatureName.Size = new System.Drawing.Size(60, 27);
            labelFeatureName.TabIndex = 6;
            labelFeatureName.Text = "Name";
            // 
            // textBoxFeatureName
            // 
            textBoxFeatureName.DockOnCenter = false;
            textBoxFeatureName.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFeatureName.Location = new System.Drawing.Point(160, 129);
            textBoxFeatureName.Name = "textBoxFeatureName";
            textBoxFeatureName.Size = new System.Drawing.Size(356, 31);
            textBoxFeatureName.TabIndex = 7;
            textBoxFeatureName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxFeaturePrefix
            // 
            textBoxFeaturePrefix.DockOnCenter = false;
            textBoxFeaturePrefix.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFeaturePrefix.Location = new System.Drawing.Point(29, 129);
            textBoxFeaturePrefix.Name = "textBoxFeaturePrefix";
            textBoxFeaturePrefix.Size = new System.Drawing.Size(125, 31);
            textBoxFeaturePrefix.TabIndex = 5;
            textBoxFeaturePrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelFeaturePrefix
            // 
            labelFeaturePrefix.AutoSize = true;
            labelFeaturePrefix.DockOnCenter = false;
            labelFeaturePrefix.Font = new System.Drawing.Font("Cascadia Mono", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            labelFeaturePrefix.Location = new System.Drawing.Point(29, 99);
            labelFeaturePrefix.Name = "labelFeaturePrefix";
            labelFeaturePrefix.Size = new System.Drawing.Size(84, 27);
            labelFeaturePrefix.TabIndex = 4;
            labelFeaturePrefix.Text = "Prefix";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(752, 509);
            Controls.Add(tabControl);
            Margin = new System.Windows.Forms.Padding(4);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(770, 556);
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(770, 556);
            Name = "FormMain";
            Padding = new System.Windows.Forms.Padding(8);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Ark Vinke Studio";
            Load += OnFormMain_Load;
            tabControl.ResumeLayout(false);
            tabPageProject.ResumeLayout(false);
            tabPageProject.PerformLayout();
            tabPageFeature.ResumeLayout(false);
            tabPageFeature.PerformLayout();
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
        private System.Windows.Forms.TabPage tabPageFeature;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeatureProject;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxFeatureProject;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeatureModule;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxFeatureModule;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeatureDeveloper;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxFeatureDeveloper;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxFeatureProduct;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeatureProduct;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeatureName;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxFeatureName;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxFeaturePrefix;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeaturePrefix;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeatureType;
        private Lazy.Vinke.Windows.Forms.LazyComboBox comboBoxFeatureType;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxFeatureDeveloperFullName;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeatureDeveloperFullName;
        private Lazy.Vinke.Windows.Forms.LazyButton buttonFeatureGenerate;
        private Lazy.Vinke.Windows.Forms.LazyButton buttonFeatureExplore;
        private Lazy.Vinke.Windows.Forms.LazyLabel labelFeatureSolutionPath;
        private Lazy.Vinke.Windows.Forms.LazyTextBox textBoxFeatureDestinationPath;
    }
}

