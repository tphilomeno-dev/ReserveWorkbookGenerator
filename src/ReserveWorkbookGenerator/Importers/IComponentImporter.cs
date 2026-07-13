using ReserveWorkbookGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Importers
{
    public interface IComponentImporter
    {
        List<ReserveComponent> Load(string fileName);
    }
}
