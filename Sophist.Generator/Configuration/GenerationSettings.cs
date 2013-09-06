using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sophist.Generator.Configuration
{
    [DefaultProperty("ProjectName")]
    public class GenerationSettings
    {
        [Description("The project name."), DisplayName("Project Name"), CategoryAttribute("Projects Settings")]
        public string ProjectName { get; set; }

        [Description("The project default namespace."), DisplayName("Project Namespace"), CategoryAttribute("Projects Settings")]
        public string ProjectNamespace { get; set; }

        [Description("The path to the solution folder."), DisplayName("Project Path"), CategoryAttribute("Projects Settings")]
        public string ProjectPath { get; set; }

        [Description("The models namespace name."), DisplayName("Models Namespace"), CategoryAttribute("Models Settings")]
        public string EntitiesNamespace { get; set; }

        [Description("The path to models folders."), DisplayName("Models Path"), CategoryAttribute("Models Settings")]
        public string EntitiesPath { get; set; }

        [Description("The models mappings namespace name."), DisplayName("Mappings Namespace"), CategoryAttribute("Models Settings")]
        public string MappingsNamespace { get; set; }

        [Description("The path to models mappings folders."), DisplayName("Mappings Path"), CategoryAttribute("Models Settings")]
        public string MappingsPath { get; set; }

        [Description("The models metadata namespace."), DisplayName("Models Metadata Namespace"), CategoryAttribute("Models Settings")]
        public string EntitiesMetadataNamespace { get; set; }

        [Description("The path to models metadata folder."), DisplayName("Models Metadata Path"), CategoryAttribute("Models Settings")]
        public string EntitiesMetadataPath { get; set; }

        [Description("The model validation namespace."), DisplayName("Validators Namespace"), CategoryAttribute("Models Settings")]
        public string ValidationNamespace { get; set; }

        [Description("The path to the model validators folder."), DisplayName("Validators Path"), CategoryAttribute("Models Settings")]
        public string ValidationPath { get; set; }

        [Description("The data contracts namespace."), DisplayName("Data Contracts Namespace"), CategoryAttribute("Data Providers Settings")]
        public string ContractsNamespace { get; set; }

        [Description("The path to the data contracts folder."), DisplayName("Data Contracts Path"), CategoryAttribute("Data Providers Settings")]
        public string ContractsPath { get; set; }

        [Description("The repository namespace."), DisplayName("Repository Namespace"), CategoryAttribute("Data Providers Settings")]
        public string DataProvidersNamespace { get; set; }

        [Description("The path to the repository folder."), DisplayName("Repository Path"), CategoryAttribute("Data Providers Settings")]
        public string DataProvidersPath { get; set; }
    }
}
