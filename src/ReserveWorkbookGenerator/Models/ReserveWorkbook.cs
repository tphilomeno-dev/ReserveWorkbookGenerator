using System;
using System.Collections.Generic;
using System.Text;

namespace ReserveWorkbookGenerator.Models
{
    public sealed class ReserveWorkbook
    {
        public ReserveSettings Settings { get; init; } = new();

        public List<ReserveScheduleRow> Schedule { get; } = [];
    }
}
