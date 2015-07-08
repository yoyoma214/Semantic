using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataModels
{
    public class Mapping : TokenPair
    {
        public AtomTokenPair FromModel { get; set; }
        public AtomTokenPair TargetModel { get; set; }
        public AtomTokenPair FromField { get; set; }
        public AtomTokenPair FromNavigateProperty { get; set; }
        public AtomTokenPair TargetField { get; set; }
        public AtomTokenPair Relation { get; set; }
        public List<AtomTokenPair> ShowFields { get; set; }
        public AtomTokenPair SplitTag { get; set; }

        //FromModel.map(FromField,FromModel,FromNavigateProperty,TargetField,TargetModel
        public MappingInfo Parse()
        {
            var mapping = new MappingInfo();
            mapping.FromModel = this.FromModel;
            mapping.FromField = this.FromField;
            mapping.FromNavigateProperty = this.FromNavigateProperty;
            mapping.Relation = this.Relation;
            mapping.ShowFields = this.ShowFields;
            mapping.SplitTag = this.SplitTag;
            mapping.TargetModel = this.TargetModel;
            mapping.TargetField = this.TargetField;

            //if (this.Relation.Value == "ManyToMany")
            //{
            //    mapping.FromModel = this.FromNavigateProperty;
            //    mapping.FromField = this.FromField;
            //    mapping.FromNavigateProperty = null;
            //    mapping.TargetModel = this.TargetField;
            //    mapping.TargetField = this.TargetModel;
            //}

            return mapping;
        }
    }
}
