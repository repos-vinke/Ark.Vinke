// FormMain.cs
//
// This file is integrated part of Lazy project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2023, March 05

using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Lazy.Vinke;
using Lazy.Vinke.Windows;
using Lazy.Vinke.Windows.Forms;
using System.Globalization;

namespace Ark.Vinke.Studio
{
    public partial class FormMain : LazyForm
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FormMain()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Methods

        private void OnFormMain_Load(Object sender, EventArgs args)
        {
            this.comboBoxFeatureType.SelectedIndex = 1;
        }

        private void OnCheckBoxProjectGenerateSolution_CheckedChanged(Object sender, EventArgs args)
        {
            if (this.checkBoxProjectGenerateSolution.Checked == true)
                this.checkBoxProjectGenerateSolutionModule.Checked = true;
        }

        private void OnCheckBoxProjectGenerateSolutionModule_CheckedChanged(Object sender, EventArgs args)
        {
            if (this.checkBoxProjectGenerateSolutionModule.Checked == false)
                this.checkBoxProjectGenerateSolution.Checked = false;
        }

        private void OnButtonProjectGenerate_Click(Object sender, EventArgs args)
        {
            try
            {
                ValidateProject();

                GenerateProject();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void OnButtonFeatureGenerate_Click(Object sender, EventArgs args)
        {
            try
            {
                ValidateFeature();

                GenerateFeature();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Attention", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ValidateProject()
        {
            String projectName = null;

            if (String.IsNullOrWhiteSpace(this.textBoxProjectDeveloper.Text) == true)
                throw new Exception("Developer was not informed!");

            if (this.textBoxProjectDeveloper.Text.Contains('.') == true)
                throw new Exception("Developer cannot contains dots (.)!");

            if (String.IsNullOrWhiteSpace(this.textBoxProjectModule.Text) == true)
                throw new Exception("Module was not informed!");

            if (this.textBoxProjectModule.Text.Contains('.') == true)
                throw new Exception("Module cannot contains dots (.)!");

            if (String.IsNullOrWhiteSpace(this.textBoxProjectName.Text) == true)
                throw new Exception("Project was not informed!");

            if (this.textBoxProjectName.Text.Contains('.') == true)
                throw new Exception("Project cannot contains dots (.)!");

            if (String.IsNullOrWhiteSpace(this.textBoxProjectDestinationPath.Text) == true)
                throw new Exception("Project destination path was not informed!");

            if (Directory.Exists(this.textBoxProjectDestinationPath.Text) == false)
                throw new Exception("Project destination path does not exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text);
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, String.Join('.', projectName, "sln"))) == true && this.checkBoxProjectGenerateSolution.Checked == true)
                throw new Exception(projectName + " solution already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text);
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, String.Join('.', projectName, "Builder", "Debug", "bat"))) == true && this.checkBoxProjectGenerateBatchFiles.Checked == true)
                throw new Exception(projectName + ".Builder.Debug batch already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text);
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, String.Join('.', projectName, "Builder", "Release", "bat"))) == true && this.checkBoxProjectGenerateBatchFiles.Checked == true)
                throw new Exception(projectName + ".Builder.Release batch already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text);
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true && this.checkBoxProjectGenerateSolutionModule.Checked == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text);
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Data");
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Client");
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "IServer");
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Server");
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "IPlugin");
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "IService");
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Plugin");
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Servant");
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");

            projectName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Service");
            if (File.Exists(Path.Combine(this.textBoxProjectDestinationPath.Text, projectName, String.Join('.', projectName, "csproj"))) == true)
                throw new Exception(projectName + " project already exists!");
        }

        private void GenerateProject()
        {
            GenerateSolution();

            GenerateSolutionBatchFiles();

            GenerateSolutionModule();

            GenerateSolutionModuleProject();

            GenerateSolutionModuleProjectData();

            GenerateSolutionModuleProjectClient();

            GenerateSolutionModuleProjectConnector();

            GenerateSolutionModuleProjectIServer();

            GenerateSolutionModuleProjectServer();

            GenerateSolutionModuleProjectIPlugin();

            GenerateSolutionModuleProjectIService();

            GenerateSolutionModuleProjectPlugin();

            GenerateSolutionModuleProjectServant();

            GenerateSolutionModuleProjectService();
        }

        private void GenerateSolution()
        {
            if (this.checkBoxProjectGenerateSolution.Checked == true)
            {
                String solutionFileName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, "sln");
                String solutionFileFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, solutionFileName);

                File.WriteAllText(solutionFileFullPath, ReplaceSolution(Properties.ResourcesStudio.Ark_Developer_Module_sln), Encoding.UTF8);
            }
        }

        private void GenerateSolutionBatchFiles()
        {
            if (this.checkBoxProjectGenerateBatchFiles.Checked == true)
            {
                String batchFileName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, "Builder", "Debug", "bat");
                String batchFileFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, batchFileName);

                File.WriteAllText(batchFileFullPath, ReplaceBatchFiles(Properties.ResourcesStudio.Ark_Developer_Module_Builder_Debug_bat), Encoding.UTF8);

                batchFileName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, "Builder", "Release", "bat");
                batchFileFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, batchFileName);

                File.WriteAllText(batchFileFullPath, ReplaceBatchFiles(Properties.ResourcesStudio.Ark_Developer_Module_Builder_Release_bat), Encoding.UTF8);
            }
        }

        private void GenerateSolutionModule()
        {
            if (this.checkBoxProjectGenerateSolutionModule.Checked == true)
            {
                String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text);
                String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
                String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

                if (Directory.Exists(moduleFolderFullPath) == false)
                    Directory.CreateDirectory(moduleFolderFullPath);

                File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_csproj), Encoding.UTF8);
            }
        }

        private void GenerateSolutionModuleProject()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text);
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectData()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Data");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_Data_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectClient()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Client");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_Client_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectConnector()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Connector");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_Connector_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectIServer()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "IServer");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_IServer_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectServer()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Server");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_Server_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectIPlugin()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "IPlugin");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_IPlugin_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectIService()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "IService");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_IService_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectPlugin()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Plugin");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_Plugin_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectServant()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Servant");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_Servant_csproj), Encoding.UTF8);
        }

        private void GenerateSolutionModuleProjectService()
        {
            String moduleFolderName = String.Join('.', "Ark", this.textBoxProjectDeveloper.Text, this.textBoxProjectModule.Text, this.textBoxProjectName.Text, "Service");
            String moduleFolderFullPath = Path.Combine(this.textBoxProjectDestinationPath.Text, moduleFolderName);
            String moduleFileFullPath = Path.Combine(moduleFolderFullPath, String.Join('.', moduleFolderName, "csproj"));

            if (Directory.Exists(moduleFolderFullPath) == false)
                Directory.CreateDirectory(moduleFolderFullPath);

            File.WriteAllText(moduleFileFullPath, ReplaceSolutionModuleProject(Properties.ResourcesStudio.Ark_Developer_Module_Project_Service_csproj), Encoding.UTF8);
        }

        private String ReplaceSolution(String content)
        {
            content = content.Replace("{GUID-ARK-SOLUTION}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-DATA}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-CLIENT}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-CONNECTOR}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-ISERVER}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-SERVER}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-IPLUGIN}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-ISERVICE}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-PLUGIN}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-SERVANT}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-ARK-DEVELOPER-MODULE-PROJECT-SERVICE}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");

            content = content.Replace("{GUID-FOLDER-ARK-DEVELOPER-MODULE}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-FOLDER-ARK-DEVELOPER-MODULE-PROJECT}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-FOLDER-ARK-DEVELOPER-MODULE-PROJECT-CLIENT}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-FOLDER-ARK-DEVELOPER-MODULE-PROJECT-SERVER}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");
            content = content.Replace("{GUID-FOLDER-ARK-DEVELOPER-MODULE-PROJECT-SERVICE}", "{" + Guid.NewGuid().ToString().ToUpper() + "}");

            content = content.Replace("{DEVELOPER}", this.textBoxProjectDeveloper.Text);
            content = content.Replace("{MODULE}", this.textBoxProjectModule.Text);
            content = content.Replace("{PROJECT}", this.textBoxProjectName.Text);

            return content;
        }

        private String ReplaceBatchFiles(String content)
        {
            content = content.Replace("{DEVELOPER}", this.textBoxProjectDeveloper.Text);
            content = content.Replace("{MODULE}", this.textBoxProjectModule.Text);

            return content;
        }

        private String ReplaceSolutionModuleProject(String content)
        {
            content = content.Replace("{DEVELOPER}", this.textBoxProjectDeveloper.Text);
            content = content.Replace("{developer}", this.textBoxProjectDeveloper.Text.ToLower());

            content = content.Replace("{MODULE}", this.textBoxProjectModule.Text);
            content = content.Replace("{module}", this.textBoxProjectModule.Text.ToLower());

            content = content.Replace("{PROJECT}", this.textBoxProjectName.Text);
            content = content.Replace("{project}", this.textBoxProjectName.Text.ToLower());

            content = content.Replace("{REPOSITORY}", this.textBoxProjectRepositoryUrl.Text);

            return content;
        }

        private void ValidateFeature()
        {
            String projectName = null;
            String fileName = null;

            if (String.IsNullOrWhiteSpace(this.textBoxFeatureDeveloper.Text) == true)
                throw new Exception("Developer was not informed!");

            if (this.textBoxFeatureDeveloper.Text.Contains('.') == true)
                throw new Exception("Developer cannot contains dots (.)!");

            if (String.IsNullOrWhiteSpace(this.textBoxFeatureModule.Text) == true)
                throw new Exception("Module was not informed!");

            if (this.textBoxFeatureModule.Text.Contains('.') == true)
                throw new Exception("Module cannot contains dots (.)!");

            if (String.IsNullOrWhiteSpace(this.textBoxFeatureProject.Text) == true)
                throw new Exception("Project was not informed!");

            if (this.textBoxFeatureProject.Text.Contains('.') == true)
                throw new Exception("Project cannot contains dots (.)!");

            if (String.IsNullOrWhiteSpace(this.textBoxFeaturePrefix.Text) == true)
                throw new Exception("Prefix was not informed!");

            if (this.textBoxFeaturePrefix.Text.Contains('.') == true)
                throw new Exception("Prefix cannot contains dots (.)!");

            if (String.IsNullOrWhiteSpace(this.textBoxFeatureName.Text) == true)
                throw new Exception("Feature name was not informed!");

            if (this.textBoxFeatureName.Text.Contains('.') == true)
                throw new Exception("Feature name cannot contains dots (.)!");

            if (String.IsNullOrWhiteSpace(this.textBoxFeatureDestinationPath.Text) == true)
                throw new Exception("Project destination path was not informed!");

            if (Directory.Exists(this.textBoxFeatureDestinationPath.Text) == false)
                throw new Exception("Project destination path does not exists!");

            projectName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "Data");
            fileName = String.Join(null, this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Data", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            if (File.Exists(Path.Combine(this.textBoxFeatureDestinationPath.Text, projectName, String.Join('.', fileName, "cs"))) == true)
                throw new Exception(fileName + " already exists!");

            projectName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "IServer");
            fileName = String.Join(null, "I", this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Server", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            if (File.Exists(Path.Combine(this.textBoxFeatureDestinationPath.Text, projectName, String.Join('.', fileName, "cs"))) == true)
                throw new Exception(fileName + " already exists!");

            projectName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "Server");
            fileName = String.Join(null, this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Server", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            if (File.Exists(Path.Combine(this.textBoxFeatureDestinationPath.Text, projectName, String.Join('.', fileName, "cs"))) == true)
                throw new Exception(fileName + " already exists!");

            projectName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "IPlugin");
            fileName = String.Join(null, "I", this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Plugin", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            if (File.Exists(Path.Combine(this.textBoxFeatureDestinationPath.Text, projectName, String.Join('.', fileName, "cs"))) == true)
                throw new Exception(fileName + " already exists!");

            projectName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "IService");
            fileName = String.Join(null, "I", this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Service", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            if (File.Exists(Path.Combine(this.textBoxFeatureDestinationPath.Text, projectName, String.Join('.', fileName, "cs"))) == true)
                throw new Exception(fileName + " already exists!");

            projectName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "Servant");
            fileName = String.Join(null, this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Servant", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            if (File.Exists(Path.Combine(this.textBoxFeatureDestinationPath.Text, projectName, String.Join('.', fileName, "cs"))) == true)
                throw new Exception(fileName + " already exists!");

            projectName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "Service");
            fileName = String.Join(null, this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Service", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            if (File.Exists(Path.Combine(this.textBoxFeatureDestinationPath.Text, projectName, String.Join('.', fileName, "cs"))) == true)
                throw new Exception(fileName + " already exists!");
        }

        private void GenerateFeature()
        {
            GenerateFeatureData();

            GenerateFeatureConnector();

            GenerateFeatureIServer();

            GenerateFeatureServer();

            GenerateFeatureIPlugin();

            GenerateFeatureIService();

            GenerateFeatureServant();

            GenerateFeatureService();
        }

        private void GenerateFeatureData()
        {
            String featureFolderName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "Data");
            String featureFolderFullPath = Path.Combine(this.textBoxFeatureDestinationPath.Text, featureFolderName);
            String featureFileName = String.Join(null, this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Data", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            String featureFileFullPath = Path.Combine(featureFolderFullPath, String.Join('.', featureFileName, "cs"));

            if (Directory.Exists(featureFolderFullPath) == false)
                Directory.CreateDirectory(featureFolderFullPath);

            File.WriteAllText(featureFileFullPath, ReplaceFeatureContent(Properties.ResourcesStudio.ModFeatureData), Encoding.UTF8);
        }

        private void GenerateFeatureConnector()
        {
            String featureFolderName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "Connector");
            String featureFolderFullPath = Path.Combine(this.textBoxFeatureDestinationPath.Text, featureFolderName);
            String featureFileName = String.Join(null, this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Connector", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            String featureFileFullPath = Path.Combine(featureFolderFullPath, String.Join('.', featureFileName, "cs"));

            if (Directory.Exists(featureFolderFullPath) == false)
                Directory.CreateDirectory(featureFolderFullPath);

            File.WriteAllText(featureFileFullPath, ReplaceFeatureContent(Properties.ResourcesStudio.ModFeatureConnector), Encoding.UTF8);
        }

        private void GenerateFeatureIServer()
        {
            String featureFolderName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "IServer");
            String featureFolderFullPath = Path.Combine(this.textBoxFeatureDestinationPath.Text, featureFolderName);
            String featureFileName = String.Join(null, "I", this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Server", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            String featureFileFullPath = Path.Combine(featureFolderFullPath, String.Join('.', featureFileName, "cs"));

            if (Directory.Exists(featureFolderFullPath) == false)
                Directory.CreateDirectory(featureFolderFullPath);

            File.WriteAllText(featureFileFullPath, ReplaceFeatureContent(Properties.ResourcesStudio.IModFeatureServer), Encoding.UTF8);
        }

        private void GenerateFeatureServer()
        {
            String featureFolderName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "Server");
            String featureFolderFullPath = Path.Combine(this.textBoxFeatureDestinationPath.Text, featureFolderName);
            String featureFileName = String.Join(null, this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Server", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            String featureFileFullPath = Path.Combine(featureFolderFullPath, String.Join('.', featureFileName, "cs"));

            if (Directory.Exists(featureFolderFullPath) == false)
                Directory.CreateDirectory(featureFolderFullPath);

            File.WriteAllText(featureFileFullPath, ReplaceFeatureContent(Properties.ResourcesStudio.ModFeatureServer), Encoding.UTF8);
        }

        private void GenerateFeatureIPlugin()
        {
            String featureFolderName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "IPlugin");
            String featureFolderFullPath = Path.Combine(this.textBoxFeatureDestinationPath.Text, featureFolderName);
            String featureFileName = String.Join(null, "I", this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Plugin", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            String featureFileFullPath = Path.Combine(featureFolderFullPath, String.Join('.', featureFileName, "cs"));

            if (Directory.Exists(featureFolderFullPath) == false)
                Directory.CreateDirectory(featureFolderFullPath);

            File.WriteAllText(featureFileFullPath, ReplaceFeatureContent(Properties.ResourcesStudio.IModFeaturePlugin), Encoding.UTF8);
        }

        private void GenerateFeatureIService()
        {
            String featureFolderName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "IService");
            String featureFolderFullPath = Path.Combine(this.textBoxFeatureDestinationPath.Text, featureFolderName);
            String featureFileName = String.Join(null, "I", this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Service", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            String featureFileFullPath = Path.Combine(featureFolderFullPath, String.Join('.', featureFileName, "cs"));

            if (Directory.Exists(featureFolderFullPath) == false)
                Directory.CreateDirectory(featureFolderFullPath);

            File.WriteAllText(featureFileFullPath, ReplaceFeatureContent(Properties.ResourcesStudio.IModFeatureService), Encoding.UTF8);
        }

        private void GenerateFeatureServant()
        {
            String featureFolderName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "Servant");
            String featureFolderFullPath = Path.Combine(this.textBoxFeatureDestinationPath.Text, featureFolderName);
            String featureFileName = String.Join(null, this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Servant", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            String featureFileFullPath = Path.Combine(featureFolderFullPath, String.Join('.', featureFileName, "cs"));

            if (Directory.Exists(featureFolderFullPath) == false)
                Directory.CreateDirectory(featureFolderFullPath);

            File.WriteAllText(featureFileFullPath, ReplaceFeatureContent(Properties.ResourcesStudio.ModFeatureServant), Encoding.UTF8);
        }

        private void GenerateFeatureService()
        {
            String featureFolderName = String.Join('.', "Ark", this.textBoxFeatureDeveloper.Text, this.textBoxFeatureModule.Text, this.textBoxFeatureProject.Text, "Service");
            String featureFolderFullPath = Path.Combine(this.textBoxFeatureDestinationPath.Text, featureFolderName);
            String featureFileName = String.Join(null, this.textBoxFeaturePrefix.Text, this.textBoxFeatureName.Text, "Service", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());
            String featureFileFullPath = Path.Combine(featureFolderFullPath, String.Join('.', featureFileName, "cs"));

            if (Directory.Exists(featureFolderFullPath) == false)
                Directory.CreateDirectory(featureFolderFullPath);

            File.WriteAllText(featureFileFullPath, ReplaceFeatureContent(Properties.ResourcesStudio.ModFeatureService), Encoding.UTF8);
        }

        private String ReplaceFeatureContent(String content)
        {
            content = content.Replace("{DEVELOPER}", this.textBoxFeatureDeveloper.Text);
            content = content.Replace("{MODULE}", this.textBoxFeatureModule.Text);
            content = content.Replace("{PROJECT}", this.textBoxFeatureProject.Text);

            content = content.Replace("{PREFIX}", this.textBoxFeaturePrefix.Text);
            content = content.Replace("{FEATURE}", this.textBoxFeatureName.Text);
            content = content.Replace("{TYPE}", this.comboBoxFeatureType.SelectedIndex == 0 ? String.Empty : this.comboBoxFeatureType.SelectedItem.ToString());

            content = content.Replace("{FULLNAME}", this.textBoxFeatureDeveloperFullName.Text);

            content = content.Replace("{YEAR}", DateTime.Now.ToString("yyyy"));
            content = content.Replace("{MONTH}", CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month));
            content = content.Replace("{DAY}", DateTime.Now.ToString("dd"));

            return content;
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }
}
