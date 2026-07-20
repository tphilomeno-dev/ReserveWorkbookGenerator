using ReserveWorkbookGenerator.Importers;
using ReserveWorkbookGenerator.Exporters;
using ReserveWorkbookGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Editor.Services
{
    public sealed class StudyFileService
    {
        private readonly JsonReserveStudyImporter _importer = new();
        private readonly JsonReserveStudyExporter _exporter = new();

        public ReserveStudy Load(string fileName)
        {
            return _importer.Load(fileName);
        }

        public void Save(string fileName, ReserveStudy study)
        {
            _exporter.Save(fileName, study);
        }
    }
}
