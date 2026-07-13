using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Models
{
    public sealed class ReserveCategory
    {
        public string Name { get; set; } = string.Empty;

        public int DisplayOrder { get; set; }

        public bool PrintSubtotal { get; set; } = true;
    }
}
