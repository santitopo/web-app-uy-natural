using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LodgingSelectionModel
    {
        public string LodgingName { get; set; }
        public int TpointId { get; set; }

        public LodgingSelectionModel(string lodgingName, int tpointId)
        {
            this.LodgingName = lodgingName;
            this.TpointId = tpointId;
        }

        public LodgingSelectionModel()
        {
        }
    }
}
